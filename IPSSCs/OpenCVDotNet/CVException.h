/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

namespace OpenCVDotNet
{
	public ref class CVException : public Exception
	{
	public:
		CVException(String^ message) : Exception(message) 
		{
		}
	};
};