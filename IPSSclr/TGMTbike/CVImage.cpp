/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#include "stdafx.h"

#include "CVUtils.h"
#include "CVException.h"
#include "CVRgbPixel.h"
#include "CVImage.h"
#include "CVCapture.h"
#include "CVWindow.h"
#include "CVVideoWriter.h"
#include "CVArr.h"
#include "CVHistogram.h"

#include "ObjDetect.h"

#include "Image.h"
#include "Image.cpp"

using namespace System::Drawing;
using namespace System::Drawing::Imaging;
using namespace System::IO;

namespace OpenCVDotNet
{
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////

	Bitmap^ CVImage::MatToBitmap(cv::Mat img)
	{
		if (img.data == nullptr)
			return nullptr;
		if (img.type() != CV_8UC3)
		{
			throw gcnew NotSupportedException("Only images of type CV_8UC3 are supported for conversion to Bitmap");
		}

		//create the bitmap and get the pointer to the data
		Bitmap ^bmpimg = gcnew Bitmap(img.cols, img.rows, PixelFormat::Format24bppRgb);

		BitmapData ^data = bmpimg->LockBits(System::Drawing::Rectangle(0, 0, img.cols, img.rows), ImageLockMode::WriteOnly, PixelFormat::Format24bppRgb);

		byte *dstData = reinterpret_cast<byte*>(data->Scan0.ToPointer());

		unsigned char *srcData = img.data;

		for (int row = 0; row < data->Height; ++row)
		{
			memcpy(reinterpret_cast<void*>(&dstData[row*data->Stride]), reinterpret_cast<void*>(&srcData[row*img.step]), img.cols*img.channels());
		}

		bmpimg->UnlockBits(data);
		delete(data);
		img.release();
		return bmpimg;
	}
	

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////

	Bitmap^ CVImage::DetectPlate(bool crop)
	{
		cv::Mat result = ObjDetect::GetInstance()->DetectPlate(image, crop);
		return MatToBitmap(result);
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////

	System::String^ CVImage::DetectChar()
	{
		std::string str = ObjDetect::GetInstance()->DetectChar(image);
		if(str == "")
			return "";
		return CVUtils::stdStrToSystemStr(str);
	}
}