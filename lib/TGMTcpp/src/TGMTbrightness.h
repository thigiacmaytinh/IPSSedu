#pragma once
#include "stdafx.h"

class TGMTbrightness
{
public:
	//get brightness value of mat, unit is percent
	static int GetLuminance(cv::Mat matInput);

	static cv::Mat EqualizeHist(cv::Mat matInput);
	static cv::Mat AutoLuminance(cv::Mat matInput);
	static cv::Mat SetBrightness(cv::Mat matInput, double alpha, int beta);
	static cv::Mat AutoContrast(cv::Mat matInput);
};

