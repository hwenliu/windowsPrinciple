// dll_cpp.cpp : 定义 DLL 应用程序的导出函数。
//


#include "stdafx.h"

//#define _CRT_SECURE_NO_WARNINGS

#include "dll_cpp.h"
#include "dll20180918.h"
#include "dll20190904.h"
#include "dll20210929.h"

#include <stdio.h>



int __stdcall testAdd(int a, int b) {
	return a + b;
}

int __stdcall testMulti(int a, int b) {
	return a * b;
}

int __stdcall testMinus(int a, int b) {
	return a - b;
}

int __stdcall testDiv(int a, int b) {
	return a / b;
}

int __stdcall testMax(int a, int b) {
	if (a > b)
		return a;
	else
		return b;
}

int __stdcall testMin(int a, int b) {
	if (a > b)
		return b;
	else
		return a;
}

int __stdcall testInt(int a, int &b) {
	b = a + 1;
	return 1;
}

int __stdcall testString(char* c, char* d) {

	printf("%s \r\n", c);

	const char* a = ",hello word!";

	strcpy(d, c);
	strcat(d, a);

	return 1;
	
}






