/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

namespace OpenCVDotNet
{
	public ref class CVArr abstract 
	{
	public:
		virtual property CvArr* Array
		{
			CvArr* get() = 0;
		}

		virtual property System::IntPtr Ptr
		{
			System::IntPtr get()
			{
				return System::IntPtr(Array);
			}
		}
	};
}