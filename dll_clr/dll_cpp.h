// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� DLL_CPP_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// DLL_CPP_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef DLL_CPP_EXPORTS
#define DLL_CPP_API __declspec(dllexport)
#else
#define DLL_CPP_API __declspec(dllimport)
#endif

// �����Ǵ� dll_cpp.dll ������
class DLL_CPP_API Cdll_cpp {
public:
	Cdll_cpp(void);
	// TODO:  �ڴ�������ķ�����

	//�ӷ�
	int Add(int a, int b)
	{
		return a + b;
	}

	//쳲���������F(1)=1��F(2)=1, F(n)=F(n-1)+F(n-2)
	long Fibonacci(long num)
	{
		if (num == 1 || num == 2)
			return 1;

		return Fibonacci(num - 1) + Fibonacci(num - 2);
	}

	//�׳�
	long Factorial(long num)
	{
		long faresult = 1;
		if (num > 1)
		{
			for (int i = 1; i <= num; i++)
			{
				faresult = faresult * i;
			}
		}
		return (faresult);
	}
};

extern DLL_CPP_API int ndll_cpp;

DLL_CPP_API int fndll_cpp(void);
