// dll_clr.h

#pragma once

#include "dll_cpp.h"

using namespace System;

namespace dll_clr {

	public ref class DllClr
	{
		// TODO:  �ڴ˴���Ӵ���ķ�����
		public:
			int Add(int a, int b) {
				Cdll_cpp cpp;
				return cpp.Add(a, b);
			}

			long Fibonacci(long num)
			{
				Cdll_cpp cpp;
				return cpp.Fibonacci(num);
			}

			//�׳�
			long Factorial(long num)
			{
				Cdll_cpp cpp;
				return cpp.Factorial(num);
			}
	};
}
