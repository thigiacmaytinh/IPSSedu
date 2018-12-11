#pragma once
#include "stdafx.h"


#define GetTGMTcar TGMTcar::GetInstance
#define INI_APPNAME_SECTION "IPSS car"
#define MIN_PLATE_W 50
#define MAX_PLATE_W 500

class CarPlateCpp
{
	
public:
	std::string text;
	std::string error;
	bool isValid;
	bool hasPlate;
	long elapsedMilisecond;
	cv::Mat image;

	CarPlateCpp()
	{
		text = "";
		error = "";
		isValid = false;
		hasPlate = false;
		elapsedMilisecond = 0;
		image = cv::Mat();
	}
	void Clear()
	{
		text = "";
		error = "";
		isValid = false;
		elapsedMilisecond = 0;
		image = cv::Mat();
	}
};

class TGMTcar
{
	static TGMTcar* m_instance;
	bool m_debug;

	int loDiff = 30;
	int upDiff = 30;
	
	cv::Mat PreprocessChar(cv::Mat in);
	std::string ReadTextFromPlate(cv::Mat matPlate);
	cv::Mat GetFeatures(cv::Mat input, int size);
	cv::Mat GetVisualHistogram(cv::Mat hist, int type);
	void DrawVisualFeatures(cv::Mat character, cv::Mat hhist, cv::Mat vhist, cv::Mat lowData);
	cv::Mat ProjectedHistogram(cv::Mat img, int t);

	bool IsValidPlateSize(cv::RotatedRect rect);
	bool IsValidCharSize(cv::Mat r);

	cv::Mat DetectPlate(cv::Mat matInput);
public:
	

	static TGMTcar* GetInstance()
	{
		if (!m_instance)
			m_instance = new TGMTcar();
		return m_instance;
	}
	TGMTcar();
	~TGMTcar();

	
	CarPlateCpp ReadPlate(std::string filePath);
	CarPlateCpp ReadPlate(cv::Mat matInput);
};