#include "TGMTtransform.h"
#include "TGMTdebugger.h"

//TGMTtransform::TGMTtransform()
//{
//}
//
//
//TGMTtransform::~TGMTtransform()
//{
//}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTtransform::WarpPerspective(cv::Mat matInput, cv::Mat& matOutput, cv::Point2f inputQuad[4], cv::Point2f outputQuad[4])
{
	ASSERT(matInput.data, "Mat input is null");
	// Set the lambda matrix the same type and size as input
	
	if (outputQuad == nullptr)
	{
		outputQuad = new cv::Point2f[4];
		outputQuad[0] = cv::Point2f(0,0);
		outputQuad[1] = cv::Point2f(matOutput.cols - 1, 0);
		outputQuad[2] = cv::Point2f(matOutput.cols - 1, matOutput.rows - 1);
		outputQuad[3] = cv::Point2f(0, matOutput.rows - 1);
	}
	// Get the Perspective Transform Matrix i.e. lambda
	cv::Mat lambda = cv::Mat::zeros(matInput.rows, matInput.cols, matInput.type());
	lambda = getPerspectiveTransform(inputQuad, outputQuad);
	// Apply the Perspective Transform just found to the src image
	warpPerspective(matInput, matOutput, lambda, matOutput.size());
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTtransform::Rotate(cv::Mat matInput, int angle, cv::Point point, bool avoidEnlarge)
{	
	ASSERT(matInput.data, "Mat input is null");
	if (angle == 0)
		return matInput;

	cv::Mat matRotate = matInput.clone();

	cv::Size originalSize = matRotate.size();
	{
		// get rotation matrix for rotating the image around its center
		if (point == cv::Point(-1, -1))
			point = cv::Point(matRotate.cols / 2.0, matRotate.rows / 2.0);

		cv::Mat rot = cv::getRotationMatrix2D(point, angle, 1.0);
		// determine bounding rectangle
		cv::Rect bbox = cv::RotatedRect(point, matRotate.size(), angle).boundingRect();
		// adjust transformation matrix
		rot.at<double>(0, 2) += bbox.width / 2.0 - point.x;
		rot.at<double>(1, 2) += bbox.height / 2.0 - point.y;

		cv::warpAffine(matRotate, matRotate, rot, bbox.size());
	}

	if (avoidEnlarge)
	{
		int dWidth = abs(originalSize.width - matRotate.cols);
		int dHeight = abs(originalSize.height - matRotate.rows);
		cv::Rect rect(dWidth/2, dHeight/2, originalSize.width, originalSize.height);
		matRotate = matRotate(rect);
	}
		

	return matRotate;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTtransform::Rotate(cv::Mat matInput, float radial, cv::Point point, bool avoidEnlarge)
{
	int angle = 57.295779513 * radial;
	return Rotate(matInput, angle, point, avoidEnlarge);
}


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTtransform::CanvasSize(cv::Mat matInput, cv::Size size)
{
	if (size.width < matInput.cols && size.height < matInput.rows)
	{
		//reduce image size
		return CropImage(matInput, cv::Rect(0, 0, size.width, size.height));
	}
	else
	{
		//enlarge image
		cv::Mat matDst = cv::Mat::zeros(size, matInput.type());
		matInput.copyTo(matDst(cv::Rect(0,0, matInput.cols, matInput.rows)));
		return matDst;
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTtransform::CropImage(cv::Mat matInput, cv::Rect rect)
{
	ASSERT(rect.width < matInput.cols && rect.height < matInput.rows, "size to crop must less than mat size");
	return matInput(rect);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<cv::Mat> TGMTtransform::CropImages(cv::Mat matInput, std::vector<cv::Rect> rects)
{
	std::vector<cv::Mat> results;
	for (int i = 0; i < rects.size(); i++)
	{
		results.push_back(CropImage(matInput, rects[i]));
	}
	return results;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTtransform::ResizeByWidth(cv::Mat matInput, int width)
{
	cv::Mat matResult;
	float scaleHeight = matInput.rows * width / matInput.cols;
	cv::resize(matInput, matResult, cv::Size(width, scaleHeight));
	return matResult;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTtransform::ResizeByHeight(cv::Mat matInput, int height)
{
	cv::Mat matResult;
	float scaleWidth = matInput.cols * height / matInput.rows;
	cv::resize(matInput, matResult, cv::Size(scaleWidth, height));
	return matResult;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

cv::Mat TGMTtransform::Deskew(cv::Mat& img)
{
	int SZ = 20;
	int affineFlags = cv::WARP_INVERSE_MAP | cv::INTER_LINEAR;
	cv::Moments m = moments(img);
	if (std::abs(m.mu02) < 1e-2)
	{
		// No deskewing needed. 
		return img.clone();
	}
	// Calculate skew based on central momemts. 
	double skew = m.mu11 / m.mu02;
	// Calculate affine transform to correct skewness. 
	cv::Mat warpMat = (cv::Mat_<double>(2, 3) << 1, skew, -0.5*SZ*skew, 0, 1, 0);

	cv::Mat imgOut = cv::Mat::zeros(img.rows, img.cols, img.type());
	warpAffine(img, imgOut, warpMat, imgOut.size(), affineFlags);

	return imgOut;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
