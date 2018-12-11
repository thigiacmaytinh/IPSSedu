#pragma once
#include <iostream>

#include <opencv2/opencv.hpp>

#define DEBUG_OUT_BUFFER_SIZE			(64*1024)

#if _DEBUG
#define DEBUG_INFO(FORMAT,...) \
	    { \
        char debugString[200]; \
        sprintf_s(debugString,FORMAT, __VA_ARGS__); \
        OutputDebugStringA(debugString); \
	    }
#else
#define DEBUG_INFO(FORMAT, ...)
#endif

#if defined(WIN32) || defined(WIN64)
#ifdef _MANAGED
	void DebugImage(cv::Mat img, std::string str);
	#define DEBUG_IMAGE(img, ...)

	void WriteImage(cv::Mat img, std::string str);
	#define WRITE_IMAGE(img, str) WriteImage(img, str)
#else
	void ShowImage(cv::Mat img, const char* fmt, ...);
	#if defined(_DEBUG)		
		#define DEBUG_IMAGE(img, ...) ShowImage(img, __VA_ARGS__)		
	#else
		#define DEBUG_IMAGE(img, ...)
	#endif
	void WriteImage(cv::Mat img, const char* fmt, ...);
	void WriteImageAsync(cv::Mat img, const char* fmt, ...);
	#define WRITE_IMAGE(img, ...) WriteImage(img, __VA_ARGS__)
	#define WRITE_IMAGE_ASYNC(img, ...) WriteImageAsync(img, __VA_ARGS__)
#endif
#else
	#define WRITE_IMAGE(img, ...)
	#define DEBUG_IMAGE(img, ...)
#endif
void PrintFPS(cv::Mat& img);
#define PRINT_FPS PrintFPS

#if CV_MAJOR_VERSION == 3
#define CV_ADAPTIVE_THRESH_GAUSSIAN_C cv::ADAPTIVE_THRESH_GAUSSIAN_C
#define CV_CHAIN_APPROX_NONE cv::CHAIN_APPROX_NONE
#define CV_CHAIN_APPROX_SIMPLE cv::CHAIN_APPROX_SIMPLE
#define CV_DIST_L2 cv::DIST_L2
#define CV_LOAD_IMAGE_GRAYSCALE cv::IMREAD_GRAYSCALE
#define CV_RETR_EXTERNAL cv::RETR_EXTERNAL
#define CV_RETR_LIST cv::RETR_LIST
#define CV_THRESH_BINARY cv::THRESH_BINARY
#define CV_THRESH_BINARY_INV cv::THRESH_BINARY_INV
#define CV_BGR2GRAY cv::COLOR_BGR2GRAY
#define CV_BGR2HSV cv::COLOR_BGR2HSV
#else
#endif

#ifdef _MSC_FULL_VER
	#if   _MSC_FULL_VER == 170060315 // MSVS 2012; Platform Toolset v110
	
	#elif _MSC_FULL_VER == 170051025 // MSVS 2012; Platform Toolset v120_CTP_Nov2012
	
	#elif _MSC_FULL_VER == 180020617 // MSVS 2013; Platform Toolset v120
	
	#elif _MSC_FULL_VER == 190024210 // MSVS 2015; Platform Toolset v140	

	#endif
#endif


#define BLACK cv::Scalar(0,0,0)
#define BLUE cv::Scalar(255,0,0)
#define CYAN cv::Scalar(255,255,0)
#define GREY cv::Scalar(128,128,128)
#define GREEN cv::Scalar(0,255,0)
#define ORANGE cv::Scalar(0,165,255)
#define PINK cv::Scalar(147,20,255)
#define PURPLE cv::Scalar(255,0,255)
#define RED cv::Scalar(0,0,255)
#define WHITE cv::Scalar(255,255,255)
#define YELLOW cv::Scalar(0,255,255)
#define UNDEFINED_COLOR cv::Scalar(-1,-1,-1)

#define MAX_PATH    260