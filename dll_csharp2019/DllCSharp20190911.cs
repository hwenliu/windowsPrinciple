using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll_csharp2019
{
    public class DllCSharp20190911
    {

        //斐波那契数列F(1)=1，F(2)=1, F(n)=F(n-1)+F(n-2)
        public static long FibonacciF(long num)
        {
            if (num == 1 || num == 2)
                return 1;

            return FibonacciF(num - 1) + FibonacciF(num - 2);
        }
    }
}
