/*****************************************************************************
*   Number Plate Recognition using SVM and Neural Networks
******************************************************************************
*   by David Millán Escrivá, 5th Dec 2012
*   http://blog.damiles.com
******************************************************************************
*   Ch5 of the book "Mastering OpenCV with Practical Computer Vision Projects"
*   Copyright Packt Publishing 2012.
*   http://www.packtpub.com/cool-projects-with-opencv/book
*****************************************************************************/

#pragma once


#include "stdafx.h"
#include <opencv2\ml\ml.hpp>

using namespace cv::ml;


#define HORIZONTAL	1
#define VERTICAL    0
#define CHAR_SIZE	20
#define USE_ANN		0

#define GetOCR OCR::GetInstance



class OCR
{
	static OCR* m_instance;
    public:

		static OCR* GetInstance()
		{
			if (!m_instance)
				m_instance = new OCR();
			return m_instance;
		}
		
		static const int numCharacters;
		static const char strCharacters[];		
        
        OCR();
		void Init(std::string trainFile);
		     
		
        int ClassifyAnn(cv::Mat f);
        void TrainAnn(cv::Mat trainData, cv::Mat trainClasses, int nlayers);
        int ClassifyKnn(cv::Mat f);
        void TrainKnn(cv::Mat trainSamples, cv::Mat trainClasses);		
		
    private:
        bool m_trained;		
		
		cv::Ptr<ANN_MLP> ann;
		cv::Ptr<KNearest> knn;
};
