#pragma once
#include "stdafx.h"
class TGMTshape
{
public:
	//TGMTshape();
	//~TGMTshape();

	struct Circle
	{		
	public:
		float radius;
		cv::Point center;

		Circle(cv::Vec3f v)
		{
			center.x = v[0];
			center.y = v[1];
			radius = v[2];
		}

		Circle(cv::Point2f _center, float _radius)
		{
			center.x = _center.x;
			center.y = _center.y;
			radius = _radius;
		}
	};

	static int FindLineAndCircle(cv::Mat);

	static std::vector<cv::Vec2f> DetectLine(cv::Mat matInput);
	static std::vector<Circle> DetectCircle(cv::Mat);

	static cv::Mat DetectAndDrawLine(cv::Mat imgInput);
	static cv::Mat DetectAndDrawLine(std::string filePath);

	static cv::Point GetCenterPoint(cv::Rect rect);
	static bool IsOverlap(cv::Rect rect1, cv::Rect rect2);

	static cv::Rect ExpandRect(cv::Rect rect, float scaleRatioX, float scaleRatioY);
	static std::vector<cv::Rect> ExpandRects(std::vector<cv::Rect> rects, float scaleRatioX, float scaleRatioY, cv::Mat currentMat);
	static bool IsValidRect(cv::Rect rect);
	static bool IsRectInsideMat(cv::Rect rect, cv::Mat matInput, int padding = 0);
	static bool IsRectInsideMat(cv::RotatedRect rrect, cv::Mat matInput, int padding = 0);
	static bool IsRectInsideRect(cv::Rect rectIn, cv::Rect rectOut);

	
	static std::vector<std::vector<cv::Point> > FindSquares(const cv::Mat image);
	static cv::Mat DrawSquares(cv::Mat matInput, const std::vector<std::vector<cv::Point> > squares);
};

