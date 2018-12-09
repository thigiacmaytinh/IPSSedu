#include "Image.h"

ImageCpp::ImageCpp(void)
{

}

ImageCpp::ImageCpp(string imgPath)
{
	m_img = cv::imread(imgPath, cv::IMREAD_COLOR);
}

ImageCpp::~ImageCpp(void)
{

}
int ImageCpp::ColoredDot(int dotSize)
{
	
    if (!m_img.data)
        return -1;

    cv::Mat dstImg = cv::Mat::zeros(m_img.size(), CV_8UC3);
    cv::Mat cir = cv::Mat::zeros(m_img.size(), CV_8UC1);


    for (int i = 0; i < m_img.rows; i += dotSize)
    {
        for (int j = 0; j < m_img.cols; j += dotSize)
        {
            cv::Rect rect = cv::Rect(j, i, dotSize, dotSize) & cv::Rect(0, 0, m_img.cols, m_img.rows);

            cv::Mat sub_dst(dstImg, rect);
            sub_dst.setTo(mean(m_img(rect)));

            circle(
                cir, 
                cv::Point(j + dotSize/2, i + dotSize/2), 
                dotSize/2 - 1, 
                CV_RGB(255,255,255), -1, CV_AA
            );
        }
    }

    cv::Mat cir_32f;
    cir.convertTo(cir_32f, CV_32F);
    normalize(cir_32f, cir_32f, 0, 1, cv::NORM_MINMAX);

    cv::Mat dst_32f;
    dstImg.convertTo(dst_32f, CV_32F);

    vector<cv::Mat> channels;
    split(dst_32f, channels);
    for (int i = 0; i < channels.size(); ++i)
        channels[i] = channels[i].mul(cir_32f);

    merge(channels, dst_32f);
    dst_32f.convertTo(dstImg, CV_8U);  
	m_img = dstImg;
}
/////////////////////////////////////////////////////////////////////////////////////////////
void ImageCpp::Show(string windowName)
{
	if(m_img.data)
		imshow(windowName, m_img);
}
/////////////////////////////////////////////////////////////////////////////////////////////
void ImageCpp::Show()
{

	if(m_img.data)
	{
		char* info= new char[100];
		sprintf(info, "Width: %d - Height %d", m_img.cols, m_img.rows);
		imshow(info, m_img);
		delete[] info;
	}
}
/////////////////////////////////////////////////////////////////////////////////////////////
int ImageCpp::Rotate(int angle)
{
	if(!m_img.data)
		return 0;
	int len = max(m_img.cols, m_img.rows);
    cv::Point2f pt(len/2., len/2.);
    cv::Mat r = cv::getRotationMatrix2D(pt, angle, 1.0);
	cv::Mat dst;
    warpAffine(m_img, dst, r, cv::Size(len, len));
	
	//imshow(string("Rotate ") + to_string((long double)angle) + string(" angle"), dst);
	m_img = dst;
}
int ImageCpp::FindingContour(int threshold1, int threshold2)
{
	if(!m_img.data ) // Check for invalid input
    {
		return 0;
    }
	cv::Mat gray;
	cvtColor(m_img, gray, CV_BGR2GRAY);
	
	cv::Mat dstImg;
	//imshow("Anh xam", gray);
	GaussianBlur(gray, gray, cv::Size(9,9), 2);
	//double t1 = 30, t2 = 200;
	Canny(gray, dstImg, threshold1, threshold2, 3, false);
	m_img = dstImg;
}
int ImageCpp::FindLineCircle()
{
	if(!m_img.data ) // Check for invalid input
    {
		return 0;
    }
	cv::Mat gray;
	cvtColor(m_img, gray, CV_BGR2GRAY);
	GaussianBlur(gray, gray, cv::Size(9, 9), 2, 2 );

	// Tim duong thang
	cv::Mat canny;
	Canny(gray, canny, 100, 200, 3, false);
	vector<cv::Vec4i> lines;
	HoughLinesP(canny, lines, 1, CV_PI/180, 50, 60, 10);
	
	// Tim duong tron
	vector<cv::Vec3f> circles;
	HoughCircles(gray, circles, CV_HOUGH_GRADIENT, 1, 100, 200, 100, 0, 0);
	
	// Ve duong thang, duong tron len anh
	for(int i = 0; i < lines.size(); i++ )
	{
		cv::Vec4i l = lines[i];
		cv::line(m_img, cv::Point(l[0], l[1]), cv::Point(l[2], l[3]), cv::Scalar(0,0,255), 2);
	}

	for(int i = 0; i < circles.size(); i++ )
	{
      cv::Point center(cvRound(circles[i][0]), cvRound(circles[i][1])); // Tam
      int radius = cvRound(circles[i][2]);  // Ban kinh
      circle(m_img, center, radius, cv::Scalar(0,0,255), 2, 8, 0 );
	}

	imshow("Anh sau khi tim thay duong thang - Duong tron", m_img);
	return 0;
}
int ImageCpp::FindDigitsInLicensePlate()
{
	//images\\BienSo.jpg
	if(!m_img.data)
		return 0;
	cv::Mat src2 = m_img.clone(); // copy anh
	cv::Mat gray, binary;
	cvtColor(m_img, gray, CV_BGR2GRAY);
	threshold(gray, binary, 100, 255, CV_THRESH_BINARY);
	imshow("Anh nhi phan goc", binary);
	cv::Mat morpho;
	cv::Mat element = cv::getStructuringElement(cv::MORPH_CROSS, cv::Size(3,3), cv::Point(1,1));
	erode(binary, morpho, element, cv::Point(-1,-1), 3);
	imshow("Anh sau khi thuc hien phep gian no", morpho);

	vector<vector<cv::Point> > contours1;
	findContours(binary, contours1, CV_RETR_LIST, CV_CHAIN_APPROX_NONE );
	for(size_t i = 0; i < contours1.size(); i++)
	{
		cv::Rect r = boundingRect(contours1[i]);
		if(r.width/(double)r.height > 3.5f && r.width/(double)r.height < 4.5f)
			rectangle(m_img, r, cv::Scalar(0, 0, 255), 2, 8, 0);
		else
			rectangle(m_img, r, cv::Scalar(0, 255, 0), 1, 8, 0);
	}
	imshow("Ket qua phat hien truoc phep gian no", m_img);

	
	vector<vector<cv::Point> > contours2;
    findContours(morpho, contours2, CV_RETR_LIST, CV_CHAIN_APPROX_NONE );
	for(size_t i = 0; i < contours2.size(); i++)
	{
		cv::Rect r = boundingRect(contours2[i]);
		if(r.width/(double)r.height > 3.5f && r.width/(double)r.height < 4.5f)
			rectangle(src2, r, cv::Scalar(0, 0, 255), 2, 8, 0);
		else
			rectangle(src2, r, cv::Scalar(0, 255, 0), 1, 8, 0);
	}
	imshow("Ket qua phat hien sau khi phep gian no", src2);
}
int ImageCpp::FindFace()
{
	cv::Mat gray;
	vector<cv::Rect> faces;
	cv::CascadeClassifier cascade;
	if(!m_img.data) // Check for invalid input
    {
		return 0;
    }
	cvtColor(m_img, gray, CV_BGR2GRAY);
	// load file training
	if (FILE *file = fopen("haarcascade_frontalface_alt.xml", "r")) 
	{
        fclose(file);
		cascade.load("haarcascade_frontalface_alt.xml");
    }
	else 
	{
        return 0;
    }   
	
	//detect face
	cascade.detectMultiScale(gray, faces, 1.1 , 2, 	CV_HAAR_SCALE_IMAGE, cv::Size(30, 30));
	if(faces.empty())
	{
		return 0;
	}
	// draw rectangle at face detected
	for(int i = 0; i < faces.size(); ++i)
	{
		rectangle(m_img, faces.at(i), CV_RGB(200,0,0), 2);
	}
	return faces.size();
}
int ImageCpp::WaterShed()
{
	if (!m_img.data)
		return -1;

	// Create binary image from source image
	cv::Mat bw;
	cvtColor(m_img, bw, CV_BGR2GRAY);
	threshold(bw, bw, 40, 255, CV_THRESH_BINARY);

	//Get the distance transform and normalize the result to [0,1] so we can visualize and threshold it
	cv::Mat dist;
	distanceTransform(bw, dist, CV_DIST_L2, 3);
	normalize(dist, dist, 0.0, 1.0, cv::NORM_MINMAX);

	threshold(dist, dist, 0.5, 1.0, CV_THRESH_BINARY);

	// Create the CV_8U version of the distance image
	// It is needed for findContours()
	cv::Mat dist_8u;
	dist.convertTo(dist_8u, CV_8U);

	// Find total markers
	vector<vector<cv::Point> > contours;
	findContours(dist_8u, contours, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_SIMPLE);

	// Total objects
	int ncomp = contours.size();

	cv::Mat markers = cv::Mat::zeros(dist.size(), CV_32SC1);
	for (int i = 0; i < ncomp; i++)
		drawContours(markers, contours, i, cv::Scalar::all(i+1), -1);
	
	circle(markers, cv::Point(5,5), 3, CV_RGB(255,255,255), -1);
	watershed(m_img, markers);

	// Generate random colors
	vector<cv::Vec3b> colors;
	for (int i = 0; i < ncomp; i++)
	{
		int b = cv::theRNG().uniform(0, 255);
		int g = cv::theRNG().uniform(0, 255);
		int r = cv::theRNG().uniform(0, 255);

		colors.push_back(cv::Vec3b((uchar)b, (uchar)g, (uchar)r));
	}

	// Create the result image
	cv::Mat dst = cv::Mat::zeros(markers.size(), CV_8UC3);

	// Fill labeled objects with random colors
	for (int i = 0; i < markers.rows; i++)
	{
		for (int j = 0; j < markers.cols; j++)
		{
			int index = markers.at<int>(i,j);
			if (index > 0 && index <= ncomp)
				dst.at<cv::Vec3b>(i,j) = colors[index-1];
			else
				dst.at<cv::Vec3b>(i,j) = cv::Vec3b(0,0,0);
		}
	}

	m_img = dst;
	return 1;
}
/////////////////////////////////////////////////////////////////////////////////////////////
bool ImageCpp::IsHaveData()
{
	return m_img.data;
}
/////////////////////////////////////////////////////////////////////////////////////////////
void ImageCpp::CaptureWC()
{
	cv::VideoCapture cap(0); // open the default camera
    if(cap.isOpened())  // check if we succeeded
	{
		cv::Mat frame;
		while(true)
		{
			cap >> frame; // get a new frame from camera
      		imshow("Original", frame);

			if(cv::waitKey(30) >= 0) break;
		}
	}
}
/////////////////////////////////////////////////////////////////////////////////////////////
void ImageCpp::SolveSudoku(cv::Mat img)
{
	//cv::Mat img = imread("images\\sudoku.jpg");
	cv::Mat gray;
	cvtColor(img, gray, cv::COLOR_BGR2GRAY);
	GaussianBlur(gray, gray, cv::Size(5,5), 0);
	adaptiveThreshold(gray, gray,255,1,1,11,2);
	
	vector<vector<cv::Point>> contours;
	findContours(gray, contours, cv::RETR_TREE, cv::CHAIN_APPROX_SIMPLE);

	vector<cv::Point> biggest;
	vector<cv::Point> approx;
	double max_area = 0;
	for (int i=0; i<contours.size(); i++)
	{
		vector<cv::Point> c = contours.at(i);
		double area = contourArea(c);
		if(area > 100)
		{
			double peri = arcLength(c, true);
			approxPolyDP(c, approx, 0.02 * peri,true);
			if (area > max_area && approx.size()==4)
			{
				biggest = approx;
				max_area = area;
			}
		}
	}
	//get 4 coners
	int minAdd = 0;
	int maxAdd = 0;
	int minMinus = 0;
	int maxMinus = 0;
	int minAddIdx = 0;
	int maxAddIdx = 0;
	int minMinusIdx = 0;
	int maxMinusIdx = 0;
	cv::Point2f hnew[4];
	if(biggest.size()== 0)
		return;
	minAdd = biggest.at(0).x + biggest.at(0).y;
	maxAdd = biggest.at(0).x + biggest.at(0).y;
	minMinus = biggest.at(0).y - biggest.at(0).x;
	maxMinus = biggest.at(0).y - biggest.at(0).x;
	for(int i=0; i<biggest.size(); i++)
	{
		int x = biggest.at(i).x;
		int y = biggest.at(i).y;
		if(x + y < minAdd) 
		{
			minAdd = x + y;
			minAddIdx = i;
		}
		if(x + y > maxAdd)
		{
			maxAdd = x + y;
			maxAddIdx = i;
		}
		if(y - x < minMinus)
		{
			minMinus = y - x;
			minMinusIdx = i;
		}
		if(y - x > maxMinus)
		{
			maxMinus = y - x;
			maxMinusIdx = i;
		}
	}
	hnew[0] = biggest.at(minAddIdx);
	hnew[1] = biggest.at(minMinusIdx);
	hnew[2] = biggest.at(maxMinusIdx);
	hnew[3] = biggest.at(maxAddIdx);

	cv::Point2f h[4] = {cv::Point2f(0.0), cv:: Point2f (449,0), cv::Point2f(0, 449), cv::Point2f(449, 449)};

	cv::Mat retval = getPerspectiveTransform(hnew, h);
	cv::Mat warp;
	warpPerspective(img, warp, retval, cv::Size(450, 450));


	cout<<max_area<<"\n";
	imshow("Gray", gray);
	imshow("warp", warp);
}

void ImageCpp::SolveSudoku()
{
	cv::VideoCapture cap(0); // open the default camera
    if(cap.isOpened())  // check if we succeeded
	{
		cv::Mat frame;
		while(true)
		{
			cap >> frame;
			imshow("Original", frame);
			SolveSudoku(frame);

			if(cv::waitKey(30) >=0) break;
		}
	}
}

cv::Mat ImageCpp::WarpPerspective(cv::Mat mat, cv::Point2i top_left, cv::Point2i top_right, cv::Point2i bot_right, cv::Point2i bot_left)
{	
	cv::Point2f src[4], dst[4];
	src[0] = top_left;			dst[0]= cv::Point2f(0,0);
	src[1] = top_right;			dst[1]= cv::Point2f(mat.cols-1, 0);
	src[2] = bot_right;			dst[2]= cv::Point2f(mat.cols-1, mat.rows-1);
	src[3] = bot_left;			dst[3]= cv::Point2f(0, mat.rows-1);

	cv::Mat mat2 = mat.clone();
	cv::warpPerspective(mat, mat2, cv::getPerspectiveTransform(src, dst), cv::Size(mat.cols, mat.rows));
	return mat2;
}