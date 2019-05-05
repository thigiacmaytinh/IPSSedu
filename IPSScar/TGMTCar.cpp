#include "TGMTcar.h"
#include "OCR.h"
#include "TGMTdraw.h"
#include "TGMTdebugger.h"
#include "TGMTimage.h"
#include "TGMTbrightness.h"
#include "TGMTshape.h"
#include "TGMTtransform.h"

TGMTcar* TGMTcar::m_instance = nullptr;

////////////////////////////////////////////////////////////////////////////////////////////////////

TGMTcar::TGMTcar()
{
	GetOCR()->Init("OCR.xml");
	m_debug = true;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

TGMTcar::~TGMTcar()
{
}

////////////////////////////////////////////////////////////////////////////////////////////////////

CarPlateCpp TGMTcar::ReadPlate(std::string filePath)
{
	return ReadPlate(cv::imread(filePath));
}

////////////////////////////////////////////////////////////////////////////////////////////////////

CarPlateCpp TGMTcar::ReadPlate(cv::Mat matInput)
{
	START_COUNT_TIME("GetLicensePlateCar");
	cv::Mat plate = DetectPlate(matInput);


	CarPlateCpp result;
	if (!plate.data)
		return result;

	result.hasPlate = true;
	result.image = plate;
	result.text = ReadTextFromPlate(plate);

	result.elapsedMilisecond = STOP_AND_PRINT_COUNT_TIME("GetLicensePlateCar");
	return result;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTcar::IsValidPlateSize(cv::RotatedRect rect)
{

	float error = 0.6;
	float plateAspect = 4.3;
	//Set a min and max area. All other patchs are discarded
	int minHeight = MIN_PLATE_W / plateAspect;
	int maxHeight = MAX_PLATE_W / plateAspect;


	//check width and height
	int w = cv::max(rect.size.width, rect.size.height);
	int h = cv::min(rect.size.width, rect.size.height);
	if (w < MIN_PLATE_W || h < minHeight || w > MAX_PLATE_W || h > maxHeight)
		return false;


	//check aspect
	float aspect = (float)w / (float)h;
	if (aspect < 1)
		aspect = (float)h / (float)w;
	float minAspect = 2.5;
	float maxAspect = plateAspect + plateAspect*error;
	if (aspect < minAspect || aspect > maxAspect)
		return false;



	//check aera
	int minAera = MIN_PLATE_W * minHeight; // minimum area
	int maxArea = MAX_PLATE_W * maxHeight; // maximum area
	int area = rect.size.height * rect.size.width;
	if (area > minAera && area < maxArea)
		return true;
	else
		return false;

}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTcar::DetectPlate(cv::Mat matInput)
{
	if (matInput.cols > 600)
	{
		matInput = TGMTtransform::ResizeByWidth(matInput, 600);
	}
	std::vector<cv::Mat> plates;


	//convert image to gray
	cv::Mat img_gray = TGMTimage::ConvertToGray(matInput);

	cv::blur(img_gray, img_gray, cv::Size(5, 5));

	//Finde vertical lines. Car plates have high density of vertical lines
	cv::Mat img_sobel;
	cv::Sobel(img_gray, img_sobel, CV_8U, 1, 0, 3, 1, 0, cv::BORDER_DEFAULT);
	//DEBUG_IMAGE(img_sobel, "sobel");

	//threshold image
	cv::Mat img_threshold;
	cv::threshold(img_sobel, img_threshold, 0, 255, CV_THRESH_OTSU + CV_THRESH_BINARY);
	//DEBUG_IMAGE(img_threshold, "threshold");

	//Morphplogic operation close
	cv::Mat element = cv::getStructuringElement(cv::MORPH_RECT, cv::Size(17, 3));
	cv::morphologyEx(img_threshold, img_threshold, cv::MORPH_CLOSE, element);


	//Find contours of possibles plates
	std::vector< std::vector< cv::Point> > contours;
	cv::findContours(img_threshold,
		contours, // a vector of contours
		CV_RETR_EXTERNAL, // retrieve the external contours
		CV_CHAIN_APPROX_NONE); // all pixels of each contours


	cv::Mat matContour = img_threshold.clone();
	cv::drawContours(matContour, contours, -1, RED);
	//DEBUG_IMAGE(matContour, "contour detected");



	//Start to iterate to each contour founded
	std::vector<std::vector<cv::Point> >::iterator itc = contours.begin();
	std::vector<cv::RotatedRect> rotatedRects;


	//Remove patch that are no inside limits of aspect ratio and area.    
	while (itc != contours.end())
	{
		//Create bounding cv::Rect of object
		cv::RotatedRect rRect = minAreaRect(cv::Mat(*itc));
		int contourSize = itc->size();
		int aera = rRect.boundingRect().area();
		int angle = cv::abs(rRect.angle);
		if (!IsValidPlateSize(rRect)
			|| contourSize < 200
			|| !TGMTshape::IsRectInsideMat(rRect, matInput)
			|| contourSize < aera / 30
			|| (angle > 20 && angle < 70))
		{
			itc = contours.erase(itc);
		}
		else
		{
			++itc;
			rotatedRects.push_back(rRect);
		}
	}

	cv::Mat matTemp = TGMTdraw::DrawRotatedRectangles(img_threshold, rotatedRects, 2);

	for (int i = 0; i < rotatedRects.size(); i++)
	{
		//get the min size between width and height
		float minSize = cv::min(rotatedRects[i].size.width, rotatedRects[i].size.height);
		minSize -= minSize * 0.5;


		//initialize rand and get 5 points around center for floodfill algorithm
		srand(time(NULL));


		//Initialize floodfill parameters and variables
		cv::Mat mask;
		mask.create(matInput.rows + 2, matInput.cols + 2, CV_8UC1);
		mask = cv::Scalar::all(0);
		int connectivity = 4;
		int newMaskVal = 255;
		int NumSeeds = 10;
		cv::Rect ccomp;
		int flags = connectivity + (newMaskVal << 8) + cv::FLOODFILL_FIXED_RANGE + cv::FLOODFILL_MASK_ONLY;
		for (int j = 0; j < NumSeeds; j++)
		{
			cv::Point seed;
			seed.x = rotatedRects[i].center.x + rand() % (int)minSize - (minSize / 2);
			seed.y = rotatedRects[i].center.y + rand() % (int)minSize - (minSize / 2);
			if (seed.x < matInput.cols && seed.y < matInput.rows && seed.x > -1 && seed.y > -1)
			{
				int area = cv::floodFill(matInput, mask, seed, RED, &ccomp, cv::Scalar(loDiff, loDiff, loDiff), cv::Scalar(upDiff, upDiff, upDiff), flags);
			}
		}


		//Check new floodfill mask cv::Match for a corcv::Rect patch.
		//Get all points detected for get Minimal rotated cv::Rect
		std::vector<cv::Point> pointsInterest;
		cv::Mat_<uchar>::iterator itMask = mask.begin<uchar>();
		cv::Mat_<uchar>::iterator end = mask.end<uchar>();
		for (; itMask != end; ++itMask)
		{
			if (*itMask == 255)
				pointsInterest.push_back(itMask.pos());
		}


		cv::RotatedRect minRect = cv::minAreaRect(pointsInterest);

		if (IsValidPlateSize(minRect))
		{
			// rotated cv::Rectangle drawing 
			cv::Point2f Rect_points[4];
			minRect.points(Rect_points);

			//Get rotation cv::Matrix
			float r = (float)minRect.size.width / (float)minRect.size.height;
			float angle = minRect.angle;
			if (r < 1)
				angle += 90;
			cv::Mat rotMat = cv::getRotationMatrix2D(minRect.center, angle, 1);

			//Create and rotate image
			cv::Mat img_rotated;
			cv::warpAffine(matInput, img_rotated, rotMat, matInput.size(), cv::INTER_CUBIC);

			//Crop image
			cv::Size Rect_size = minRect.size;
			if (r < 1)
				cv::swap(Rect_size.width, Rect_size.height);
			cv::Mat img_crop;
			cv::getRectSubPix(img_rotated, Rect_size, minRect.center, img_crop);

			cv::Mat resultResized;
			resultResized.create(33, 144, CV_8UC3);
			cv::resize(img_crop, resultResized, resultResized.size(), 0, 0, cv::INTER_CUBIC);

			cv::Mat grayResult = TGMTimage::ConvertToGray(resultResized);

			cv::blur(grayResult, grayResult, cv::Size(3, 3));
			TGMTbrightness::AutoLuminance(grayResult);


			cv::Rect bRect = minRect.boundingRect();
			if (bRect.width < bRect.height * 3)
				continue;
			if (bRect.width > 300)
				continue;

			plates.push_back(grayResult);
#ifdef _DEBUG
			cv::Mat matRegion = matInput.clone();
			for (int i = 0; i < plates.size(); i++)
			{
				cv::rectangle(matRegion, minRect.boundingRect(), GREEN);
			}
			DEBUG_IMAGE(matRegion, "posible_regions");
#endif
		}
	}

	cv::Mat plate;
	if (plates.size() == 0)
	{
		PrintError("Can not detect plate");
		return plate;
	}
	else
		PrintSuccess("Plate detected: %d", plates.size());



	plate = plates[0];
	return plate;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTcar::ReadTextFromPlate(cv::Mat plate)
{
	cv::Mat matGray = TGMTimage::ConvertToGray(plate);

	cv::equalizeHist(matGray, matGray);

	cv::Mat matBinary;
	cv::threshold(matGray, matBinary, 60, 255, cv::THRESH_BINARY_INV);

	DEBUG_IMAGE(matBinary, "threshold");

	//Find contours of possibles characters
	std::vector< std::vector< cv::Point> > contours;
	cv::findContours(matBinary,
		contours, // a vector of contours
		CV_RETR_EXTERNAL, // retrieve the external contours
		CV_CHAIN_APPROX_NONE); // all pixels of each contours

						
	// Draw blue contours on a white image
	cv::Mat result = matBinary.clone();

	cv::cvtColor(result, result, cv::COLOR_GRAY2RGB);
	cv::drawContours(result, contours,
		-1, // draw all contours
		BLUE, // in blue
		1); // with a thickness of 1

	//Start to iterate to each contour founded
	std::vector<std::vector<cv::Point> >::iterator itc = contours.begin();

	std::vector<cv::Rect> charsPos;
	//Remove patch that are no inside limits of aspect ratio and area.    
	while (itc != contours.end())
	{
		//Create bounding rect of object
		cv::Rect rect = cv::boundingRect(cv::Mat(*itc));
		if (rect.area() > 10)
		{
			//Crop image
			cv::Mat matChar = matBinary(rect);
			if (IsValidCharSize(matChar))
			{				
				charsPos.push_back(rect);
				cv::rectangle(result, rect, GREEN);
			}
		}
		++itc;
	}
	std::cout << "Num chars: " << charsPos.size() << "\n";

	//sort char by position
	for (int i = 0; i < charsPos.size(); i++)
	{
		for (int j = 0; j < charsPos.size(); j++)
		{
			if (charsPos[i].x < charsPos[j].x)
			{
				auto temp1 = charsPos[i];
				charsPos[i] = charsPos[j];
				charsPos[j] = temp1;
			}
		}
	}

	std::string text = "";
	for (int i = 0; i < charsPos.size(); i++)
	{
		cv::Mat matChar = matBinary(charsPos[i]);
		matChar = PreprocessChar(matChar);
		cv::Mat f = GetFeatures(matChar, 15);
#if USE_ANN
		int label = GetOCR()->ClassifyAnn(f);
#else
		int label = GetOCR()->ClassifyKnn(f);
#endif
		char c = GetOCR()->strCharacters[label];
		text += c;
	}

	cv::imshow("Segmented Chars", result);
	return text;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTcar::PreprocessChar(cv::Mat in)
{
	//Remap image
	int h = in.rows;
	int w = in.cols;
	cv::Mat transformMat = cv::Mat::eye(2, 3, CV_32F);
	int m = cv::max(w, h);
	transformMat.at<float>(0, 2) = m / 2 - w / 2;
	transformMat.at<float>(1, 2) = m / 2 - h / 2;

	cv::Mat warpImage(m, m, in.type());
	cv::warpAffine(in, warpImage, transformMat, warpImage.size(), cv::INTER_LINEAR, cv::BORDER_CONSTANT, cv::Scalar(0));

	cv::Mat out;
	cv::resize(warpImage, out, cv::Size(CHAR_SIZE, CHAR_SIZE));

	return out;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTcar::GetFeatures(cv::Mat in, int sizeData)
{
	//Histogram features
	cv::Mat vhist = ProjectedHistogram(in, VERTICAL);
	cv::Mat hhist = ProjectedHistogram(in, HORIZONTAL);

	//Low data feature
	cv::Mat lowData;
	cv::resize(in, lowData, cv::Size(sizeData, sizeData));

	if(m_debug)
		DrawVisualFeatures(in, hhist, vhist, lowData);



	//Last 10 is the number of moments components
	int numCols = vhist.cols + hhist.cols + lowData.cols * lowData.rows;

	cv::Mat out = cv::Mat::zeros(1, numCols, CV_32F);
	//Asign values to feature
	int j = 0;
	for (int i = 0; i < vhist.cols; i++)
	{
		out.at<float>(j) = vhist.at<float>(i);
		j++;
	}

	for (int i = 0; i < hhist.cols; i++)
	{
		out.at<float>(j) = hhist.at<float>(i);
		j++;
	}

	for (int x = 0; x < lowData.cols; x++)
	{
		for (int y = 0; y < lowData.rows; y++)
		{
			out.at<float>(j) = (float)lowData.at<uchar>(x, y);
			j++;
		}
	}
	return out;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTcar::DrawVisualFeatures(cv::Mat character, cv::Mat hhist, cv::Mat vhist, cv::Mat lowData)
{
	cv::Mat img(121, 121, CV_8UC3, cv::Scalar(0, 0, 0));
	cv::Mat ch;
	cv::Mat ld;

	cv::cvtColor(character, ch, CV_GRAY2RGB);

	cv::resize(lowData, ld, cv::Size(100, 100), 0, 0, cv::INTER_NEAREST);
	cv::cvtColor(ld, ld, CV_GRAY2RGB);

	cv::Mat hh = GetVisualHistogram(hhist, HORIZONTAL);
	cv::Mat hv = GetVisualHistogram(vhist, VERTICAL);

	cv::Mat roi = img(cv::Rect(0, 101, 20, 20));
	ch.copyTo(roi);

	roi = img(cv::Rect(21, 101, 100, 20));
	hh.copyTo(roi);

	roi = img(cv::Rect(0, 0, 20, 100));
	hv.copyTo(roi);

	roi = img(cv::Rect(21, 0, 100, 100));
	ld.copyTo(roi);

	cv::line(img, cv::Point(0, 100), cv::Point(121, 100), RED);
	cv::line(img, cv::Point(20, 0), cv::Point(20, 121), RED);

	cv::imshow("Visual Features", img);
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTcar::GetVisualHistogram(cv::Mat hist, int type)
{

	int size = 100;
	cv::Mat imHist;


	if (type == HORIZONTAL)
	{
		imHist.create(cv::Size(size, hist.cols), CV_8UC3);
	}
	else
	{
		imHist.create(cv::Size(hist.cols, size), CV_8UC3);
	}

	imHist = cv::Scalar(55, 55, 55);

	for (int i = 0; i < hist.cols; i++)
	{
		float value = hist.at<float>(i);
		int maxval = (int)(value*size);

		cv::Point pt1;
		cv::Point pt2, pt3, pt4;

		if (type == HORIZONTAL)
		{
			pt1.x = pt3.x = 0;
			pt2.x = pt4.x = maxval;
			pt1.y = pt2.y = i;
			pt3.y = pt4.y = i + 1;

			cv::line(imHist, pt1, pt2, cv::Scalar(220, 220, 220), 1, 8, 0);
			cv::line(imHist, pt3, pt4, cv::Scalar(34, 34, 34), 1, 8, 0);

			pt3.y = pt4.y = i + 2;
			cv::line(imHist, pt3, pt4, cv::Scalar(44, 44, 44), 1, 8, 0);
			pt3.y = pt4.y = i + 3;
			cv::line(imHist, pt3, pt4, cv::Scalar(50, 50, 50), 1, 8, 0);
		}
		else
		{
			pt1.x = pt2.x = i;
			pt3.x = pt4.x = i + 1;
			pt1.y = pt3.y = 100;
			pt2.y = pt4.y = 100 - maxval;


			cv::line(imHist, pt1, pt2, cv::Scalar(220, 220, 220), 1, 8, 0);
			cv::line(imHist, pt3, pt4, cv::Scalar(34, 34, 34), 1, 8, 0);

			pt3.x = pt4.x = i + 2;
			cv::line(imHist, pt3, pt4, cv::Scalar(44, 44, 44), 1, 8, 0);
			pt3.x = pt4.x = i + 3;
			cv::line(imHist, pt3, pt4, cv::Scalar(50, 50, 50), 1, 8, 0);

		}
	}

	return imHist;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTcar::ProjectedHistogram(cv::Mat img, int orient)
{
	int sz = orient ? img.rows : img.cols;
	cv::Mat mhist = cv::Mat::zeros(1, sz, CV_32F);

	for (int j = 0; j < sz; j++)
	{
		cv::Mat data = orient ? img.row(j) : img.col(j);
		mhist.at<float>(j) = cv::countNonZero(data);
	}

	//Normalize histogram
	double min, max;
	cv::minMaxLoc(mhist, &min, &max);

	if (max > 0)
		mhist.convertTo(mhist, -1, 1.0f / max, 0);

	return mhist;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTcar::IsValidCharSize(cv::Mat matChar)
{
	float minHeight = 15;
	float maxHeight = 28;

	if (matChar.rows < minHeight || matChar.rows > maxHeight)
		return false;

	//Char sizes 45x77
	float aspect = 45.0f / 77.0f;
	float charAspect = (float)matChar.cols / (float)matChar.rows;
	if (charAspect < 0.2)
		return false;
	float error = 0.35;
	
	//We have a different aspect ratio for number 1, and it can be ~0.2
	float maxAspect = aspect + aspect*error;
	if (charAspect > maxAspect)
		return false;
	//area of pixels
	float area = cv::countNonZero(matChar);
	//bb area
	float bbArea = matChar.cols * matChar.rows;
	//% of pixel in area
	float percPixels = area / bbArea;

	if (percPixels < 0.8)
		return true;
	else
		return false;

}