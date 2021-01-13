/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

namespace OpenCVDotNet
{
	public ref class CVCapture
	{
	private:
		CvCapture* capture;
		System::String^ filename;

		CVImage^ asImage;

	public:
		CVCapture(System::String^ filename)
		{
			capture = NULL;
			asImage = nullptr;
			Open(filename);
		}

		CVCapture()
		{
			asImage = nullptr;
			capture = cvCreateCameraCapture(CV_CAP_ANY);
		}

		CVCapture(int cameraId)
		{
			asImage = nullptr;
			capture = cvCreateCameraCapture(cameraId);
		}

		~CVCapture()
		{
			Release();
		}

		void Release()
		{
			if (asImage != nullptr)
			{
				asImage->Release();
				asImage = nullptr;
			}

			if (capture != NULL)
			{
				pin_ptr<CvCapture*> cap = &capture;
				cvReleaseCapture(cap);
			}
		}

		property int Width
		{
			int get()
			{
				if (asImage != nullptr) return asImage->Width;
				return (int) cvGetCaptureProperty(capture, CV_CAP_PROP_FRAME_WIDTH);
			}
		}

		property int Height
		{
			int get()
			{
				if (asImage != nullptr) return asImage->Height;
				return (int) cvGetCaptureProperty(capture, CV_CAP_PROP_FRAME_HEIGHT);
			}
		}

		CVImage^ QueryFrame()
		{
			if (asImage != nullptr) return asImage->Clone();

			IplImage* frame = cvQueryFrame(capture);
			if (frame == NULL) return nullptr;
			CVImage^ newImage = gcnew CVImage(gcnew CVImage(frame));
			return newImage;
		}

		void Open(System::String^ filename)
		{
			Release();
			
			capture = NULL;
			asImage = nullptr;

			System::String^ ext = System::IO::Path::GetExtension(filename);

			// if the extension of the filename is not AVI, try opening as an image.
			if (ext->ToUpper()->CompareTo(".AVI") != 0)
			{
				asImage = gcnew CVImage(filename);
			}
			else
			{
				char fn[1024 + 1];
				CVUtils::StringToCharPointer(filename, fn, 1024);
				capture = cvCreateFileCapture(fn);

				if (capture == NULL)
				{
					throw gcnew CVException(
						System::String::Format("Unable to open file	'{0}' for capture", filename));
				}
			}

			this->filename = filename;
		}

		property int FramesPerSecond
		{
			int get()
			{
				// if this is an image, return 30 as default FPS.
				if (asImage != nullptr) return 30;
				
				return (int) cvGetCaptureProperty(capture, CV_CAP_PROP_FPS);
			}
		}

		void Restart()
		{
			Open(filename);
		}

		CVImage^ CreateCompatibleImage()
		{
			CVImage^ img = gcnew CVImage(this->Width, this->Height, CVDepth::Depth8U, 3);
			return img;
		}
	};
};