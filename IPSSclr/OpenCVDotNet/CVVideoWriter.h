/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

namespace OpenCVDotNet
{
	public enum class CVCodec
	{
		UserDefined = -1,
		Mpeg1 = 1,//CV_FOURCC('P','I','M','1'), // MPEG-1 codec
		MotionJpeg = 2,//CV_FOURCC('M','J','P','G'), // motion-jpeg codec (does not work well)
		Mpeg4_2 = 3,//CV_FOURCC('M', 'P', '4', '2'), // MPEG-4.2 codec
		Mpeg4_3 = 4,//CV_FOURCC('D', 'I', 'V', '3'), // MPEG-4.3 codec
		Mpeg4 = 5,//CV_FOURCC('D', 'I', 'V', 'X'), // MPEG-4 codec
		H263 = 6,//CV_FOURCC('U', '2', '6', '3'), // H263 codec
		H263I = 7,//CV_FOURCC('I', '2', '6', '3'), // H263I codec
		Flv1 = 8//CV_FOURCC('F', 'L', 'V', '1'), // FLV1 codec
	};

	public enum class CVFramesPerSecond
	{
		Fps25 = 25,
		Fps30 = 30,
	};

	public ref class CVVideoWriter
	{
	private:
		CvVideoWriter* vw_;

	public:
		CVVideoWriter(System::String^ filename, int width, int height)
		{
			Create(filename, CVCodec::UserDefined, CVFramesPerSecond::Fps25, width, height, true);
		}

		CVVideoWriter(System::String^ filename, CVCodec codec, int width, int height)
		{
			Create(filename, codec, CVFramesPerSecond::Fps25, width, height, true);
		}

		CVVideoWriter(System::String^ filename, CVCodec codec, CVFramesPerSecond fps, int width, int height)
		{
			Create(filename, codec, fps, width, height, true);
		}

		CVVideoWriter(System::String^ filename, CVCodec codec, CVFramesPerSecond fps, int width, int height, bool is_color)
		{
			Create(filename, codec, fps, width, height, is_color);
		}

		~CVVideoWriter()
		{
			Release();
		}

		void WriteFrame(CVImage^ image)
		{
			cvWriteFrame(vw_, image->Internal);
		}

		void Release()
		{
			CvVideoWriter* ptr = vw_;
			cvReleaseVideoWriter(&ptr);
		}

	protected:
		void Create(System::String^ filename, CVCodec codec, CVFramesPerSecond fps, int width, int height, bool is_color)
		{
			char fn[1024 + 1];
			CVUtils::StringToCharPointer(filename, fn, 1024);
			vw_ = cvCreateVideoWriter(fn, (int) codec, (int) fps, cvSize(width, height), is_color ? 1 : 0);
		}
	};

};