#include "TGMTfile.h"

#if defined(WIN32) || defined(WIN64) 
#include "TGMTdebugger.h"
#include "TGMTutil.h"
#include <windows.h>
#ifdef UNICODE
#define TGMTSTR LPCWSTR
#else
#define TGMTSTR LPCSTR
#endif
#endif // WIN32

#include <iostream>
#include <fstream>


#ifdef _MANAGED

#include "TGMTbridge.h"
using namespace System::Threading::Tasks;
using namespace System::Threading;
#else
#include <future>
#include <algorithm>
#endif

#if defined (OS_LINUX)
#include <stdlib.h>
#include <unistd.h>
#include <sys/stat.h>
#include <sys/types.h>
#include "dirent.h"
#include <errno.h>
#include <vector>
#endif
//TGMTfile::TGMTfile(void)
//{
//}
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//TGMTfile::~TGMTfile(void)
//{
//}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<std::string> TGMTfile::GetFilesInDir(std::string dirPath, bool searchAllChildDir)
{	
	std::vector<std::string> result;
#if defined(WIN32) || defined (OS_LINUX)
	WIN32_FIND_DATA findFileData;
	HANDLE hFind;
	std::string fileName;
	bool ret = true;

	TGMTfile::CorrectPath(dirPath);

#ifdef UNICODE
	std::wstring wsForLongFileName = std::wstring(L"\\\\?\\") + TGMTutil::String2WString(dirPath) + L"*";

#else
	std::string wsForLongFileName = std::string("\\\\?\\") + dirPath + "*";
#endif
	hFind = FindFirstFile((TGMTSTR)(wsForLongFileName).c_str(), &findFileData);
	if (hFind != INVALID_HANDLE_VALUE)
	{
		do
		{
#ifdef UNICODE
			fileName = TGMTutil::WString2String((TGMTSTR)findFileData.cFileName);
#else
			fileName = (TGMTSTR)findFileData.cFileName;
#endif
			if (fileName != "." && fileName != "..")
			{
				fileName.insert(0, dirPath);
				if ((findFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) != 0)   //file is a directory
				{
					if (searchAllChildDir)
					{
						std::vector<std::string> temp = GetFilesInDir(fileName, searchAllChildDir);
						result.insert(result.end(), temp.begin(), temp.end());
					}
				}
				else   //is a file
				{
					result.push_back(fileName);
				}

			}
		}
		while (FindNextFile(hFind, &findFileData));

		FindClose(hFind);
	}
#endif
	return result;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTfile::FileExist(std::string filePath)
{
	if (filePath == "")
		return false;
	if (FILE *file = fopen(filePath.c_str(), "r"))
	{
		fclose(file);
		return true;
	}
	else
	{
		return false;
	}
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::GetFileName(std::string filePath)
{
	size_t idx = filePath.rfind('\\');
	return filePath.substr(idx + 1);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::GetFileExtension(std::string filePath)
{
	size_t idx = filePath.rfind('.');
	return filePath.substr(idx + 1);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::GetDirName(std::string dirPath)
{
	if (dirPath.substr(dirPath.length() - 2) == "\\")
	{
		dirPath = dirPath.substr(dirPath.length() - 2);
	}

	return GetFileName(dirPath);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::GetFileNameWithoutExtension(std::string filePath)
{
	std::string fileName = GetFileName(filePath);
	size_t idx = fileName.rfind('.');
	return fileName.substr(0, idx);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTfile::DirExist(const std::string dirName)
{
#ifdef WIN32
	DWORD ftyp = GetFileAttributesA(dirName.c_str());
	if (ftyp == INVALID_FILE_ATTRIBUTES)
		return false;  //something is wrong with your path!

	if (ftyp & FILE_ATTRIBUTE_DIRECTORY)
		return true;   // this is a directory!

	return false;    // this is not a directory!
#elif defined (OS_LINUX)
	if (0 == access(dirName.c_str(), F_OK))
	{
		struct stat statbuf;
		if (0 == stat(dirName.c_str(), &statbuf))
			return (S_IFDIR & statbuf.st_mode) != 0;
	}
#endif
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::CreateDir(std::string dirName)
{
#if defined(WIN32) || defined (OS_LINUX)
	if (DirExist(dirName))
		return;
#endif

#if defined(WIN32)
	CreateDirectoryA(dirName.c_str(), NULL);
#elif defined (OS_LINUX)
	std::string command = "mkdir -p " + dirName;
	const int dir_err = system(command.c_str());
	if (-1 == dir_err)
	{
		printf("Error creating directory!n");
	}
#else
	//TODO
#endif

}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


std::string TGMTfile::GetCurrentDir()
{
#ifdef WIN32
#ifdef UNICODE
	wchar_t buffer[MAX_PATH];
	GetCurrentDirectory(MAX_PATH, buffer);
	std::wstring wstr(buffer);
	return std::string(wstr.begin(), wstr.end());
#else
	char buffer[MAX_PATH];
	GetCurrentDirectory(MAX_PATH, buffer);
	return buffer;
#endif

#elif defined( OS_LINUX)
	char pWorkingDirectory[MAX_PATH];
	getcwd(pWorkingDirectory, MAX_PATH);
	std::string currentDir(pWorkingDirectory);
	return currentDir;
#endif
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<std::string> TGMTfile::GetImageFilesInDir(std::string dirPath, bool searchAllChildDir)
{
	std::vector<std::string> fileNames = GetFilesInDir(dirPath, searchAllChildDir);
	std::vector<std::string> result;
	for (size_t i = 0; i < fileNames.size(); i++)
	{
		if (IsImage(fileNames[i]))
		{
			result.push_back(fileNames[i]);
		}
	}
	return result;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<std::string> TGMTfile::GetVideoFilesInDir(std::string dirPath, bool searchAllChildDir)
{
	std::vector<std::string> fileNames = GetFilesInDir(dirPath, searchAllChildDir);
	std::vector<std::string> result;
	for (size_t i = 0; i < fileNames.size(); i++)
	{
		if (IsVideo(fileNames[i]))
		{
			result.push_back( fileNames[i]);
		}
	}
	return result;
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTfile::IsDir(std::string filePath)
{
	return DirExist(filePath);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTfile::IsImage(std::string filePath)
{	
	std::string ext = filePath.substr(filePath.find_last_of(".") + 1);
	std::transform(ext.begin(), ext.end(), ext.begin(), ::tolower);
	return (ext == "jpg" || ext == "png" || ext == "bmp" || ext == "pgm" || ext == "webp" || ext == "gif" || ext == "jpeg");
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTfile::IsVideo(std::string filePath)
{
	std::string ext = filePath.substr(filePath.find_last_of(".") + 1);
	std::transform(ext.begin(), ext.end(), ext.begin(), ::tolower);
	return (ext == "mp4" || ext == "avi" || ext == "wmv" || ext == "mpg" || ext == "flv");
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::WriteToFile(std::string fileName, std::string text, bool append)
{
	std::ofstream myfile(fileName, append ? std::ios::app : std::ios::out);
	myfile.write(text.c_str(), sizeof(char)*text.size());
	myfile.close();
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if (defined(WIN32) ||defined(WIN64)) && !defined(_MANAGED)
void TGMTfile::WriteToFileAsync(std::string fileName, std::string text, bool append)
{
	std::future<void> result = std::async([](const std::string _fileName, const std::string _text, bool _append)
	{
		WriteToFile(_fileName, _text, _append);
	}, fileName, text, append);
}
#endif

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::GetParentDir(std::string filePath)
{
	int lastSlash = filePath.rfind('\\');
	std::string dir = filePath.substr(0, lastSlash);
	int idx = dir.rfind('\\');
	return dir.substr(idx + 1);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<std::string> TGMTfile::GetChildDirInDir(std::string dirPath, bool searchAllChildDir)
{
	std::vector<std::string> result;
#if defined(WIN32) || defined (OS_LINUX)
	WIN32_FIND_DATA findFileData;
	HANDLE hFind;
	std::string fileName;
	bool ret = true;

	TGMTfile::CorrectPath(dirPath);

#ifdef UNICODE
	std::wstring wsForLongFileName = std::wstring(L"\\\\?\\") + TGMTutil::String2WString(dirPath) + L"*";
	
#else
	std::string wsForLongFileName = std::string("\\\\?\\") + dirPath + "*";
	
#endif

	hFind = FindFirstFile((TGMTSTR)(wsForLongFileName).c_str(), &findFileData);
	if (hFind != INVALID_HANDLE_VALUE)
	{
		do
		{
#ifdef UNICODE
			fileName = TGMTutil::WString2String((TGMTSTR)findFileData.cFileName);
#else
			fileName = (TGMTSTR)findFileData.cFileName;
#endif
			if (fileName != "." && fileName != "..")
			{
				fileName.insert(0, dirPath);
				if ((findFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) != 0)   //file is a directory
				{
					result.push_back(fileName);
					if (searchAllChildDir)
					{
						std::vector<std::string> temp = GetChildDirInDir(fileName, searchAllChildDir);
						result.insert(result.end(), temp.begin(), temp.end());
					}
				}
			}
		} while (FindNextFile(hFind, &findFileData));

		FindClose(hFind);
	}
#endif
	return result;	
}

//void CopyFile(const std::string& fileNameFrom, const std::string& fileNameTo)
//{
//	assert(fileExists(fileNameFrom));
//	std::ifstream in(fileNameFrom.c_str());
//	std::ofstream out(fileNameTo.c_str());
//	out << in.rdbuf();
//	out.close();
//	in.close();
//}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::ReadAllText(std::string fileName)
{
	std::string content;
	std::ifstream myFile(fileName);
	if (myFile.is_open())
	{
		std::string line;
		while (getline(myFile, line))
		{
			content.append(line);
		}
		myFile.close();
	}

	return content;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<std::string> TGMTfile::ReadAllLine(std::string fileName)
{
	std::ifstream infile(fileName);

	std::string line;
	std::vector<std::string> lines;
	while (std::getline(infile, line))
	{
		lines.push_back(line);
	}
	return lines;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if (defined(WIN32) ||defined(WIN64)) && defined(UNICODE)
#include <codecvt>
std::vector<std::wstring> TGMTfile::WReadAllLine(std::string fileName)
{
	std::wifstream infile(fileName);
	infile.imbue(std::locale(std::locale::empty(), new std::codecvt_utf8<wchar_t>));
	std::wstring line;
	std::vector<std::wstring> lines;
	while (std::getline(infile, line))
	{
		lines.push_back(line);
	}
	return lines;
}
#endif

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#if (defined(WIN32) || defined(_WIN64)) && !defined(_MANAGED)

void TGMTfile::Move_File(const std::string fileNameFrom, const std::string fileNameTo)
{
	MoveFile((TGMTSTR)fileNameFrom.c_str(), (TGMTSTR)fileNameTo.c_str());
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::Move_File(const std::wstring fileNameFrom, const std::wstring fileNameTo)
{
	MoveFile((TGMTSTR)fileNameFrom.c_str(), (TGMTSTR)fileNameTo.c_str());
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::MoveFileAsync(const std::string fileNameFrom, const std::string fileNameTo)
{
	std::future<void> result = std::async([](const std::string from, const std::string to) 
	{
		MoveFile((TGMTSTR)from.c_str(), (TGMTSTR)to.c_str());
	}, fileNameFrom, fileNameTo);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::MoveFileAsync(const std::wstring fileNameFrom, const std::wstring fileNameTo)
{
	std::future<void> result = std::async([](const std::wstring from, const std::wstring to)
	{
		MoveFile((TGMTSTR)from.c_str(), (TGMTSTR)to.c_str());
	}, fileNameFrom, fileNameTo);
}

#endif

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::WriteResouceFileToDisk(std::string targetFile, int resouceID)
{
#ifdef WIN32
	HRSRC myResource = ::FindResource(NULL, MAKEINTRESOURCE(resouceID), RT_RCDATA);
	unsigned int myResourceSize = ::SizeofResource(NULL, myResource);
	ASSERT(myResourceSize > 0, "Can not load resouce");
	HGLOBAL myResourceData = ::LoadResource(NULL, myResource);
	void* pMyExecutable = ::LockResource(myResourceData);

	std::ofstream f(targetFile.c_str(), std::ios::out | std::ios::binary);
	f.write((char*)pMyExecutable, myResourceSize);
	f.close();
#endif
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::GetTempChar()
{
#ifdef WIN32
	std::string tempName = std::tmpnam(nullptr);
	int idx = tempName.find_last_of("\\");
	tempName = tempName.substr(idx);
	//remove dot
	tempName.erase(std::remove(tempName.begin(), tempName.end(), '.'), tempName.end());
	tempName.erase(std::remove(tempName.begin(), tempName.end(), '\\'), tempName.end());
	return tempName;
#else
    return "";
#endif
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::GetTempFilePath()
{
	return std::tmpnam(nullptr);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::GetTempDirPath()
{	
	std::string tempDirPath = GetSystemTempDirPath() + GetTempChar();
	CreateDir(tempDirPath);
	return tempDirPath;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::GetSystemTempDirPath()
{
#ifdef WIN32
	char systemTempDir[MAX_PATH];
	//GetTempPath(MAX_PATH, systemTempDir);
	return systemTempDir;
#else
    return "";
#endif
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::Delete_File(std::string fileName)
{
#ifdef WIN32
#ifdef _MANAGED
	DeleteFile((TGMTSTR)fileName.c_str());
#else
	std::future<void> result = std::async([](const std::string file) 
	{
		DeleteFile((TGMTSTR)file.c_str());
	}, fileName);
#endif
#endif
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::Delete_Dir(std::string dirName)
{
#ifdef WIN32
	std::system(("rmdir " + dirName + "/s /q").c_str());
#elif defined (OS_LINUX)
	std::string command = "rmdir -p " + dirName;
	const int dir_err = system(command.c_str());
	if (-1 == dir_err)
	{
		printf("Error deleting directory!n");
	}
#endif
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::Copy_File(const std::string fileNameFrom, const std::string fileNameTo)
{
#ifdef WIN32
#ifdef _MANAGED
	bool temp = false;
	CopyFile((TGMTSTR)fileNameFrom.c_str(), (TGMTSTR)fileNameTo.c_str(), temp);
#else
	std::future<void> result = std::async([](const std::string from, const std::string to) 
	{
		bool temp = false;
		CopyFile((TGMTSTR)from.c_str(), (TGMTSTR)to.c_str(), temp);
	}, fileNameFrom, fileNameTo);
#endif
#endif
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTfile::CorrectPath(std::string& path)
{
	if (path.substr(path.length() - 2) != "\\")
	{
		path += "\\";
	}
	if (path.substr(1,1) != ":")
	{
		path = GetCurrentDir() + "\\" + path;
	}
	return path;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int TGMTfile::GetFileSize(std::string filePath)
{
	std::ifstream in(filePath, std::ifstream::ate | std::ifstream::binary);
	return in.tellg();	
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#ifdef _MANAGED
System::String^ TGMTfile::CorrectPath(System::String^ path)
{
	if (path->Substring(path->Length - 2) != "\\")
	{
		path += "\\";
	}
	return path;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::MoveFileAsync(System::String^ fileNameFrom, System::String^ fileNameTo)
{
	ThreadStart^ mThread = gcnew ThreadStart(gcnew TGMTfileManaged(fileNameFrom, fileNameTo), &TGMTfileManaged::MoveFile);
	Thread^ newThread = gcnew Thread(mThread);
	newThread->Start();
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTfile::IsImage(System::String^ filePath)
{
	std::string sFilePath = TGMT::TGMTbridge::SystemStr2stdStr(filePath);
	return IsImage(sFilePath);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

bool TGMTfile::IsVideo(System::String^ filePath)
{
	std::string sFilePath = TGMT::TGMTbridge::SystemStr2stdStr(filePath);
	return IsVideo(sFilePath);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::OpenFolder(System::String^ folder)
{
	System::Diagnostics::Process::Start(folder);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

System::String^ TGMTfile::GetCurrentFolder()
{
	return System::IO::Path::GetDirectoryName(System::Reflection::Assembly::GetEntryAssembly()->Location);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::WriteAllText(System::String^ fileName, System::String^ text)
{
	System::Windows::Forms::SaveFileDialog^ ofd = gcnew System::Windows::Forms::SaveFileDialog();
	ofd->Filter = "Text file|*.txt";
	ofd->FileName = fileName;
	ofd->ShowHelp = true;
	ofd->Title = "Save text file";
	ofd->ShowDialog();
	System::String^ path = ofd->FileName;
	//File::WriteAllText(path, text);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::WriteAllText(std::string fileName, std::string text)
{
	System::String^ sfileName = TGMT::TGMTbridge::stdStrToSystemStr(fileName);
	System::String^ stext = TGMT::TGMTbridge::stdStrToSystemStr(text);

	WriteAllText(sfileName, stext);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::WriteResouceFileToDisk(System::String^ targetFile, System::String^ resourceFile)
{
	//Stream^ readStream = System::Reflection::Assembly::GetExecutingAssembly()->GetManifestResourceStream(resourceFile);
	//if (readStream != nullptr)
	//{
	//	FileStream^ writeStream = gcnew FileStream(targetFile, FileMode::Create);
	//	readStream->CopyTo(writeStream);
	//	readStream->Close();
	//	writeStream->Close(); // Required to flush the buffer & have non-zero filesize
	//}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTfile::TGMTfileManaged::MoveFile()
{
	if (System::IO::File::Exists(m_fileNameFrom) && !System::IO::File::Exists(m_fileNameTo))
		System::IO::File::Move(m_fileNameFrom, m_fileNameTo);
};
#endif