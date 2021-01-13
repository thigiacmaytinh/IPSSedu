#include "ObjDetect.h"
//#include "Shlwapi.h"
//#include "svm.h"
#include <iostream>
#include <windows.h>
ObjDetect* ObjDetect::instance = NULL;

////////////////////////////////////////////////////////////////////////////////////////////////////////////

ObjDetect::ObjDetect(void)
{
	isInited = false;
 	Init();
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////
ObjDetect::~ObjDetect(void)
{
	//svm_free_and_destroy_model(&model_num);
	//svm_free_and_destroy_model(&model_charnum);
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////
void ObjDetect::Init()
{
	if (!plate_cascade.load("bienso.xml")){ OutputDebugStringA("--(!)Error loading plate_cascade\n"); return; };
	
	if (!char_cascade.load("kytu.xml")){ OutputDebugStringA("--(!)Error loading char_cascade\n"); return; };
	
	
	isInited = true;
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////
bool ObjDetect::IsInited()
{
	return isInited;
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////
cv::Mat ObjDetect::DetectPlate( cv::Mat frame, bool crop)
{
	cv::Mat frame_gray, frameResult;
	cvtColor(frame, frame_gray, CV_BGR2GRAY);
	equalizeHist(frame_gray, frame_gray);
	std::vector<cv::Rect> rects;
	plate_cascade.detectMultiScale(frame_gray, rects, 1.1, 2, 0, cv::Size(0, 0));

	if(rects.size() == 0)
		return frame;
	else
	{
		cv::Mat mat = frame( rects[0]);
		cv::resize(mat, mat, cv::Size((float)mat.cols * 360 / (float)mat.rows, 360));
		return mat;
	}
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////
cv::Mat ObjDetect::DetectPlate( std::string imgPath, bool crop)
{	
	cv::Mat frame = cv::imread(imgPath);

	return DetectPlate(frame, crop);
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////
std::vector<cv::Rect> SortRect(std::vector<cv::Rect> rects)
{
	for(int i = 0; i< rects.size(); ++i)
	{		
        for(int j=0; j<rects.size(); ++j)
		{
			if(rects[i].x > rects[j].x)
			{
				cv::Rect temp = rects[i];
				rects[i] = rects[j];
				rects[j] = temp;
			}
		}
	}
	return rects;
}
//use for sort chars
std::vector<cv::Rect> SortCharRect(std::vector<cv::Rect> rects)
{	
	std::vector<cv::Rect> rects1;
	std::vector<cv::Rect> rects2;

	for(int i = 0; i< rects.size(); ++i)
	{
		cv::Rect rect = rects[i];
        if( rect.y < 65 || rect.y > 165 )
		{
            if( rect.y < 170 )
			{
                rects1.push_back(rect);
			}
			else
			{
               rects2.push_back(rect);
			}
		}        
	}

	rects1 = SortRect(rects1);
	rects2 = SortRect(rects2);

	rects1.insert( rects1.end(), rects2.begin(), rects2.end() );
	return rects1;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<cv::Mat> ObjDetect::Detect(cv::Mat frame, Type type, bool crop)
{	
	if(!IsInited())
		Init();

	std::vector<cv::Rect> rects;
	std::vector<cv::Mat> result;
	cv::Mat frame_gray, frameResult;
	cvtColor( frame, frame_gray, CV_BGR2GRAY );
	equalizeHist( frame_gray, frame_gray );
	//-- Detect plate
	if(type == Type::chars)
	{
		char_cascade.detectMultiScale( frame_gray, rects, 1.1, 2, 0, cv::Size(0, 0) );
		//sort
		rects = SortCharRect(rects);

	}	
	for( size_t i = 0; i < rects.size(); i++ )
	{
		if (crop)
		{
			if(rects[i].x > 0 && rects[i].y >0)
			{
				cv::Mat temp = frame( rects[i] );
				if (type == Type::chars)
				{
					resize(temp, temp, cv::Size(20,48));
				}
				result.push_back(temp);
			}
		}
		else
		{
			cv::Point p1( rects[i].x , rects[i].y );
			cv::Point p2( rects[i].x + rects[i].width, rects[i].y +rects[i].height );		
			rectangle(frame, p1, p2, cv::Scalar( 255, 0, 255 ), 3 );
			result.push_back(frame);
		}		
	}	
	return result;
	
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string ObjDetect::DetectChar(cv::Mat plateCropped)
{	
	cv::Mat frame_gray;
	cvtColor( plateCropped, frame_gray, CV_BGR2GRAY );
	std::vector<cv::Rect> rects;
	char_cascade.detectMultiScale( frame_gray, rects, 1.1, 2, 0, cv::Size(0, 0) );

	std::string result = "";
	for(int i=0; i<rects.size(); i++)
	{
		char temp[40];
		sprintf(temp, "%d_%d_%d_%d", rects[i].x, rects[i].y, rects[i].width, rects[i].height);
		result += temp;
		result += "_";
	}

	return result.substr(0, result.length()-1);
}
