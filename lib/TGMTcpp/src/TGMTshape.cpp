#include "TGMTshape.h"
#include "TGMTdebugger.h"
#include "TGMTimage.h"
#include "TGMTcolor.h"
#include "TGMTdraw.h"

//TGMTshape::TGMTshape()
//{
//}
//
//////////////////////////////////////////////////////////////////////////////////////////////////////
//
//TGMTshape::~TGMTshape()
//{
//}

////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<cv::Vec2f> TGMTshape::DetectLine(cv::Mat matInput)
{
	std::vector<cv::Vec2f> result;
	cv::HoughLines(matInput, result, 1, CV_PI / 180, 100);
	return result;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

int TGMTshape::FindLineAndCircle(cv::Mat imgInput)
{
	if (!imgInput.data) // Check for invalid input
	{
		return 0;
	}
	cv::Mat gray;
	cvtColor(imgInput, gray, CV_BGR2GRAY);
	GaussianBlur(gray, gray, cv::Size(9, 9), 2, 2);

	// Tim duong thang
	cv::Mat canny;
	Canny(gray, canny, 100, 200, 3, false);
	std::vector<cv::Vec4i> lines;
	HoughLinesP(canny, lines, 1, CV_PI / 180, 50, 60, 10);

	
	// Ve duong thang, duong tron len anh
	for (int i = 0; i < lines.size(); i++)
	{
		cv::Vec4i l = lines[i];
		line(imgInput, cv::Point(l[0], l[1]), cv::Point(l[2], l[3]), cv::Scalar(0, 0, 255), 2);
	}
	cv::imshow("Anh sau khi tim thay duong thang - Duong tron", imgInput);
	return 0;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<TGMTshape::Circle> TGMTshape::DetectCircle(cv::Mat matInput)
{
	cv::Mat gray = TGMTimage::ConvertToGray(matInput);
	GaussianBlur(gray, gray, cv::Size(9, 9), 2, 2);
	// Tim duong tron
	
	std::vector<cv::Vec3f> circles;
	std::vector<Circle> result;
	HoughCircles(gray, circles, CV_HOUGH_GRADIENT, 1, 100, 200, 100, 0, 0);
	for (size_t i = 0; i < circles.size(); i++)
	{
		result.push_back(Circle(circles[i]));
	}

	return result;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTshape::DetectAndDrawLine(cv::Mat imgSrc)
{
	if (!imgSrc.data)
		return cv::Mat(1, 1, 0);
	cv::Mat imgBlur, imgGray, imgBinary;
	cv::cvtColor(imgSrc, imgGray, CV_BGR2GRAY);

	//convert BGR image to binary image
#if 0
	GaussianBlur(imgGray, imgBlur, cv::Size(3, 3), 2);
	imshow("imgBlur", imgBlur);
	cv::Canny(imgBlur, imgBinary, 50, 150, 3);
#else
	GaussianBlur(imgGray, imgBlur, cv::Size(9, 9), 2);
	cv::threshold(imgBlur, imgBinary, 0, 255, CV_THRESH_OTSU);
#endif
	imshow("imgBinary", imgBinary);
	//DEBUG_IMAGE(imgBlur, "IMG BLUR");

	//detect lines
#if 1

	std::vector<cv::Vec2f> lines;
	HoughLines(imgBinary, lines, 1, CV_PI / 180, 100);
	TGMTdraw::DrawLines(imgSrc, lines);
#else

	std::vector<cv::Vec4i> lines;
	HoughLinesP(imgBinary, lines, 1, CV_PI / 180, 50, 50, 10);
	TGMTshape::DrawLines(imgSrc, lines);
#endif
	return imgSrc;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTshape::DetectAndDrawLine(std::string filePath)
{
	return DetectAndDrawLine(cv::imread(filePath));
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Point TGMTshape::GetCenterPoint(cv::Rect rect)
{
	return cv::Point(rect.x + rect.width / 2, rect.y + rect.height / 2);
}

////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTshape::IsOverlap(cv::Rect rect1, cv::Rect rect2)
{
	int area = (rect1 & rect2).area();
	return area > 0;
}

////////////////////////////////////////////////////////////////////////////////////////////////////



////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<cv::Rect> TGMTshape::ExpandRects(std::vector<cv::Rect> rects, float scaleRatioX, float scaleRatioY, cv::Mat currentMat)
{
	std::vector<cv::Rect> result;
	for (size_t i = 0; i < rects.size(); i++)
	{
		cv::Rect r = ExpandRect(rects[i], scaleRatioX, scaleRatioY);
		if (IsRectInsideMat(r, currentMat))
			result.push_back(r);
		else
			result.push_back(rects[i]);
	}
	return result;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Rect TGMTshape::ExpandRect(cv::Rect rect, float scaleRatioX, float scaleRatioY)
{
	if (scaleRatioX == 1 && scaleRatioY == 1)
		return rect;

	cv::Rect r = rect;
	r.x -= (r.width * scaleRatioX - r.width) / 2;
	r.y -= (r.height * scaleRatioY - r.height) / 2;
	r.width *= scaleRatioX;
	r.height *= scaleRatioY;

	if (IsValidRect(r))
	{
		return r;
	}
	return rect;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTshape::IsValidRect(cv::Rect rect)
{
	return rect.x >= 0 && rect.y >= 0 && rect.width > 0 && rect.height > 0;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTshape::IsRectInsideMat(cv::Rect rect, cv::Mat matInput, int padding)
{	
	return rect.x > padding &&
		rect.y > padding &&
		rect.x + rect.width < matInput.cols - padding &&
		rect.y + rect.height < matInput.rows - padding;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTshape::IsRectInsideMat(cv::RotatedRect rrect, cv::Mat matInput, int padding)
{
	cv::Rect rect = rrect.boundingRect();
	return rect.x > padding &&
		rect.y > padding &&
		rect.x + rect.width < matInput.cols - padding &&
		rect.y + rect.height < matInput.rows - padding;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTshape::IsRectInsideRect(cv::Rect rectIn, cv::Rect rectOut)
{
	return rectIn.x >= rectOut.x &&
		rectIn.y >= rectOut.y &&
		rectIn.x + rectIn.width <= rectOut.x + rectOut.width &&
		rectIn.y + rectIn.height <= rectOut.y + rectOut.height;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

// helper function:
// finds a cosine of angle between vectors
// from pt0->pt1 and from pt0->pt2
static double angle(cv::Point pt1, cv::Point pt2, cv::Point pt0)
{
	double dx1 = pt1.x - pt0.x;
	double dy1 = pt1.y - pt0.y;
	double dx2 = pt2.x - pt0.x;
	double dy2 = pt2.y - pt0.y;
	return (dx1*dx2 + dy1*dy2) / sqrt((dx1*dx1 + dy1*dy1)*(dx2*dx2 + dy2*dy2) + 1e-10);
}

////////////////////////////////////////////////////////////////////////////////////////////////////

// returns sequence of squares detected on the image.
// the sequence is stored in the specified memory storage
std::vector<std::vector<cv::Point> > TGMTshape::FindSquares(const cv::Mat image)
{
	int thresh = 50;
	int N = 11;
	std::vector<std::vector<cv::Point> > squares;

	cv::Mat pyr, timg, gray0(image.size(), CV_8U), gray;

	// down-scale and upscale the image to filter out the noise
	cv::pyrDown(image, pyr, cv::Size(image.cols / 2, image.rows / 2));
	cv::pyrUp(pyr, timg, image.size());
	std::vector<std::vector<cv::Point> > contours;

	// find squares in every color plane of the imagethres
	for (int c = 0; c < 3; c++)
	{
		int ch[] = { c, 0 };
		cv::mixChannels(&timg, 1, &gray0, 1, ch, 1);

		// try several threshold levels
		for (int l = 0; l < N; l++)
		{
			// hack: use Canny instead of zero threshold level.
			// Canny helps to catch squares with gradient shading
			if (l == 0)
			{
				// apply Canny. Take the upper threshold from slider
				// and set the lower to 0 (which forces edges merging)
				cv::Canny(gray0, gray, 0, thresh, 5);
				// dilate canny output to remove potential
				// holes between edge segments
				cv::dilate(gray, gray, cv::Mat(), cv::Point(-1, -1));
			}
			else
			{
				// apply threshold if l!=0:
				//     tgray(x,y) = gray(x,y) < (l+1)*255/N ? 255 : 0
				gray = gray0 >= (l + 1) * 255 / N;
			}

			// find contours and store them all as a list
			cv::findContours(gray, contours, cv::RETR_LIST, cv::CHAIN_APPROX_SIMPLE);

			std::vector<cv::Point> approx;

			// test each contour
			for (size_t i = 0; i < contours.size(); i++)
			{
				// approximate contour with accuracy proportional
				// to the contour perimeter
				cv::approxPolyDP(cv::Mat(contours[i]), approx, cv::arcLength(cv::Mat(contours[i]), true)*0.02, true);

				// square contours should have 4 vertices after approximation
				// relatively large area (to filter out noisy contours)
				// and be convex.
				// Note: absolute value of an area is used because
				// area may be positive or negative - in accordance with the
				// contour orientation
				if (approx.size() == 4 &&
					fabs(cv::contourArea(cv::Mat(approx))) > 1000 &&
					cv::isContourConvex(cv::Mat(approx)))
				{
					double maxCosine = 0;

					for (int j = 2; j < 5; j++)
					{
						// find the maximum cosine of the angle between joint edges
						double cosine = fabs(angle(approx[j % 4], approx[j - 2], approx[j - 1]));
						maxCosine = MAX(maxCosine, cosine);
					}

					// if cosines of all angles are small
					// (all angles are ~90 degree) then write quandrange
					// vertices to resultant sequence
					if (maxCosine < 0.3)
						squares.push_back(approx);
				}
			}
		}
	}

	return squares;
}

////////////////////////////////////////////////////////////////////////////////////////////////////

// the function draws all the squares in the image
cv::Mat TGMTshape::DrawSquares(cv::Mat matInput, const std::vector<std::vector<cv::Point> > squares)
{
	cv::Mat matDraw = matInput.clone();
	for (size_t i = 0; i < squares.size(); i++)
	{
		const cv::Point* p = &squares[i][0];
		int n = (int)squares[i].size();
		polylines(matDraw, &p, &n, 1, true, cv::Scalar(0, 255, 0), 3, cv::LINE_AA);
	}
	

	return matDraw;
}