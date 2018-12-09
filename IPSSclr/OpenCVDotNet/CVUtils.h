/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

#include "CVException.h"

namespace OpenCVDotNet
{
	static int ErrorHandler(int status, const char* func_name, const char* err_msg, const char* file_name, int line, void* userdata)
	{
		throw gcnew CVException(gcnew System::String(err_msg));
		return 0;
	}

	public ref class CVUtils
	{
	public:
		static void StringToCharPointer(String^ string, char* output, int size)
		{
			pin_ptr<const __wchar_t> p = PtrToStringChars(string);
			wcstombs_s(NULL, output, size, p, size);
		}

		static int Round(double val)
		{
			return cvRound(val);
		}

		static void ErrorsToExceptions()
		{
			cvRedirectError(ErrorHandler);
		}

		static Color ScalarToColor(CvScalar scalar)
		{
			return Color::FromArgb((int) scalar.val[2], (int) scalar.val[1], (int) scalar.val[0]);
		}

		static System::String^ stdStrToSystemStr(std::string str)
		{
			return gcnew String(str.c_str());
		}

		static std::string SystemStr2stdStr(System::String^ str)
		{
			using namespace Runtime::InteropServices;
			const char* chars = (const char*)(Marshal::StringToHGlobalAnsi(str)).ToPointer();
			std::string result = chars;
			Marshal::FreeHGlobal(IntPtr((void*)chars));
			return result;
		}
	};
};