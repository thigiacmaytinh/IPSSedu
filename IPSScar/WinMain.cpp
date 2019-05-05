// IPSSdetectorCPP.cpp : Defines the entry point for the console application.
//

#include <tchar.h>
#include "TGMTfile.h"
#include "TGMTdebugger.h"
#include "TGMTutil.h"
#ifdef WIN32
#include <thread>
#include <windows.h>
#include <future>
#endif
#include "TGMTCar.h"


#define DETECT_PLATE 0


//use for read video
std::string m_outdir;
std::string m_content = "";
int m_exactly = 0;
bool m_writeLog = true;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void PrintHelp()
{
	PrintMessage("==========================================================\n");
	PrintMessage("Using by syntax: \n");
	PrintMessageGreen("CarDetector.exe -in <directory or file>");
	PrintMessage("-in is directory contain images or image to detect");
	PrintMessage("-out is directory contain result");
	PrintMessage("==========================================================");
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#ifdef CAR
void ReadCarPlates(std::vector<std::string> imgList, std::string outDir)
{

	if (imgList.size() == 0)
	{
		PrintError("No input image");
		return;
	}


	START_COUNT_TIME("Total");

	int exactly = 0;

	std::string content = "";

	for (size_t i = 0; i < imgList.size(); i++)
	{
		if (!TGMTfile::FileExist(imgList[i]))
			PrintError("File %s is not exist", imgList[i].c_str());
		else if (!TGMTfile::IsImage(imgList[i]))
			PrintError("File %s is not image", imgList[i].c_str());
		else
		{

			CarPlateCpp result = GetTGMTcar()->ReadPlate(imgList[i]);
			if (!outDir.empty())
			{
				WRITE_IMAGE(result.image, "%s\\%s.jpg", outDir.c_str(), TGMTfile::GetFileNameWithoutExtension(imgList[i]).c_str());
			}			

			content += TGMTutil::FormatString("%s %s\n", imgList[i].c_str(), result.text == "" ? result.error.c_str() : result.text.c_str());

			if (result.hasPlate)
			{
				PrintSuccess("%s : %s", imgList[i].c_str(), result.text.c_str());
				if(result.isValid)
					exactly++;
			}
			else
			{
				PrintError("%s : %s (%s)", imgList[i].c_str(), result.text.c_str(), result.error.c_str());
			}

			SET_CONSOLE_TITLE("%d / %d", i + 1, imgList.size());
		}
	}
	PrintMessage("Write result to file %s\\Result.txt", outDir.c_str());
	std::string sumup = TGMTutil::FormatString("Exactly %d / %d plate", exactly, imgList.size());
	TGMTfile::WriteToFile(outDir.empty() ? "report.csv" : outDir + "\\report.csv", content + "\n" + sumup, false);

	PrintMessage(sumup.c_str());
	STOP_AND_PRINT_COUNT_TIME("Total");
}
#endif

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int _tmain(int argc, _TCHAR* argv[])
{

	SET_CONSOLE_TITLE("IPSS car detector");

	if (argc == 1)
	{
		PrintHelp();
	}
	else if (argc < 3)
	{
		TGMTutil::CheckParameterExist(argc, argv, "-in");
		return -1;
	}
	else
	{
		std::string in = TGMTutil::GetParameter(argc, argv, "-in");
		m_outdir = TGMTutil::GetParameter(argc, argv, "-out");

		if (TGMTfile::IsDir(in))
		{
			if (in == m_outdir)
			{
				PrintError("Directory input same as directory output");
			}
			else
			{
				PrintMessage("Loading files from %s", in.c_str());
				std::vector<std::string> imgList = TGMTfile::GetImageFilesInDir(in);

				ReadCarPlates(imgList, m_outdir);

			}
		}
		else if (TGMTfile::IsImage(in))
		{
			std::vector<std::string> imgList;
			imgList.push_back(in);
			ReadCarPlates(imgList, m_outdir);


		}
	}

	cv::waitKey();
	getchar();

	return 0;
}
