/**
 * (C) 2007 Elad Ben-Israel
 * This code is licenced under the GPL.
 */

#pragma once

#include "stdafx.h"

using namespace System::Collections::Generic;

#include "CVPair.h"
#include "CVArr.h"

namespace OpenCVDotNet
{
	public enum class CVHistogramType
	{
		Array = CV_HIST_ARRAY,
		Sparse = CV_HIST_SPARSE,
	};

	public ref class CVHistogram
	{
	private:
		CvHistogram* _hist;
		array<int>^ _binSizes;
		array<CVPair^>^ _binRanges;

	public:
		CVHistogram(array<int>^ binSizes, array<CVPair^>^ binRanges)
		{
			CreateHist(binSizes, binRanges);
		}

		virtual ~CVHistogram(void)
		{
			Release();
		}

		void Release()
		{
			if (_hist != NULL)
			{
				CvHistogram* p = (CvHistogram*) _hist;
				cvReleaseHist(&p);
				_hist = NULL;
			}
		}

		property CVPair^ MinMaxValue
		{
			CVPair^ get()
			{
				float min_value, max_value;
				cvGetMinMaxHistValue(_hist, &min_value, &max_value);
				return gcnew CVPair(min_value, max_value);
			}
		}

		property double default[int]
		{
			double get(int idx0)
			{
				return cvQueryHistValue_1D(_hist, idx0);
			}
		}
		
		property CvHistogram* Internal
		{
			CvHistogram* get()
			{
				return _hist;
			}
		}

		property array<int>^ BinSizes
		{
			array<int>^ get()
			{
				return this->_binSizes;
			}
		}

		property array<CVPair^>^ BinRanges
		{
			array<CVPair^>^ get()
			{
				return this->_binRanges;
			}

		}

	protected:
		void CreateHist(array<int>^ binSizes, array<CVPair^>^ binRanges)
		{
			this->_binSizes = binSizes;
			this->_binRanges = binRanges;

			int dims = binSizes->Length;
			cli::pin_ptr<int> sizes = &binSizes[0];
			float** ranges = new float*[binRanges->Length];

			// make sure ranges & sizes are of the same dimention.
			assert(binSizes->Length == binRanges->Length);
			
			// create ranges array.
			for (int i = 0; i < binRanges->Length; ++i)
			{
				float* range = new float[2];
				range[0] = binRanges[i]->First;
				range[1] = binRanges[i]->Second;
				ranges[i] = range;
			}

			// create histogram.
			_hist = cvCreateHist(dims, sizes, CV_HIST_ARRAY, (float**) ranges, 1);

			// delete ranges array.
			for (int i = 0; i < binRanges->Length; ++i) delete ranges[i];
			delete [] ranges;
		}
	};
}