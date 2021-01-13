/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

namespace OpenCVDotNet
{
	public ref class CVRgbPixel
	{
		Byte r, b, g;

	public:
		CVRgbPixel(Byte r, Byte g, Byte b)
		{
			this->r = r;
			this->b = b;
			this->g = g;
		}

		CVRgbPixel(Color col)
		{
			this->r = col.R;
			this->b = col.B;
			this->g = col.G;
		}

		property Byte R { Byte get() { return r; } }
		property Byte G { Byte get() { return g; } }
		property Byte B { Byte get() { return b; } }

		property Byte BwValue
		{
			Byte get()
			{
				return this->GrayLevel;
			}
		}

		property Byte GrayLevel
		{
			Byte get()
			{
				Byte bw_value = (Byte)
					((double) b * 0.114 + 
					 (double) g * 0.587 + 
					 (double) r * 0.299);
				return bw_value;
			}
		}

		virtual String^ ToString() override
		{
			return String::Format("({0},{1},{2})", r, g, b);
		}

		Color ToColor()
		{
			return Color::FromArgb(this->R, this->G, this->B);
		}
	};
};