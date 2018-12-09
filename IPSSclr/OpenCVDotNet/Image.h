#pragma once
#include <iostream>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/objdetect/objdetect.hpp>

using namespace std;

class ImageCpp
{
	cv::Mat m_img;
public:
	ImageCpp(void);
	ImageCpp(string imgPath);
	ImageCpp(cv::Mat img);
	~ImageCpp(void);
	///////////////////////////////////////////////////////////////
	int ColoredDot(int dotSize);
	int Rotate(int angle);
	int FindingContour(int threshold1, int threshold2);
	int FindLineCircle();
	int FindDigitsInLicensePlate();
	int FindFace();
	int WaterShed();
	/////////////////////////////////////////////////////////////
	bool IsHaveData();
	//////////////////////////////////////////////////////////////
	void Show(string windowName);
	void Show();
	//////////////////////////////////////////////////////////////
	static void CaptureWC();
	static void SolveSudoku(cv::Mat img);
	static void SolveSudoku();	
	static cv::Mat WarpPerspective(cv::Mat mat, cv::Point2i top_left, cv::Point2i top_right, cv::Point2i bot_right, cv::Point2i bot_left);
};

