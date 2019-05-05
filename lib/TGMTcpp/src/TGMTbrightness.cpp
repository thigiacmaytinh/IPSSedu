#include "TGMTbrightness.h"
#include "TGMTdebugger.h"
#include "TGMTimage.h"

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int TGMTbrightness::GetLuminance(cv::Mat matInput)
{
	cv::Mat temp, color[3], lum;
	temp = matInput;

	cv::split(temp, color);

	color[0] = color[0] * 0.299;
	color[1] = color[1] * 0.587;
	color[2] = color[2] * 0.114;


	lum = color[0] + color[1] + color[2];

	cv::Scalar summ = sum(lum);


	double brightness = summ[0] / ((pow(2, 8) - 1)*matInput.rows * matInput.cols) * 2; //-- percentage conversion factor
	return brightness * 100;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTbrightness::EqualizeHist(cv::Mat matInput)
{
	if (matInput.channels() == 1)
	{
		// Can bang histogram anh xam
		cv::Mat matResult;
		cv::equalizeHist(matInput, matResult);
		return matResult;
	}
	else if (matInput.channels() == 3)
	{
		// Can bang histogram anh mau

		cv::Mat hsv, matResult;
		cv::cvtColor(matInput, hsv, CV_BGR2HSV);
		std::vector<cv::Mat> hsv_channels;
		// Tach hsv thanh 3 kenh mau
		cv::split(hsv, hsv_channels);
		// Can bang histogram kenh mau v (value)
		cv::equalizeHist(hsv_channels[2], hsv_channels[2]);
		// Tron anh
		cv::merge(hsv_channels, hsv);
		// Chuyen doi hsv sang rgb de hien thi
		cv::cvtColor(hsv, matResult, CV_HSV2BGR);

		return matResult;
	}
	else
	{
		ASSERT(false, "Only support image has 1 or 3 channels");
	}
	
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTbrightness::AutoLuminance(cv::Mat matInput)
{
	cv::Mat matResult;
	int maxValue = pow(2, TGMTimage::GetBitDepth(matInput)) - 1;
	cv::normalize(matInput, matResult, 0, maxValue, cv::NORM_MINMAX);
	return matResult;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTbrightness::SetBrightness(cv::Mat matInput, double alpha, int beta)
{
	cv::Mat matResult = matInput.clone();
	for (uint i = 0; i < matResult.rows; i++)
	{
		for (uint j = 0; j < matResult.cols; j++)
		{
			for (uint k = 0; k < 3; k++)
			{
				matResult.at<cv::Vec3b>(i, j)[k] = cv::saturate_cast<uchar>(alpha*(matResult.at<cv::Vec3b>(i, j)[k]) + beta);
			}				
		}			
	}
	return matResult;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTbrightness::AutoContrast(cv::Mat matInput)
{
	cv::Mat matOutput;
	cv::GaussianBlur(matInput, matOutput, cv::Size(11, 11), 0);
	cv::addWeighted(matInput, 1.5, matOutput, -0.5, 1, matOutput);
	return matOutput;
}