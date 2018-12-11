#pragma once
#include <string>
#if defined(WIN32) ||  defined(_WIN64)
#include <windows.h>
#endif

void debug_out(int color, const char* fmt, ...);

void StartCountTime(char* taskName);
int StopCountTime(char* taskName);
int StopAndPrintCountTime(char* taskName);
void TGMTSetConsoleTitle(const char* fmt,...);
void WriteLog(char* fileName, char* fmt, ...);
std::string GetCurrentDateTime(bool removeSpecialCharacter = false);

#if defined(WIN32) ||  defined(_WIN64)
void ShowMessageBox(char* title, char* fmt, ...);
void ShowMessageBoxW(std::wstring title, std::wstring msg);
void ShowErrorBoxW(std::wstring title, std::wstring msg);
void ShowErrorBox(char* title, char* fmt, ...);

//create crash dump, using: 
//SetUnhandledExceptionFilter(CreateMinidump);
LONG WINAPI CreateMinidump(struct _EXCEPTION_POINTERS* apExceptionInfo);
#endif

#ifdef _DEBUG
#define DEBUG_OUT(...)						debug_out(0, __VA_ARGS__)
#define DEBUG_OUT_CON(...)					debug_out_con(__VA_ARGS__)
#define DEBUG_OUT_COLOR(c, ...)				debug_out(c, __VA_ARGS__)
#else
#define DEBUG_OUT(...)					
#define DEBUG_OUT_CON(...)				
#define DEBUG_OUT_COLOR(c, ...)			
#endif

#if defined(WIN32) ||  defined(_WIN64) || defined (OS_LINUX)
#define TODO(...)							debug_out(0, __VA_ARGS__)
#define PrintMessage(...)					debug_out(0, __VA_ARGS__)
#define PrintError(...)						debug_out(1, __VA_ARGS__)
#define PrintMessageYellow(...)				debug_out(2, __VA_ARGS__)
#define PrintSuccess(...)					debug_out(3, __VA_ARGS__)
#define PrintMessageGreen(...)				debug_out(3, __VA_ARGS__)
#define PrintMessageBlue(...)				debug_out(4, __VA_ARGS__)
#elif defined (ANDROID)
#define TODO(...)							
#define PrintMessage(...)					
#define PrintError(...)						
#define PrintMessageYellow(...)				
#define PrintSuccess(...)					
#define PrintMessageGreen(...)				
#define PrintMessageBlue(...)				
#endif


#ifdef LIB
void OutputDebug(std::string str);
void ShowAssertManaged(const char* fmt, ...);
#if defined(WIN32) ||  defined(_WIN64)
#define ASSERT(value,x,...) if(!(value)) \
{\
	ShowAssertManaged("%s(%d):\n" #x, __FILE__, __LINE__,__VA_ARGS__ );\
}
#else
#define ASSERT(value,x,...)
#endif
#else
#if defined(WIN32) ||  defined(_WIN64)
#define ASSERT(value,x,...) if(!(value)) \
{\
	debug_out(1,  "%s(%d):\n" #x, __FILE__, __LINE__,__VA_ARGS__); \
	__debugbreak(); \
}

#define CHECK(value,x,...) \
if(value) \
{\
	debug_out(3, #x " success", __VA_ARGS__); \
}\
else\
{\
	debug_out(1, #x " failed", __VA_ARGS__); \
	WriteLog("TestCaseLog.txt", "%s(%d) " #x " failed\n", __FILE__, __LINE__,__VA_ARGS__);\
}

#elif ANDROID || OS_LINUX
#define ASSERT(value,...)
#endif
#endif




#define START_COUNT_TIME StartCountTime
#define STOP_COUNT_TIME StopCountTime
#define STOP_AND_PRINT_COUNT_TIME StopAndPrintCountTime

#define SET_CONSOLE_TITLE(...) TGMTSetConsoleTitle(__VA_ARGS__);
