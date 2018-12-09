/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

namespace OpenCVDotNet
{
	public ref class CVWindow
	{
	private:
		char* nativeName_;

	public:
		CVWindow(System::String^ name)
		{
			CreateCVWindow(name, CV_WINDOW_AUTOSIZE);
		}

		~CVWindow()
		{
			delete [] nativeName_;
		}

		CVWindow(System::String^ name, int flags)
		{
			CreateCVWindow(name, flags);
		}

		void Move(int x, int y)
		{
			cvMoveWindow(nativeName_, x, y);
		}

		void Resize(int width, int height)
		{
			cvResizeWindow(nativeName_, width, height);
		}

		void ShowImage(CVImage^ image)
		{
			cvShowImage(nativeName_, image->Internal);
		}

		int WaitKey(int timeout)
		{
			return cvWaitKey(timeout);
		}

		property IntPtr Handle
		{
			IntPtr get()
			{
				void* ptr = cvGetWindowHandle(nativeName_);
				return IntPtr(ptr);
			}
		}

		void HideFrame()
		{
			HWND ptr = (HWND) cvGetWindowHandle(nativeName_);
			HWND parentHwnd = GetParent(ptr);
			ShowWindow(parentHwnd, SW_HIDE);
		}

	private:
		void CreateCVWindow(System::String^ name, int flags)
		{
			nativeName_ = new char[100 + 1];
			CVUtils::StringToCharPointer(name, nativeName_, 100);
			cvNamedWindow(nativeName_, flags);
		}


	};
};