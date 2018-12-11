#include "TGMTdebugger.h"
#ifdef WIN32
#include <windows.h>
#include <Dbghelp.h>
#include <tchar.h>
#endif
#include <time.h>
#include <map>
#include "TGMTfile.h"
#include <algorithm>
#include <stdio.h>
#include <string.h>
#ifndef _MANAGED
#include <future>
#endif
#ifdef OS_LINUX
#include <stdarg.h>
#include <string.h>
#include <stdio.h>
#endif
static std::map<std::string, clock_t > tasksTime;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

#define FOREGROUND_BLUE      0x0001 // text color contains blue.
#define FOREGROUND_GREEN     0x0002 // text color contains green.
#define FOREGROUND_RED       0x0004 // text color contains red.
#define FOREGROUND_INTENSITY 0x0008 // text color is intensified.
#define BACKGROUND_BLUE      0x0010 // background color contains blue.
#define BACKGROUND_GREEN     0x0020 // background color contains green.
#define BACKGROUND_RED       0x0040 // background color contains red.
#define BACKGROUND_INTENSITY 0x0080 // background color is intensified.
#define DEBUG_OUT_BUFFER_SIZE			(64*1024)
#define STD_OUTPUT_HANDLE   ((DWORD)-11)

void debug_out(int color, const char* fmt, ...)
{
#if defined(WIN32) || defined(OS_LINUX)
	char str[DEBUG_OUT_BUFFER_SIZE];

	va_list arg_list;

	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);

	if (str[0] == 0 || str[strlen(str) - 1] != '\n')
	{
		strcat(str, "\n");
	}
#endif

#if defined(OS_LINUX)
	printf("\n%s", str);
#endif

#ifdef WIN32
#ifdef MANAGED
	Console::WriteLine(TGMTbridge::stdStrToSystemStr(str));
#else
	OutputDebugStringA(str);

	HANDLE console = nullptr;
	int defaultAttributes;
	if (color != 0)
	{
		console = GetStdHandle(STD_OUTPUT_HANDLE);
		CONSOLE_SCREEN_BUFFER_INFO csbi;
		GetConsoleScreenBufferInfo(console, &csbi);
		defaultAttributes = csbi.wAttributes;
	}

	switch (color)
	{
	case 1: //red
		SetConsoleTextAttribute(console, FOREGROUND_RED | FOREGROUND_INTENSITY);
		break;

	case 2: // yellow
		SetConsoleTextAttribute(console, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_INTENSITY);
		break;

	case 3: // green
		SetConsoleTextAttribute(console, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
		break;

	case 4: // blue
		SetConsoleTextAttribute(console, FOREGROUND_BLUE | FOREGROUND_INTENSITY);
		break;
	}
	
	printf("%s", str);

	if (color != 0)
	{
		SetConsoleTextAttribute(console, defaultAttributes);
	}
#endif
#endif
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void StartCountTime(char* taskName)
{
	tasksTime[taskName] = clock();
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

int StopCountTime(char* taskName)
{
	clock_t startTime = tasksTime.at(taskName);
	tasksTime.erase(taskName);
	int deltaTime = clock() - startTime;
	return deltaTime;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

int StopAndPrintCountTime(char* taskName)
{
	int deltaTime = StopCountTime(taskName);
	PrintMessageYellow("%s elapsed time: %d ms \n", taskName, deltaTime);
	return deltaTime;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void TGMTSetConsoleTitle(const char* fmt, ...)
{
#ifdef WIN32
	va_list arg_list;
	char str[DEBUG_OUT_BUFFER_SIZE];

	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
	SetConsoleTitleA(str);
#else
	va_list arg_list;
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
	printf("\n%s", str);
#endif
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void WriteLog(char* fileName, char* fmt, ...)
{
#ifdef WIN32
	va_list arg_list;
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
#else
	char str[DEBUG_OUT_BUFFER_SIZE];
#endif
	if (str[0] == 0 || str[strlen(str) - 1] != '\n')
	{
		strcat(str, "\n");
	}
	TGMTfile::WriteToFile(fileName, GetCurrentDateTime(false) + ": " + str);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string GetCurrentDateTime(bool removeSpecialCharacter)
{
	time_t     now = time(0);
	struct tm  tstruct;
	char       buf[80];
	tstruct = *localtime(&now);
	strftime(buf, sizeof(buf), "%Y-%m-%d.%X", &tstruct);
	if (removeSpecialCharacter)
	{
		std::string temp = buf;
		std::replace(temp.begin(), temp.end(), ':', '-');
		return temp;
	}

	return buf;
}
#ifdef WIN32
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Example uses: ShowMessageBoxW(L"title here", L"Message here");
void ShowMessageBoxW(std::wstring title, std::wstring msg)
{
	MessageBoxW(GetActiveWindow(), msg.c_str(), title.c_str(), MB_OK | MB_ICONINFORMATION);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void ShowMessageBox(char* title, char* fmt, ...)
{
	va_list arg_list;
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
	MessageBoxA(GetActiveWindow(), str, title, MB_OK | MB_ICONINFORMATION);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

void ShowErrorBox(char* title, char* fmt, ...)
{
	va_list arg_list;
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
	MessageBoxA(GetActiveWindow(), str, title, MB_OK | MB_ICONERROR);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Example uses: ShowErrorBoxW(L"title here", L"Message here");
void ShowErrorBoxW(std::wstring title, std::wstring msg)
{
	const wchar_t* _title = title.c_str();
	const wchar_t* _msg = msg.c_str();
	MessageBoxW(GetActiveWindow(), _msg, _title, MB_OK | MB_ICONERROR);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////

typedef BOOL(WINAPI *MINIDUMPWRITEDUMP)(HANDLE hProcess, DWORD dwPid, HANDLE hFile, MINIDUMP_TYPE DumpType, CONST PMINIDUMP_EXCEPTION_INFORMATION ExceptionParam, CONST PMINIDUMP_USER_STREAM_INFORMATION UserStreamParam, CONST PMINIDUMP_CALLBACK_INFORMATION CallbackParam);

LONG WINAPI CreateMinidump(struct _EXCEPTION_POINTERS* apExceptionInfo)
{
	HMODULE mhLib = ::LoadLibrary(_T("dbghelp.dll"));
	MINIDUMPWRITEDUMP pDump = (MINIDUMPWRITEDUMP)::GetProcAddress(mhLib, "MiniDumpWriteDump");

	HANDLE  hFile = ::CreateFile(_T("core.dmp"), GENERIC_WRITE, FILE_SHARE_WRITE, NULL, CREATE_ALWAYS,
		FILE_ATTRIBUTE_NORMAL, NULL);

	_MINIDUMP_EXCEPTION_INFORMATION ExInfo;
	ExInfo.ThreadId = ::GetCurrentThreadId();
	ExInfo.ExceptionPointers = apExceptionInfo;
	ExInfo.ClientPointers = FALSE;

	_MINIDUMP_TYPE dumpType = (_MINIDUMP_TYPE)(MiniDumpWithFullMemory | MiniDumpWithFullMemoryInfo | MiniDumpWithThreadInfo);
	pDump(GetCurrentProcess(), GetCurrentProcessId(), hFile, dumpType, &ExInfo, NULL, NULL);
	::CloseHandle(hFile);
	return EXCEPTION_CONTINUE_SEARCH;
}
#endif
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

#ifdef LIB
void ShowAssertManaged(const char* fmt, ...)
{
	char str[DEBUG_OUT_BUFFER_SIZE];
#ifdef WIN32
	va_list arg_list;

	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
#endif
	if (str[0] == 0 || str[strlen(str) - 1] != '\n')
	{
		strcat(str, "\n");
	}
#ifdef WIN32
	ShowErrorBox("TGMT error", str);
#else
	printf("%s", str);
#endif

}

#endif