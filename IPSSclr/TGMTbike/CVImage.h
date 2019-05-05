/**
 * (C) 2007 Elad Ben-Israel and OpenCVDotNet contributors
 * This code is licenced under the GPL.
 */

#pragma once

#include "stdafx.h"


#include "CVRgbPixel.h"
#include "CVUtils.h"
#include "CVHistogram.h"
#include "CVPair.h"
#include "CVArr.h"
#include <opencv2/core/core.hpp>


namespace OpenCVDotNet
{
	public enum class CVInterpolation
	{
		NearestNeigbor = CV_INTER_NN,
		Linear = CV_INTER_LINEAR,
		Area = CV_INTER_AREA,
		Cubic = CV_INTER_CUBIC
	};

	public enum class CVDepth
	{
		Depth1U = IPL_DEPTH_1U,
		Depth8U = IPL_DEPTH_8U,
		Depth16U = IPL_DEPTH_16U,
		Depth32F = IPL_DEPTH_32F,
		Depth8S = IPL_DEPTH_8S,
		Depth16S = IPL_DEPTH_16S,
		Depth32S = IPL_DEPTH_32S,
		Depth64F = IPL_DEPTH_64F,
	};

	public ref class CVConnectedComp
	{
	private:
		double area;
		unsigned char r, g, b;
		System::Drawing::Rectangle rect;
		CvSeq* contour;
		Color avgColor;

	public:
		CVConnectedComp(CvConnectedComp* in)
		{
			area = in->area;

			avgColor = CVUtils::ScalarToColor(in->value);

			rect = System::Drawing::Rectangle(in->rect.x, in->rect.y, in->rect.width, in->rect.height);
			contour = in->contour;
		}

		CVConnectedComp(System::Drawing::Rectangle rect)
		{
			this->rect = rect;
		}

		property System::Drawing::Rectangle Rect
		{
			System::Drawing::Rectangle get()
			{
				return this->rect;
			}
		}
		
		property double Area
		{
			double get()
			{
				return this->area;
			}
		}

		property Color AverageColor
		{
			Color get()
			{
				return this->avgColor;
			}
		}
	};



	public ref class CVImage : public CVArr, public IDisposable
	{
	internal:
		IplImage* image;
		bool created;
		//static ObjDetect* objDetect;

	public:
		CVImage()
		{
			//objDetect = new ObjDetect();
		}
		CVImage(IplImage* internal_image)
		{
			image = internal_image;
			created = false;
			/*if (!objDetect)
				objDetect = new ObjDetect();*/
		}

		CVImage(cv::Mat mat)
		{
			image = cvCloneImage(&(IplImage)mat);
		}

		CVImage(CVImage^ clone)
		{
			Create(clone->Width, clone->Height, clone->Depth, clone->Channels);
			cvConvertImage(clone->Internal, this->image, clone->Internal->origin == 1 ? CV_CVTIMG_FLIP : 0);
		}

		CVImage(System::Drawing::Bitmap^ sourceImage) 
        { 
            System::Drawing::Rectangle rect ; 
            rect.X = 0 ; 
            rect.Y = 0 ; 
            rect.Width = sourceImage->Width; 
            rect.Height = sourceImage->Height; 

            System::Drawing::Imaging::BitmapData^ bData = 
                    sourceImage->LockBits(rect, 
                    System::Drawing::Imaging::ImageLockMode::ReadWrite, 
                    sourceImage->PixelFormat); 

            IplImage* tempImage = cvCreateImageHeader(cvSize(sourceImage->Width, sourceImage->Height), 8, Bitmap::GetPixelFormatSize(sourceImage->PixelFormat)/8);                 
            tempImage->imageData = (char *)bData->Scan0.ToPointer(); 

            IplImage *dst[4]; 
            for(int i = 0 ; i < 4 ; i ++ ) 
                    dst[i] = NULL; 
            for(int i = 0 ; i < tempImage->nChannels ; i ++ ) 
                    dst[i] = cvCreateImage(cvSize(sourceImage->Width, sourceImage->Height), 8, 1); 

            cvSplit(tempImage, dst[0], dst[1], dst[2], dst[3]); 
            image = cvCreateImage(cvSize(sourceImage->Width, sourceImage->Height), 8, 3); 
            cvMerge(dst[0], dst[1], dst[2], NULL, image) ; 

            for(int i = 0 ; i < tempImage->nChannels ; i ++ ) 
                    cvReleaseImage(dst + i); 

            created = true; 
            sourceImage->UnlockBits(bData); 
        } 



		
		CVImage(int width, int height, CVDepth depth, int channels)
		{
			Create(width, height, depth, channels);
		}

		
		CVImage(System::String^ filename)
		{
			if (!System::IO::File::Exists(filename)) {
				throw gcnew System::IO::FileNotFoundException(filename);
			}
			LoadImage(filename, true);
		}

		
		CVImage(System::String^ filename, bool isColor)
		{
			LoadImage(filename, isColor);
		}

		
		CVImage(array<CVImage^>^ bgrChannels)
		{
			Create(bgrChannels[0]->Width, bgrChannels[0]->Height, bgrChannels[0]->Depth, 3);
			this->Merge(bgrChannels);
		}

		
		virtual ~CVImage()
		{
			Release();
		}

		
		void LoadImage(System::String^ filename, bool isColor)
		{
			Release();

			char fn[1024 + 1];
			CVUtils::StringToCharPointer(filename, fn, 1024);
			image = cvLoadImage(fn, isColor ? 1 : 0);
			created = true;
		}

		
		void Release()
		{
			if (!created) return;

			IplImage* ptr = image;
			cvReleaseImage(&ptr);
		}

		
		property CVRgbPixel^ default[System::Drawing::Point]
		{
			CVRgbPixel^ get(System::Drawing::Point pt)
			{
				return this[pt.Y, pt.X];
			}

			
			void set(System::Drawing::Point pt, CVRgbPixel^ val)
			{
				this[pt.Y, pt.X] = val;
			}
		}

		char* GetPixelPtr(int row, int col)
		{
			if (row < 0 || row >= Height || col < 0 || col >= Width)
			{
				throw gcnew CVException(System::String::Format("Attempt to access a pixel ({0},{1}) outside of bounds of the image (w={2},h={3})",
					col, row, Width, Height));
			}

			char* rowPtr = image->imageData + row * image->widthStep;
			char* pixelPtr = rowPtr + (col * image->nChannels);
			return pixelPtr;
		}

		
		property CVRgbPixel^ default[int, int]
		{
			CVRgbPixel^ get(int row, int col)
			{
				char* pixel = GetPixelPtr(row, col);

				if (Channels == 3)
				{
					return gcnew CVRgbPixel(pixel[2], pixel[1], pixel[0]);
				}
				else if (Channels == 1)
				{
					return gcnew CVRgbPixel(0, 0, pixel[0]);
				}
				else
				{
					return nullptr;
				}
			}

			
			void set(int row, int col, CVRgbPixel^ value)
			{
				char* pixel = GetPixelPtr(row, col);

				if (Channels == 3)
				{
					pixel[2] = value->R;
					pixel[1] = value->G;
					pixel[0] = value->B;
				}
				else if (Channels == 1)
				{
					pixel[0] = value->B;
				}
				else 
				{
					assert(false);
				}
			}
		}

		property int Width
		{
			int get()
			{
				return image->width;
			}
		}

		
		property int Height
		{
			int get()
			{
				return image->height;
			}
		}

		
		property int Channels
		{
			int get()
			{
				return image->nChannels;
			}
		}

		
		property CVDepth Depth
		{
			CVDepth get()
			{
				return (CVDepth) image->depth;
			}
		}

		
		virtual property CvArr* Array
		{
			CvArr* get() override
			{
				pin_ptr<CvArr> intr = image;
				return intr;
			}
		}

		
		virtual property IplImage* Internal
		{
			IplImage* get()
			{
				return (IplImage*) Array;
			}
		}

		void Zero()
		{
			if (image != NULL)
				cvZero(image);
		}

		void DrawLine(System::Drawing::Point pt1, System::Drawing::Point pt2, System::Drawing::Color color)
		{
			DrawLine(pt1, pt2, color, 1);
		}


		void DrawLine(System::Drawing::Point pt1, System::Drawing::Point pt2, System::Drawing::Color color, int thickness)
		{
			DrawLine(pt1, pt2, color, thickness, 8);
		}


		void DrawLine(System::Drawing::Point pt1, System::Drawing::Point pt2, System::Drawing::Color color, int thickness, int lineType)
		{
			DrawLine(pt1, pt2, color, thickness, lineType, 0);
		}

		void DrawLine(System::Drawing::Point pt1, System::Drawing::Point pt2, System::Drawing::Color color, int thickness, int lineType, int shift)
		{
			cvLine(this->Internal, cvPoint(pt1.X, pt1.Y), cvPoint(pt2.X, pt2.Y), CV_RGB(color.R, color.G, color.B), thickness, lineType, shift);
		}

		void DrawRectangle(System::Drawing::Rectangle rect, System::Drawing::Color color)
		{
			DrawRectangle(rect, color, 1);
		}

		void DrawRectangle(System::Drawing::Rectangle rect, System::Drawing::Color color, int thickness)
		{
			DrawRectangle(rect, color, thickness, 8, 0);
		}

		void DrawRectangle(System::Drawing::Rectangle rect, System::Drawing::Color color, int thickness, int lineType)
		{
			DrawRectangle(rect, color, thickness, lineType, 0);
		}

		void DrawRectangle(System::Drawing::Rectangle rect, System::Drawing::Color color, int thickness, int lineType, int shift)
		{
			cvRectangle(image, cvPoint(rect.Left, rect.Top), cvPoint(rect.Right, rect.Bottom), CV_RGB(color.R,color.G,color.B), thickness, lineType, shift);
		}

		void Split(CVImage^ ch0, CVImage^ ch1, CVImage^ ch2, CVImage^ ch3)
		{
			IplImage* d0 = ch0 != nullptr ? ch0->image : NULL;
			IplImage* d1 = ch1 != nullptr ? ch1->image : NULL;
			IplImage* d2 = ch2 != nullptr ? ch2->image : NULL;
			IplImage* d3 = ch3 != nullptr ? ch3->image : NULL;

			cvSplit(image, d0, d1, d2, d3);
		}

		array<CVImage^>^ Split()
		{
			List<CVImage^>^ channels = gcnew List<CVImage^>();

			int w = RegionOfInterest.Width;
			int h = RegionOfInterest.Height;

			CVImage^ c0 = Channels >= 1 ? gcnew CVImage(w, h, this->Depth, 1) : nullptr;
			CVImage^ c1 = Channels >= 2 ? gcnew CVImage(w, h, this->Depth, 1) : nullptr;
			CVImage^ c2 = Channels >= 3 ? gcnew CVImage(w, h, this->Depth, 1) : nullptr;
			CVImage^ c3 = Channels >= 4 ? gcnew CVImage(w, h, this->Depth, 1) : nullptr;

			Split(c0, c1, c2, c3);

			if (c0 != nullptr) channels->Add(c0);
			if (c1 != nullptr) channels->Add(c1);
			if (c2 != nullptr) channels->Add(c2);
			if (c3 != nullptr) channels->Add(c3);
			return channels->ToArray();
		}

		void Merge(CVImage^ blue, CVImage^ green, CVImage^ red)
		{
			IplImage* c0 = blue != nullptr ? blue->image : NULL;
			IplImage* c1 = green != nullptr ? green->image : NULL;
			IplImage* c2 = red != nullptr ? red->image : NULL;
			cvMerge(c0, c1, c2, NULL, image);
		}

		void Merge(array<CVImage^>^ rbgChannels)
		{
			assert(rbgChannels->Length == 3);
			Merge(rbgChannels[0], rbgChannels[1], rbgChannels[2]);
		}

		CVHistogram^ CalcHistogram(int binsSize)
		{
			return CalcHistogram(binsSize, nullptr);
		}


		CVHistogram^ CalcHistogram(int binsSize, CVImage^ mask)
		{
			array<Int32>^ binSizes = gcnew array<Int32>(3);
			array<CVPair^>^ binRanges = gcnew array<CVPair^>(3);

			binSizes[0] = binSizes[1] = binSizes[2] = binsSize;
			binRanges[0] = binRanges[1] = binRanges[2] = gcnew CVPair(0, 255);

			return CalcHistogram(binSizes, binRanges, mask);
		}

		CVHistogram^ CalcHistogram(array<int>^ binSizes, array<CVPair^>^ binRanges)
		{
			return CalcHistogram(binSizes, binRanges, nullptr);
		}

		CVHistogram^ CalcHistogram(array<int>^ binSizes, array<CVPair^>^ binRanges, CVImage^ mask)
		{
			CVHistogram^ h = gcnew CVHistogram(binSizes, binRanges);

			IplImage** images = new IplImage*[this->Channels];
			if (this->Channels == 1) 
			{
				images[0] = this->Internal;
			}
			else
			{
				array<CVImage^>^ planes = this->Split();
				for (int i = 0; i < planes->Length; ++i)
					images[i] = planes[i]->Internal;
			}

			CvArr* maskArr = NULL;
			if (mask != nullptr)
				maskArr = mask->Array;

			cvCalcHist(images, h->Internal, 0, maskArr);

			delete [] images;

			return h;
		}

		void Resize(int newWidth, int newHeight)
		{
			Resize(newWidth, newHeight, CVInterpolation::Area);
		}

		void Resize(int newWidth, int newHeight, CVInterpolation interpolation)
		{
			CVImage^ newImage = gcnew CVImage(newWidth, newHeight, Depth, Channels);
			cvResize(this->image, newImage->image, (int) interpolation);
			Release();
			this->image = newImage->image;
			newImage->created = false;
		}

		Bitmap^ ToBitmap()
		{
			SIZE size = { 0, 0 };
			int channels = 0;
			void* dst_ptr = 0;
			const int channels0 = 3;
			int origin = 0;
			CvMat stub, dst, *image;
			bool changed_size = false; // philipg

			HDC hdc = CreateCompatibleDC(0);
			CvArr* arr = this->Array;

			if (CV_IS_IMAGE_HDR(arr)) origin = ((IplImage*)arr)->origin;

			image = cvGetMat(arr, &stub);

			uchar buffer[sizeof(BITMAPINFO) + 255*sizeof(RGBQUAD)];
			BITMAPINFO* binfo = (BITMAPINFO*)buffer;

			size.cx = image->width;
			size.cy = image->height;
			channels = channels0;

			FillBitmapInfo(binfo, size.cx, size.cy, channels*8, 1);

			HBITMAP hBitmap = CreateDIBSection(hdc, binfo, DIB_RGB_COLORS, &dst_ptr, 0, 0);
			if (hBitmap == NULL)
				return nullptr;

			cvInitMatHeader(&dst, size.cy, size.cx, CV_8UC3, dst_ptr, (size.cx * channels + 3) & -4);
			cvConvertImage(image, &dst, origin == 0 ? CV_CVTIMG_FLIP : 0);

			System::Drawing::Bitmap^ bmpImage = System::Drawing::Image::FromHbitmap(IntPtr(hBitmap));

			DeleteObject(hBitmap);
			DeleteDC(hdc);

			return bmpImage;
		}

		static void FillBitmapInfo( BITMAPINFO* bmi, int width, int height, int bpp, int origin )
		{
			assert( bmi && width >= 0 && height >= 0 && (bpp == 8 || bpp == 24 || bpp == 32));

			BITMAPINFOHEADER* bmih = &(bmi->bmiHeader);

			memset( bmih, 0, sizeof(*bmih));
			bmih->biSize = sizeof(BITMAPINFOHEADER);
			bmih->biWidth = width;
			bmih->biHeight = origin ? abs(height) : -abs(height);
			bmih->biPlanes = 1;
			bmih->biBitCount = (unsigned short)bpp;
			bmih->biCompression = BI_RGB;

			if( bpp == 8 )
			{
				RGBQUAD* palette = bmi->bmiColors;
				int i;
				for( i = 0; i < 256; i++ )
				{
					palette[i].rgbBlue = palette[i].rgbGreen = palette[i].rgbRed = (BYTE)i;
					palette[i].rgbReserved = 0;
				}
			}
		}

		
		property System::Drawing::Rectangle RegionOfInterest
		{
			void set(System::Drawing::Rectangle rect)
			{
				System::Drawing::Rectangle irect(0, 0, Width, Height);
				if (!irect.IntersectsWith(rect))
					return;

				irect.Intersect(rect);
				cvSetImageROI(Internal, cvRect(irect.X, irect.Y, irect.Width, irect.Height));
			}

			System::Drawing::Rectangle get()
			{
				CvRect rc = cvGetImageROI(Internal);
				return System::Drawing::Rectangle(rc.x, rc.y, rc.width, rc.height);
			}
		}

		void ResetROI()
		{
			cvResetImageROI(Internal);
		}

		CVImage^ CalcBackProject(CVHistogram^ histogram)
		{
			cli::array<CVImage^>^ planes = Split();

			CVImage^ backProjection = 
				gcnew CVImage(
					planes[0]->RegionOfInterest.Width, 
					planes[0]->RegionOfInterest.Height, 
					planes[0]->Depth, 
					planes[0]->Channels);

			IplImage** iplImages = new IplImage*[planes->Length];
			for (int i = 0; i < planes->Length; ++i)
				iplImages[i] = planes[i]->Internal;

			cvCalcBackProject(iplImages, backProjection->Internal, histogram->Internal);

			delete [] iplImages;

			for (int i = 0; i < planes->Length; ++i)
				planes[i]->Release();

			return backProjection;
		}

		CVConnectedComp^ MeanShift(System::Drawing::Rectangle window)
		{
			return MeanShift(window, 0.1);
		}

		CVConnectedComp^ MeanShift(System::Drawing::Rectangle window, int maxIterations)
		{
			return MeanShift(window, CV_TERMCRIT_ITER, maxIterations);
		}

		CVConnectedComp^ MeanShift(System::Drawing::Rectangle window, double eps)
		{
			return MeanShift(window, CV_TERMCRIT_EPS, eps);
		}

		CVConnectedComp^ MeanShift(System::Drawing::Rectangle window, int maxIterations, double eps)
		{
			return MeanShift(window, CV_TERMCRIT_ITER | CV_TERMCRIT_EPS, maxIterations, eps);
		}

		CVConnectedComp^ MeanShift(System::Drawing::Rectangle window, int termCriteria, int maxIterations, double eps)
		{
			System::Drawing::Rectangle realWindow(0, 0, Width, Height);
			if (!realWindow.IntersectsWith(window))
			{
				CVConnectedComp^ cc = gcnew CVConnectedComp(window);
				return cc;
			}

			realWindow.Intersect(window);

			CvRect wnd = cvRect(realWindow.X, realWindow.Y, realWindow.Width, realWindow.Height);
			CvTermCriteria tc = cvTermCriteria(termCriteria, maxIterations, eps);
			
			CvConnectedComp comp;
			cvMeanShift(Internal, wnd, tc, &comp);

			return gcnew CVConnectedComp(&comp);
		}

		CVImage^ CopyRegion(System::Drawing::Rectangle rect)
		{
			CVImage^ roi = gcnew CVImage(this);
			roi->RegionOfInterest = rect;
			return roi;
		}

		//void DrawPixel(System::Drawing::Point pt)
		//{
		//	DrawPixel(pt, Color::FromArgb(255,255,255));
		//}

		//void DrawPixel(System::Drawing::Point pt, System::Drawing::Color color)
		//{
		//	DrawPixel(pt, color, 1);
		//}

		//void DrawPixel(System::Drawing::Point pt, System::Drawing::Color color, int thickness)
		//{
		//	DrawRectangle(
		//		System::Drawing::Rectangle(pt, Size(0, 0)), 
		//		color, thickness);
		//}

		CVConnectedComp^ CamShift(System::Drawing::Rectangle window, double eps)
		{
			return CamShift(window, CV_TERMCRIT_EPS, 0, eps);
		}

		CVConnectedComp^ CamShift(System::Drawing::Rectangle window, int maxIterations)
		{
			return CamShift(window, CV_TERMCRIT_ITER, maxIterations, 0.0);
		}

		CVConnectedComp^ CamShift(System::Drawing::Rectangle window, int termCriteria, int maxIterations, double eps)
		{
			CvConnectedComp cc;
			cvCamShift(Internal, cvRect(window.X, window.Y, window.Width, window.Height), cvTermCriteria(termCriteria, maxIterations, eps), &cc);
			return gcnew CVConnectedComp(&cc);
		}

		CVImage^ Clone()
		{
			CVImage^ n = gcnew CVImage(NULL);
			n->image = cvCloneImage(this->Internal);
			return n;
		}

		CVImage^ ToGrayscale()
		{
			CVImage^ gs = gcnew CVImage(Width, Height, Depth, 1);
			System::Drawing::Rectangle prevRoi = this->RegionOfInterest;
			this->ResetROI();
			cvConvertImage(this->Internal, gs->Internal);
			this->RegionOfInterest = prevRoi;
			gs->RegionOfInterest = prevRoi;

			return gs;
		}

		bool Contains(System::Drawing::Point pt)
		{
			System::Drawing::Rectangle rc(0, 0, Width, Height);
			return (rc.Contains(pt));
		}

		

	private:
		void Create(int width, int height, CVDepth depth, int channels)
		{
			image = cvCreateImage(cvSize(width, height), (int) depth,  channels);
			created = true;
		}

		static Bitmap^ MatToBitmap(cv::Mat srcImg);
	public:
		System::String^ DetectChar();
		Bitmap^ DetectPlate(bool crop);
		

	};


};