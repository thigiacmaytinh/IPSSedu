#include "TGMTcolor.h"
#include "TGMTdebugger.h"
#include "TGMTutil.h"

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTcolor::GetColorName(cv::Mat imgInput, cv::Point p)
{
	if (!imgInput.data)
		return "Error";

	cv::Mat imgHSV;
	cv::cvtColor(imgInput, imgHSV, CV_BGR2HSV);

	cv::Vec3b pixel = imgHSV.at<cv::Vec3b>(p);
	

#if DEBUG	
	int h = pixel[0];
	float s = pixel[1];
	float v = pixel[2];
	std::cout << h * 2 << " - " << s / 255.f << " - " << v / 255.f << "\n";
#endif
	
	cv::Scalar color = GetColorCorresponding(pixel);
	if (color == BLACK)
		return "Black";
	else if (color == BLUE)
		return "Blue";
	else if (color == CYAN)
		return "Cyan";
	else if (color == GREY)
		return "Grey";
	else if (color == GREEN)
		return "Green";
	else if (color == ORANGE)
		return "Orange";
	else if (color == PINK)
		return "Pink";
	else if (color == PURPLE)
		return "Purple";
	else if (color == RED)
		return "Red";
	else if (color == WHITE)
		return "White";
	else if (color == YELLOW)
		return "Yellow";
	else 
		return "unknown";
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTcolor::GetColorName(cv::Mat imgInput, int x, int y)
{
	return GetColorName(imgInput, cv::Point(x, y));
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Scalar TGMTcolor::GetColorCorresponding(int H, int S, int V)
{
	if (V < 75)
		return BLACK;
	else if (V > 190 && S < 27)
		return WHITE;
	else if (S < 53 && V < 185)
		return GREY;
	else
	{	// Is a color
		if (H < 14)
			return RED;
		else if (H < 25)
			return ORANGE;
		else if (H < 34)
			return YELLOW;
		else if (H < 73)
			return GREEN;
		else if (H < 102)
			return CYAN;
		else if (H < 127)
			return BLUE;
		else if (H < 149)
			return PURPLE;
		else if (H < 175)
			return PINK;
		else	// full circle 
			return RED;	// back to Red
	}

}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Scalar TGMTcolor::GetColorCorresponding(cv::Vec3b pixel)
{
	uchar H = pixel[0];  	// Hue
	uchar S = pixel[1];		// Saturation
	uchar V = pixel[2]; 	// Value (Brightness)
	return GetColorCorresponding(H, S, V);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Scalar TGMTcolor::GetPixelValue(cv::Mat matInput, cv::Point p)
{
	cv::Vec3b pixel = matInput.at<cv::Vec3b>(p.x, p.y);

	PrintMessage("(%d, %d, %d)", pixel[0], pixel[1], pixel[2]);

	return cv::Scalar(pixel);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Scalar TGMTcolor::GetRandomColor()
{
	int R = TGMTutil::GetRandomInt();	
	int G = TGMTutil::GetRandomInt();
	int B = TGMTutil::GetRandomInt();
	return cv::Scalar(B, G, R);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTcolor::FilterColor(cv::Mat matInput, uchar minH, uchar maxH, uchar minS, uchar maxS, uchar minV, uchar maxV, bool isHSV)
{
	cv::Scalar lower = cv::Scalar(minH, minS, minV);
	cv::Scalar higher = cv::Scalar(maxH, maxS, maxV);
	return FilterColor(matInput, lower, higher, isHSV);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTcolor::FilterColor(cv::Mat matInput, cv::Scalar lower, cv::Scalar higher, bool isHSV )
{
	cv::Mat matHsv;
	if (!isHSV)
		cv::cvtColor(matInput, matHsv, CV_BGR2HSV);
	else
		matHsv = matInput;

	cv::Mat mask, matResult;
	cv::inRange(matHsv, lower, higher, mask);

	matInput.copyTo(matResult, mask);
	return matResult;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTcolor::GetMostColorName(cv::Mat matInput, float& confidence)
{
	std::vector<std::string> ColorNames = { "Black", "White", "Grey", "Red", "Orange", "Yellow", "Green", "Aqua", "Blue", "Purple", "Pink" };

	cv::Mat imageHSV;
	cv::cvtColor(matInput, imageHSV, CV_BGR2HSV);	// (note that OpenCV stores RGB images in B,G,R order.
	ASSERT(imageHSV.data, "ERROR: Couldn't convert Shirt image from BGR2HSV.")

		
	int h = imageHSV.rows;				// Pixel height
	int w = imageHSV.cols;				// Pixel width
	int rowSize = imageHSV.step;		// Size of row in bytes, including extra padding

											
	// Create an empty tally of pixel counts for each color type
	int tallyColors[11];
	for (int i = 0; i < 11; i++)
	{
		tallyColors[i] = 0;
	}

	// Scan the shirt image to find the tally of pixel colors
	for (int y = 0; y < h; y++)
	{
		for (int x = 0; x < w; x++)
		{
			cv::Vec3b pixel = imageHSV.at<cv::Vec3b>(y, x);

			// Determine what type of color the HSV pixel is.
			Color ctype = GetPixelColorType(pixel);
			// Keep count of these colors.
			tallyColors[ctype]++;
		}
	}

	// Print a report about color types, and find the max tally
	int tallyMaxIndex = 0;
	int tallyMaxCount = -1;
	int pixels = w * h;
	for (int i = 0; i < 11; i++)
	{
		int v = tallyColors[i];
		if (v > tallyMaxCount)
		{
			tallyMaxCount = v;
			tallyMaxIndex = i;
		}
	}

	confidence = (float)tallyMaxCount * 100 / pixels;
	std::string color = ColorNames[tallyMaxIndex].c_str();
	PrintMessage("Detected color: %s with %d percent", color.c_str(), (int)confidence);

	return color;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

TGMTcolor::Color TGMTcolor::GetPixelColorType(int H, int S, int V)
{
	Color color;
	if (V < 75)
		color = C_BLACK;
	else if (V > 190 && S < 27)
		color = C_WHITE;
	else if (S < 53 && V < 185)
		color = C_GREY;
	else
	{	// Is a color
		if (H < 14)
			color = C_RED;
		else if (H < 25)
			color = C_ORANGE;
		else if (H < 34)
			color = C_YELLOW;
		else if (H < 73)
			color = C_GREEN;
		else if (H < 102)
			color = C_AQUA;
		else if (H < 127)
			color = C_BLUE;
		else if (H < 149)
			color = C_PURPLE;
		else if (H < 175)
			color = C_PINK;
		else	// full circle 
			color = C_RED;	// back to Red
	}
	return color;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


TGMTcolor::Color TGMTcolor::GetPixelColorType(cv::Vec3b pixel)
{
	uchar H = pixel[0];  	// Hue
	uchar S = pixel[1];		// Saturation
	uchar V = pixel[2]; 	// Value (Brightness)
	return GetPixelColorType(H, S, V);
}