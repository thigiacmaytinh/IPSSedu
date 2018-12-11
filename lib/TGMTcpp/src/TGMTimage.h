#pragma once
#include "stdafx.h"

//----------------------------------------
// TGMT mean: ThiGiacMayTinh
//----------------------------------------
class TGMTimage
{
public:
	//TGMTimage(void);
	//~TGMTimage(void);
	static cv::Mat ConvertToGray(cv::Mat matInput);

	static std::string GetImageType(cv::Mat);
	static bool Compare(cv::Mat mat1, cv::Mat mat2);

	//return percent of Blurriness
	//lower is more blurry
	static int CalcBlurriness(const cv::Mat src);

	static int GetBitDepth(cv::Mat);
	static cv::Mat Blend(cv::Mat mat1, cv::Mat mat2, float alpha);
	
};

