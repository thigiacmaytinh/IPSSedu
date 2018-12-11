#include "TGMTdraw.h"
#ifdef WIN32
#include <Windows.h>
#endif
#include "TGMTcolor.h"

//TGMTdraw::TGMTdraw()
//{
//}
//
//
//TGMTdraw::~TGMTdraw()
//{
//}



void TGMTdraw::DrawLine(cv::Mat matInput, cv::Point pt1, cv::Point pt2, cv::Scalar color)
{
	DrawLine(matInput, pt1, pt2, color, 1);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTdraw::DrawLine(cv::Mat matInput, cv::Point pt1, cv::Point pt2, cv::Scalar color, int thickness)
{
	DrawLine(matInput,pt1, pt2, color, thickness, 8);
}


/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTdraw::DrawLine(cv::Mat matInput, cv::Point pt1, cv::Point pt2, cv::Scalar color, int thickness, int lineType)
{
	DrawLine(matInput,pt1, pt2, color, thickness, lineType, 0);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTdraw::DrawLine(cv::Mat matInput, cv::Point pt1, cv::Point pt2, cv::Scalar color, int thickness, int lineType, int shift)
{
	cv::line(matInput, pt1, pt2, color, thickness, lineType, shift);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTdraw::DrawLine(cv::Mat img, cv::Vec2f line, cv::Scalar color)
{
	if (!img.data)
		return;


	if (line[1] != 0)
	{
		float m = -1 / tan(line[1]);
		float c = line[0] / sin(line[1]);
		cv::line(img, cv::Point(0, c), cv::Point(img.size().width, m*img.size().width + c), color);
	}
	else
	{
		cv::line(img, cv::Point(line[0], 0), cv::Point(line[0], img.size().height), color);
	}


}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTdraw::DrawLine(cv::Mat img, cv::Vec4i line, cv::Scalar color)
{
	if (!img.data)
		return;

	cv::line(img, cv::Point(line[0], line[1]), cv::Point(line[2], line[3]), color, 1, CV_AA);

}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTdraw::DrawLines(cv::Mat img, std::vector<cv::Vec2f> lines, cv::Scalar color)
{
	if (!img.data)
		return;


	//TODO: rewrite function
	for (int i = 0; i < lines.size(); ++i)
	{
		cv::Vec2f line = lines[i];
		if (line[1] != 0)
		{
			float m = -1 / tan(line[1]);
			float c = line[0] / sin(line[1]);
			cv::line(img, cv::Point(0, c), cv::Point(img.size().width, m*img.size().width + c), color);
		}
		else
		{
			cv::line(img, cv::Point(line[0], 0), cv::Point(line[0], img.size().height), color);
		}
	}

}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTdraw::DrawLines(cv::Mat img, std::vector<cv::Vec4i> lines, cv::Scalar color)
{
	if (!img.data)
		return;

	for (int i = 0; i < lines.size(); i++)
	{
		DrawLine(img, lines[i], color);
	}
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTdraw::DrawLine(cv::Mat imgInput, int rhoValue, int thetaValue)
{
	cv::Vec2f line = cv::Vec2f(rhoValue, thetaValue);
	DrawLine(imgInput, line);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::DrawRectangle(const cv::Mat matInput, cv::Rect rect, cv::Scalar color)
{
	return DrawRectangle( matInput, rect, color, 1);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::DrawRectangle(const cv::Mat matInput, cv::Rect rect, cv::Scalar color, int thickness)
{
	return DrawRectangle(matInput, rect, color, thickness, 8, 0);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::DrawRectangle(const cv::Mat matInput, cv::Rect rect, cv::Scalar color, int thickness, int lineType)
{
	return DrawRectangle(matInput, rect, color, thickness, lineType, 0);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::DrawRectangle(const cv::Mat matInput, cv::Rect rect, cv::Scalar color, int thickness, int lineType, int shift)
{
	cv::Mat matDraw = matInput.clone();
	cv::rectangle(matDraw, rect.tl(), rect.br(), color, thickness, lineType, shift);
	return matDraw;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTdraw::DrawRectangles(cv::Mat& matInput, std::vector<cv::Rect> rects, int thickness, cv::Scalar color)
{
	for (int i = 0; i < rects.size(); i++)
	{
		if (color == UNDEFINED_COLOR)
			DrawRectangle(matInput, rects[i],  TGMTcolor::GetRandomColor(), thickness);
		else
			DrawRectangle(matInput, rects[i], color, thickness);
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::PutText(cv::Mat img, cv::Point p, cv::Scalar color, const char* fmt, ...)
{
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_list arg_list;
#ifndef _ARM_
	va_start(arg_list, fmt);
#else
	__crt_va_start_a(arg_list, fmt);
#endif
	
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);


	return PutText(img, p, color, 1.f, str);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::PutText(cv::Mat img, cv::Point p, cv::Scalar color, float fontScale, const char* fmt, ...)
{
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_list arg_list;
#ifndef _ARM_
	va_start(arg_list, fmt);
#else
	__crt_va_start_a(arg_list, fmt);
#endif
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);

	return PutText(img, p, color, fontScale, str);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::PutText(cv::Mat mat, cv::Point p, cv::Scalar color, float fontScale, char* text)
{
	if (text == nullptr || text == "")
		return mat;
	cv::Mat matDraw = mat.clone();

	cv::putText(matDraw, text, p, cv::FONT_ITALIC, fontScale, color, 2);
	return matDraw;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::DrawRotatedRectangle(cv::Mat matInput, cv::RotatedRect rect, int thickness, cv::Scalar color)
{
	cv::Mat matDraw = matInput.clone();
	if (matDraw.channels() == 1)
		cv::cvtColor(matDraw, matDraw, CV_GRAY2BGR);
	cv::Point2f rectPoints[4]; 
	rect.points(rectPoints);

	cv::Scalar clr;
	if (color == UNDEFINED_COLOR)
		clr = TGMTcolor::GetRandomColor();
	for (int j = 0; j < 4; j++)
	{
		line(matDraw, rectPoints[j], rectPoints[(j + 1) % 4], clr, thickness, 8);
	}
	return matDraw;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::DrawRotatedRectangles(cv::Mat matInput, std::vector<cv::RotatedRect> rects, int thickness, cv::Scalar color)
{
	cv::Mat matDraw = matInput.clone();
	if (matDraw.channels() == 1)
		cv::cvtColor(matDraw, matDraw, CV_GRAY2BGR);

	for (int i = 0; i < rects.size(); i++)
	{
		cv::Point2f rectPoints[4];
		rects[i].points(rectPoints);

		cv::Scalar clr;
		if(color == UNDEFINED_COLOR)
			clr = TGMTcolor::GetRandomColor();
		for (int j = 0; j < 4; j++)
		{
			cv::line(matDraw, rectPoints[j], rectPoints[(j + 1) % 4], clr, thickness, 8);
		}
	}
	return matDraw;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::DrawRectMask(cv::Mat matInput, cv::Rect rect, float alpha)
{
	cv::Mat mask(matInput.size(), CV_8UC3, BLACK);
	cv::rectangle(mask, rect, WHITE, -1);

	cv::Mat matRoi;
	cv::bitwise_and(matInput, mask, matRoi);


	cv::Mat matBlur(matInput.size(), CV_8UC3);
	cv::addWeighted(matInput, 1 - alpha, cv::Scalar(50, 50, 50), alpha, 0.0, matBlur);
	cv::addWeighted(matRoi, 1, matBlur, 1, 0.0, matRoi);

	return matRoi;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::DrawCircle(cv::Mat matInput, TGMTshape::Circle circle, cv::Scalar color, int thickness)
{
	cv::Mat mat = matInput.clone();
	cv::circle(mat, circle.center, circle.radius,color, thickness, 8, 0);
	return mat;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTdraw::DrawCircles(cv::Mat matInput, std::vector<TGMTshape::Circle> circles, cv::Scalar color, int thickness)
{
	cv::Mat matDraw = matInput.clone();
	for (size_t i = 0; i < circles.size(); i++)
	{
		cv::circle(matDraw, circles[i].center, circles[i].radius, color == UNDEFINED_COLOR ? TGMTcolor::GetRandomColor() : color, thickness, 8, 0);
	}
	return matDraw;
}