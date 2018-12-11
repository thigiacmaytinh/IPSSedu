#include "TGMTutil.h"
#include <sstream>
#include <string>
#ifdef WIN32
#include "windows.h"
#endif
#include "TGMTdebugger.h"
#include <algorithm>
#include <random>
#include <cctype>
#include <cwctype>
#ifdef OS_LINUX
#include <stdarg.h>
#include <string.h>
#include <stdio.h>
#endif
#define DEBUG_OUT_BUFFER_SIZE			(64*1024)

//TGMTutil::TGMTutil()
//{
//}
//
//
//TGMTutil::~TGMTutil()
//{
//}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTutil::IntToString(int number)
{
	std::stringstream ss;
	ss << number;
	return ss.str();
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::wstring TGMTutil::String2WString(const std::string s)
{
#if 0
	int len;
	int slength = (int)s.length() + 1;
	len = MultiByteToWideChar(CP_ACP, 0, s.c_str(), slength, 0, 0);
	wchar_t* buf = new wchar_t[len];
	MultiByteToWideChar(CP_ACP, 0, s.c_str(), slength, buf, len);
	std::wstring r(buf);
	delete[] buf;
	return r;
#else
	return std::wstring(s.begin(), s.end());
#endif
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTutil::WString2String(const std::wstring s)
{
	return std::string(s.begin(), s.end());
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTutil::FormatString(const char* fmt, ...)
{
	va_list arg_list;
	char str[DEBUG_OUT_BUFFER_SIZE];
	va_start(arg_list, fmt);
	vsnprintf(str, DEBUG_OUT_BUFFER_SIZE - 1, fmt, arg_list);
	return str;

}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef ANDROID

#ifdef UNICODE
std::string TGMTutil::GetParameter(int argc, wchar_t* argv[], char* key, char* defaultValue)
#else
std::string TGMTutil::GetParameter(int argc, char* argv[], char* key, char* defaultValue)
#endif

{
	if (argv[0] == nullptr)
		return defaultValue;
	
	for (int i = 1; i < argc; i++)
	{
		if (strcmp((char*)argv[i], key) == 0)
		{
			if (argv[i + 1] != nullptr)
				return (char*)argv[i + 1];
			else
				return defaultValue;
		}
	}
	return defaultValue;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#ifdef UNICODE
bool TGMTutil::CheckParameterExist(int argc, wchar_t* argv[], char* key)
#else
bool TGMTutil::CheckParameterExist(int argc, char* argv[], char* key)
#endif
{
	if (TGMTutil::GetParameter(argc, argv, key) == "")
	{
		PrintError("Missing value of parameter %s", key);
		return false;
	}

	return true;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#ifdef UNICODE
bool TGMTutil::CheckParameterAloneExist(int argc, wchar_t* argv[], char* key)
#else
bool TGMTutil::CheckParameterAloneExist(int argc, char* argv[], char* key)
#endif
{
	for (int i = 1; i < argc; i++)
	{
		if (strcmp((char*)argv[i], key) == 0)
		{		
			return true;
		}
	}
	return false;
}
#endif

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTutil::ReplaceString(std::string &inputStr, char oldchar, char newchar)
{
	std::replace(inputStr.begin(), inputStr.end(), oldchar, newchar);
	return inputStr;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<std::string> TGMTutil::SplitString(std::string str, char separator)
{
	std::vector<std::string> elems;
	std::stringstream ss;
	ss.str(str);
	std::string item;
	while (std::getline(ss, item, separator)) {
		elems.push_back(item);
	}
	return elems;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::vector<std::wstring> TGMTutil::SplitWString(std::wstring str, wchar_t separator)
{
	std::vector<std::wstring> elems;
	std::wstringstream ss;
	ss.str(str);
	std::wstring item;
	while (std::getline(ss, item,separator)) 
	{
		elems.push_back(item);
	}
	return elems;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int TGMTutil::GetRandomInt(int min, int max)
{
	std::mt19937 rng(std::random_device{}());
	std::uniform_int_distribution<> dist(min, max);
	return dist(rng);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTutil::JoinVectorString(std::vector<std::string> strings, char* separator)
{
	
	if (strings.size() == 0)
		return "";

	std::string result = "";

	for (size_t i = 0; i < strings.size(); i++)
	{
		result += strings[i];
		if (i < strings.size() - 1)
		{
			result += separator;
		}
	}
	return result;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTutil::RemoveString(std::string inputStr, char chrWantRemove)
{
	inputStr.erase(std::remove(inputStr.begin(), inputStr.end(), chrWantRemove), inputStr.end());
	return inputStr;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTutil::RemoveSpecialCharacter(std::string inputStr)
{
	inputStr.resize(std::remove_if(inputStr.begin(), inputStr.end(), [](char x) {return !isalnum(x) && !isspace(x); }) - inputStr.begin());
	return inputStr;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::wstring TGMTutil::ToLowerW(std::wstring str)
{
	std::transform(str.begin(), str.end(), str.begin(), ::tolower);
	return str;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTutil::ToLower(std::string str)
{
	std::transform(str.begin(), str.end(), str.begin(), ::tolower);
	return str;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

static inline void ltrim(std::string &s) 
{
	s.erase(s.begin(), std::find_if(s.begin(), s.end(), [](int ch) 
	{
		return !std::isspace(ch);
	}));
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

static inline void rtrim(std::string &s) 
{
	s.erase(std::find_if(s.rbegin(), s.rend(), [](int ch) 
	{
		return !std::isspace(ch);
	}).base(), s.end());
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

static inline void ltrim(std::wstring &s)
{
	s.erase(s.begin(), std::find_if(s.begin(), s.end(), [](int ch)
	{
		return !std::iswspace(ch);
	}));
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

static inline void rtrim(std::wstring &s)
{
	s.erase(std::find_if(s.rbegin(), s.rend(), [](int ch)
	{
		return !std::iswspace(ch);
	}).base(), s.end());
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::wstring TGMTutil::WTrim(std::wstring str)
{
	ltrim(str);
	rtrim(str);
	return str;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////

std::string TGMTutil::Trim(std::string str)
{
	ltrim(str);
	rtrim(str);
	return str;
}