#pragma once
#include "opencv2/objdetect/objdetect.hpp"
#include "opencv2/highgui/highgui.hpp"
#include "opencv2/imgproc/imgproc.hpp"

class ObjDetect
{
	

	static ObjDetect* instance;

	cv::CascadeClassifier plate_cascade;
	cv::CascadeClassifier char_cascade;

	bool isInited;
public:

	enum Type
	{		
		chars = 0,
		crab
	};

	ObjDetect();
	//ObjDetect(cv::String pathToCascade);
	~ObjDetect();

	static ObjDetect* GetInstance()
	{
		if(!instance)
			instance = new ObjDetect();
		return instance;
	}
	static char* ObjDetect::readm_line(FILE *input);
	void Init();	
	void WriteSVM( cv::Mat charGray);


	bool IsInited();

	std::vector<cv::Mat> Detect(cv::Mat frame, Type, bool crop);

	cv::Mat DetectPlate( cv::Mat frame, bool crop );
	cv::Mat DetectPlate( std::string imgPath, bool crop );

	std::string DetectChar(cv::Mat plateCropped);	

};