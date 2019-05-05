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

#include "OCR.h"
#include "TGMTimage.h"
#include "TGMTdebugger.h"


OCR* OCR::m_instance = nullptr;
const char OCR::strCharacters[] = { '0','1','2','3','4','5','6','7','8','9','B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
const int OCR::numCharacters = 30;


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

OCR::OCR()
{
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void OCR::Init(std::string trainFile)
{
	m_trained = false;

	//Read file storage.
	cv::FileStorage fs;
	fs.open(trainFile, cv::FileStorage::READ);
	ASSERT(fs.isOpened(), "Can not load %s", trainFile.c_str());
	cv::Mat matData;
	cv::Mat matClasses;
	fs["TrainingDataF15"] >> matData;
	fs["classes"] >> matClasses;

#if USE_ANN
	TrainAnn(matData, matClasses, 10);
#else
	TrainKnn(matData, matClasses);
#endif
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void OCR::TrainAnn(cv::Mat TrainData, cv::Mat classes, int nlayers)
{
	DEBUG_IMAGE(TrainData, "TrainData");

	cv::Mat_<int> layers(3, 1);
	layers(0) = TrainData.cols;     // input
	layers(1) = numCharacters ;  // hidden
	layers(2) = nlayers;  // hidden
	

	ann = ANN_MLP::create();
	ann->setLayerSizes(layers);
	ann->setActivationFunction(cv::ml::ANN_MLP::SIGMOID_SYM);

	//Prepare trainClases
	//Create a mat with n trained data by m classes
	cv::Mat trainClasses;
	trainClasses.create(TrainData.rows, nlayers, CV_32FC1);
	for (int i = 0; i < trainClasses.rows; i++)
	{
		for (int k = 0; k < trainClasses.cols; k++)
		{
			//If class of data i is same than a k class
			if (k == classes.at<int>(i))
				trainClasses.at<float>(i, k) = 1;
			else
				trainClasses.at<float>(i, k) = 0;
		}
	}


	//Learn classifier
	m_trained = ann->train(TrainData, cv::ml::ROW_SAMPLE, trainClasses);

	ASSERT(m_trained, "Training data OCR failed");
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int OCR::ClassifyAnn(cv::Mat f)
{
	int result = -1;
	cv::Mat output(1, numCharacters, CV_32FC1);

	ann->predict(f, output);

	cv::Point maxLoc;
	double maxVal;
	cv::minMaxLoc(output, 0, &maxVal, 0, &maxLoc);
	//We need know where in output is the max val, the x (cols) is the class.

	return maxLoc.x;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int OCR::ClassifyKnn(cv::Mat f)
{
	cv::Mat m;
	int response = knn->findNearest(f, knn->getDefaultK(), m);
	return response;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void OCR::TrainKnn(cv::Mat trainSamples, cv::Mat trainClasses)
{
	// learn classifier
	knn = KNearest::create();
	knn->setIsClassifier(true);
	knn->setAlgorithmType(KNearest::Types::BRUTE_FORCE);
	knn->train(trainSamples, ROW_SAMPLE, trainClasses);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




