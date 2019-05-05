#pragma once
#include "stdafx.h"

//----------------------------------------
// TGMT mean: ThiGiacMayTinh
//----------------------------------------
class TGMTcolor
{
	enum  Color { C_BLACK = 0, C_WHITE, C_GREY, C_RED, C_ORANGE, C_YELLOW, C_GREEN, C_AQUA, C_BLUE, C_PURPLE, C_PINK, NUM_COLOR_TYPES };
	static Color GetPixelColorType(int H, int S, int V);
	static Color GetPixelColorType(cv::Vec3b pixel);
public:

	static std::string GetColorName(cv::Mat, cv::Point);
	static std::string GetColorName(cv::Mat, int x, int y);	

	static cv::Scalar GetColorCorresponding(int H, int S, int V);
	static cv::Scalar GetColorCorresponding(cv::Vec3b pixel);

	static cv::Scalar GetPixelValue(cv::Mat matInput, cv::Point p);
	static cv::Scalar GetRandomColor();

	static cv::Mat FilterColor(cv::Mat matInput, uchar minH, uchar maxH, uchar minS, uchar maxS, uchar minV, uchar maxV, bool isHSV = false);
	static cv::Mat FilterColor(cv::Mat matInput, cv::Scalar lower, cv::Scalar higher, bool isHSV = false);
	static std::string GetMostColorName(cv::Mat matInput, float& initialConfidence);
};

