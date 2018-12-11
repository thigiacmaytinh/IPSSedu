#pragma once
#include "stdafx.h"
#include "TGMTshape.h"

class TGMTdraw
{
	static cv::Mat PutText(cv::Mat img, cv::Point p, cv::Scalar color, float fontScale, char* text);
public:
	static void DrawLine(cv::Mat matInput,cv::Point pt1, cv::Point pt2, cv::Scalar color);
	static void DrawLine(cv::Mat matInput,cv::Point pt1, cv::Point pt2, cv::Scalar color, int thickness);
	static void DrawLine(cv::Mat matInput,cv::Point pt1, cv::Point pt2, cv::Scalar color, int thickness, int lineType);
	static void DrawLine(cv::Mat matInput, cv::Point pt1, cv::Point pt2, cv::Scalar color, int thickness, int lineType, int shift);
	static void DrawLine(cv::Mat imgInput, int rhoValue, int thetaValue);
	static void DrawLine(cv::Mat img, cv::Vec2f line, cv::Scalar color = RED);
	static void DrawLine(cv::Mat img, cv::Vec4i line, cv::Scalar color = RED);
	static void DrawLines(cv::Mat img, std::vector<cv::Vec2f> lines, cv::Scalar color = RED);
	static void DrawLines(cv::Mat img, std::vector<cv::Vec4i> lines, cv::Scalar color = RED);

	static cv::Mat DrawRectangle(const cv::Mat matInput, cv::Rect rect, cv::Scalar color = RED);
	static cv::Mat DrawRectangle(const cv::Mat matInput, cv::Rect rect, cv::Scalar color, int thickness);
	static cv::Mat DrawRectangle(const cv::Mat matInput, cv::Rect rect, cv::Scalar color, int thickness, int lineType);
	static cv::Mat DrawRectangle(const cv::Mat matInput, cv::Rect rect, cv::Scalar color, int thickness, int lineType, int shift);

	static void DrawRectangles(cv::Mat& matInput, std::vector<cv::Rect> rects, int thickness = 1, cv::Scalar color = UNDEFINED_COLOR);

	static cv::Mat DrawRotatedRectangle(cv::Mat matInput, cv::RotatedRect rect, int thickness = 1, cv::Scalar color = UNDEFINED_COLOR);
	static cv::Mat DrawRotatedRectangles(cv::Mat matInput, std::vector<cv::RotatedRect> rects, int thickness = 1, cv::Scalar color = UNDEFINED_COLOR);

	static cv::Mat PutText(cv::Mat img, cv::Point p, cv::Scalar color, const char* fmt, ...);
	static cv::Mat PutText(cv::Mat img, cv::Point p, cv::Scalar color, float fontScale, const char* fmt, ...);

	
	static cv::Mat DrawRectMask(cv::Mat matInput, cv::Rect rect, float alpha);
	
	static cv::Mat DrawCircle(cv::Mat matInput, TGMTshape::Circle circle, cv::Scalar color = UNDEFINED_COLOR, int thickness = -1);
	static cv::Mat DrawCircles(cv::Mat matInput, std::vector<TGMTshape::Circle> circles, cv::Scalar color = UNDEFINED_COLOR, int thickness = -1);
};

