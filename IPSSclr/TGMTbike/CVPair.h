/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

namespace OpenCVDotNet
{
	public ref class CVPair
	{
	private:
		float _first, _second;

	public:
		CVPair(float first, float second)
		{
			_first = first;
			_second = second;
		}

		property float First { float get() { return _first; } }
		property float Second { float get() { return _second; }}

		virtual String^ ToString() override
		{
			return String::Format("({0},{1})", _first, _second);
		}
	};
}