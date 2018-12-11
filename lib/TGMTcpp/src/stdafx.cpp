#include "stdafx.h"
#ifdef WIN32
#include <windows.h>
#include <time.h>
#endif

#ifndef _MANAGED
#include <future>
#endif
#ifdef OS_LINUX
#include <stdarg.h>
#endif

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void OnEvent(int event, int x, int y, int flags, void* userdata)
{
	switch (event)
	{
	case cv::EVENT_MOUSEMOVE:
		break;
	case cv::EVENT_LBUTTONDOWN:
		//print coordinate
		std::cout << "Left mouse click [" << x << ";" << y << "]\n";
		break;
	case cv::EVENT_RBUTTONDOWN:
		break;
	case cv::EVENT_MBUTTONDOWN:
		break;
	case cv::EVENT_LBUTTONUP:
		break;
	case cv::EVENT_RBUTTONUP:
		break;
	case cv::EVENT_MBUTTONUP:
		break;
	case cv::EVENT_LBUTTONDBLCLK:
		break;
	case cv::EVENT_RBUTTONDBLCLK:
		break;
	case cv::EVENT_MBUTTONDBLCLK:
		break; 
	default:
		break;
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

#ifdef _MANAGED
void ShowImage(cv::Mat img, std::string str)
#else
void ShowImage(cv::Mat img, const char* fmt, ...)
#endif
{
#ifndef _MANAGED
	va_list arg_list;
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
#endif
	cv::namedWindow(str);

	cv::setMouseCallback(str, OnEvent, NULL);
	cv::imshow(str, img);

}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef _MANAGED
void WriteImageAsync(cv::Mat img, const char* fmt, ...)
{
	va_list arg_list;
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
	std::future<void> result = std::async([](char* chr, cv::Mat mat) {cv::imwrite(chr, mat); }, str, img);	
}
#endif

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void WriteImage(cv::Mat img, const char* fmt, ...)
{
	va_list arg_list;
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
	cv::imwrite(str, img);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void PrintFPS(cv::Mat& img)
{
#ifdef _MANAGED

#else
	static time_t lastTime = clock() - 1;
	time_t delta = clock() - lastTime;
	time_t fps = 1000 / (delta == 0 ? 1 : delta);
	char str[10];
	sprintf(str, "FPS: %lld", fps);
	cv::putText(img, str, cv::Point(10, 30), cv::FONT_ITALIC, 1, cv::Scalar(0, 0, 255), 1);

	lastTime = clock();
#endif
}