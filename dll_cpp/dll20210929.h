#pragma once
#ifndef __DLL_20210929__
#define __DLL_20210929__

extern "C" __declspec(dllexport) int __stdcall testMin(int a, int b);

extern "C" __declspec(dllexport) int __stdcall testInt(int a, int &b);

extern "C" __declspec(dllexport) int __stdcall testString(char* c, char* d);


#endif