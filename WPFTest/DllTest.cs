using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    class DllTest
    {
        [DllImport(@"../../../Debug/dll_cpp.dll", EntryPoint ="testAdd", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testAdd2(int a, int b);

        [DllImport(@"../../../Release/dll_cpp.dll", EntryPoint = "testMulti", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testMulti(int a, int b);

        [DllImport(@"dll_cpp.dll", EntryPoint = "testMinus", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testMinus(int a, int b);

        [DllImport(@"dll_cpp.dll", EntryPoint = "testMax", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testMax(int a, int b);

        [DllImport(@"../../../Debug/dll_cpp.dll", EntryPoint = "testMin", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testMinXX(int a, int b);

        [DllImport(@"dll_cpp.dll", EntryPoint = "testString", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testStringXX(StringBuilder c, [MarshalAs(UnmanagedType.LPStr)] StringBuilder d);

        [DllImport(@"dll_cpp.dll", EntryPoint = "testString", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testStringYY(String c, ref String d);

        [DllImport(@"../../../Debug/dll_cpp.dll", EntryPoint = "testInt", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testIntZz(int a, ref int b);

        [DllImport(@"../../../Debug/dll20211013.dll", EntryPoint = "testMulti", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testMulti20211013(int a, int b);

    }
}
