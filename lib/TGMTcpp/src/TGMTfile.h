#pragma once
#include <vector>
#include <string>

class TGMTfile
{	
	static std::string GetTempChar();
public:
	//TGMTfile(void);
	//~TGMTfile(void);

	
	static bool FileExist(std::string filePath);
	static bool DirExist(std::string dirName);

	static std::string GetFileName(std::string filePath);
	static std::string GetFileExtension(std::string filePath);
	static std::string GetDirName(std::string dirPath);
	static std::string GetFileNameWithoutExtension(std::string filePath);
	static std::string GetTempFilePath();
	static std::string GetTempDirPath();
	static std::string GetSystemTempDirPath();

	static int GetFileSize(std::string filePath);
	static void CreateDir(std::string dirName);
	static std::string GetCurrentDir();
	
	static std::string GetParentDir(std::string filePath);
	static std::vector<std::string> GetImageFilesInDir(std::string dirPath, bool searchAllChildDir = false);
	static std::vector<std::string> GetVideoFilesInDir(std::string dirPath, bool searchAllChildDir = false);
	static std::vector<std::string> GetFilesInDir(std::string dirPath, bool searchAllChildDir = false);
	static std::vector<std::string> GetChildDirInDir(std::string dirPath, bool searchAllChildDir = false);

	static bool IsDir(std::string filePath);
	static bool IsImage(std::string filePath);
	static bool IsVideo(std::string filePath);

	static void MoveFileAsync(const std::string fileNameFrom, const std::string fileNameTo);
	static void MoveFileAsync(const std::wstring fileNameFrom, const std::wstring fileNameTo);
	static void Copy_File(const std::string fileNameFrom, const std::string fileNameTo);
	static void WriteToFile(std::string fileName, std::string text, bool append = true);
#if (defined(WIN32) ||defined(WIN64)) && !defined(_MANAGED)
	static void WriteToFileAsync(std::string fileName, std::string text, bool append = true);
#endif
	static void WriteResouceFileToDisk(std::string targetFile, int resouceID);
	static void Delete_File(std::string fileName);
	static void Delete_Dir(std::string dirName);

	static std::string ReadAllText(std::string fileName);
	static std::vector<std::string> ReadAllLine(std::string fileName);
#if (defined(WIN32) ||defined(WIN64)) && defined(UNICODE)
	static std::vector<std::wstring> WReadAllLine(std::string fileName);
#endif

	static std::string CorrectPath(std::string& path);

#ifdef _MANAGED
	ref class TGMTfileManaged
	{
		System::String^ m_fileNameFrom;
		System::String^ m_fileNameTo;
	public: 
		TGMTfileManaged( System::String^ fileNameFrom, System::String^ fileNameTo)
		{
			m_fileNameFrom = fileNameFrom;
			m_fileNameTo = fileNameTo;
		};
		void MoveFile();
	};
	static System::String^ CorrectPath(System::String^ path);
	
	static void MoveFileAsync(System::String^ fileNameFrom, System::String^ fileNameTo);

	static bool IsImage(System::String^ filePath);
	static bool IsVideo(System::String^ filePath);
	static void OpenFolder(System::String^ folder);
	static System::String^ GetCurrentFolder();
	static void WriteAllText(System::String^ fileName, System::String^ text);
	static void WriteAllText(std::string fileName, std::string text);
	static void WriteResouceFileToDisk(System::String^ targetFile, System::String^ resourceFile);
#else	
	static void Move_File(const std::string fileNameFrom, const std::string fileNameTo);
	static void Move_File(const std::wstring fileNameFrom, const std::wstring fileNameTo);
#endif
};

