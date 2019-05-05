#pragma once
#include "stdafx.h"

class TGMTtransform
{
public:
	//TGMTtransform();
	//~TGMTtransform();

	static void WarpPerspective(cv::Mat matInput, cv::Mat& matOutput, cv::Point2f inputQuad[4], cv::Point2f outputQuad[4] =nullptr);


	//rotate image around point, default rotate around center point
	static cv::Mat Rotate(cv::Mat matInput, int angle, cv::Point point = cv::Point(-1,-1), bool avoidEnlarge = false);
	static cv::Mat Rotate(cv::Mat matInput, float radial, cv::Point point = cv::Point(-1, -1), bool avoidEnlarge = false);

	
	static cv::Mat CanvasSize(cv::Mat matInput, cv::Size size);
	//height auto scale by width
	static cv::Mat ResizeByWidth(cv::Mat matInput, int width);
	//width auto scale by height
	static cv::Mat ResizeByHeight(cv::Mat matInput, int height);

	static cv::Mat CropImage(cv::Mat matInput, cv::Rect rect);
	static std::vector<cv::Mat> CropImages(cv::Mat matInput, std::vector<cv::Rect> rects);
	static cv::Mat Deskew(cv::Mat& img);
};

