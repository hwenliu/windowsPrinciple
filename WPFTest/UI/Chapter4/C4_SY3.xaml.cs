﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Utils;

namespace WPFTest.UI.Chapter4
{
    /// <summary>
    /// C2_SY1.xaml 的交互逻辑
    /// </summary>
    public partial class C4_SY3 : ChildPage
    {

        public static Process cmdP;
        public static StreamWriter cmdStreamInput;
        private static StringBuilder cmdOutput = null;
        
        #region 定义常量消息值
        public const int TRAN_FINISHED = 0x501;
        public const int WM_COPYDATA = 0x004B;
     
        #endregion

        #region 定义结构体
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        #endregion

        //动态链接库引入
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
        IntPtr hWnd, // handle to destination window 
        int Msg, // message 
        int wParam, // first message parameter 
        ref COPYDATASTRUCT lParam // second message parameter 
        );

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);

        public C4_SY3()
        {
            InitializeComponent();

        }

        public C4_SY3(MainWindow parent)
        {
            InitializeComponent();
            this.parentWindow = parent;

        }

        //页面加载时，添加消息处理钩子函数
        private void ChildPage_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource hWndSource;
            WindowInteropHelper wih = new WindowInteropHelper(this.parentWindow);
            hWndSource = HwndSource.FromHwnd(wih.Handle);
            //添加处理程序 
            hWndSource.AddHook(MainWindowProc);

        }

        //钩子函数，处理所收到的消息
        private IntPtr MainWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_COPYDATA:
                    try
                    {
                        COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                        Type mytype = mystr.GetType();

                        COPYDATASTRUCT MyKeyboardHookStruct = (COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(COPYDATASTRUCT));
                        showComment(MyKeyboardHookStruct.lpData);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                case TRAN_FINISHED:
                    {
                        showComment(cmdOutput.ToString());
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return hwnd;
        }

        private void clearComments()
        {
            listBox1.Items.Clear();
            //textBox2.Text = "";
        }

        private void showComment(String comment)
        {
            if (MyStringUtil.isEmpty(comment)) {
                listBox1.Items.Add("");
                return;
            }

            listBox1.Items.Add(comment);
            //textBox2.Text = comment;
        }

        //定义回调
        private delegate void updateDelegate(object comment);
        public void update(object comment)
        {
            //showComment((string)comment);
            if (!listBox1.Dispatcher.CheckAccess())
            {
                //声明，并实例化回调
                updateDelegate d = update;
                //使用回调
                listBox1.Dispatcher.Invoke(d, comment);
            }
            else
            {
                showComment((string)comment);
            }

        }

        private void runCMD(object sender, RoutedEventArgs e)
        {
            clearComments();
            string strCmd = "getmac";
            if (!MyStringUtil.isEmpty(textBox1.Text))
            {
                strCmd = textBox1.Text.Trim();
            }
           
            cmdOutput = new StringBuilder("");
            
            cmdP = new Process();
            cmdP.StartInfo.FileName = "cmd.exe";
            cmdP.StartInfo.CreateNoWindow = true;
            cmdP.StartInfo.UseShellExecute = false;
            cmdP.StartInfo.RedirectStandardOutput = true;
            cmdP.StartInfo.RedirectStandardInput = true;
            
            cmdP.OutputDataReceived += new DataReceivedEventHandler(strOutputHandler);
            cmdP.Start();

            cmdStreamInput = cmdP.StandardInput;
            cmdStreamInput.WriteLine(strCmd);
            //cmdStreamInput.WriteLine("exit");
            cmdP.BeginOutputReadLine();
        }

        //如果有输出，则重定向至输出对象，并向窗口对象发送特定的消息WM_COPYDATA和封装数据COPYDATASTRUCT
        private  void strOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            cmdOutput.AppendLine(outLine.Data);

            update(outLine.Data);


            //通过查找窗口，封装数据，发送消息的方式来异步更新控件
            //通过FindWindow API的方式找到目标进程句柄，然后发送消息
            /*
            IntPtr WINDOW_HANDLER = FindWindow(null, "demo");

            if (WINDOW_HANDLER != IntPtr.Zero)
            {
                //IntPtr hwndThree = FindWindowEx(WINDOW_HANDLER, 0, null, "");

                COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                mystr.dwData = (IntPtr)0;
                if (MyStringUtil.isEmpty(outLine.Data))
                {
                    mystr.cbData = 0;
                    mystr.lpData = "";
                }
                else {
                    byte[] sarr = System.Text.Encoding.Unicode.GetBytes(outLine.Data);
                    mystr.cbData = sarr.Length + 1;
                    mystr.lpData = outLine.Data;
                }
                SendMessage(WINDOW_HANDLER, WM_COPYDATA, 0, ref mystr);
            }
            */

            /*
            //或者通过枚举进程的方式找到目标进程句柄，然后发送消息
            Process[] procs = Process.GetProcesses();
            foreach (Process p in procs)
            {
                if (p.ProcessName.Equals("WPFTest"))
                {
                    // 获取目标进程句柄
                    IntPtr hWnd = p.MainWindowHandle;

                    // 封装消息
                    byte[] sarr = System.Text.Encoding.Unicode.GetBytes(outLine.Data);
                    int len = sarr.Length;
                    COPYDATASTRUCT cds2;
                    cds2.dwData = (IntPtr)0;
                    cds2.cbData = len + 1;
                    cds2.lpData = outLine.Data;

                    // 发送消息
                    SendMessage(hWnd, WM_COPYDATA, 0, ref cds2);
                }
            }
            **/

        }

        private void closeCMD(object sender, RoutedEventArgs e)
        {
            cmdP.Close();
        }
    }
}
