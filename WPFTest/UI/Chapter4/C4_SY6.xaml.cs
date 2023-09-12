
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
using System.IO.Pipes;
using System.Threading;
using System.Security.Principal;

namespace WPFTest.UI.Chapter4
{
    /// <summary>
    /// C4_SY6.xaml 的交互逻辑
    /// </summary>
    public partial class C4_SY6 : ChildPage
    {
        public static string input = "";
        public static string output = "";

        private const string PipeName = "testpipe";
        private Encoding encoding = Encoding.UTF8;

        private NamedPipeServerStream pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);

        private string messageStr = "";
        private Boolean isRunning = false;

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr wnd, int msg, IntPtr wP, ref COPYDATASTRUCT lParam);

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(IntPtr wnd, int msg, IntPtr wP, ref COPYDATASTRUCT lParam);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);


        public C4_SY6()
        {
            InitializeComponent();

        }

        public C4_SY6(MainWindow parent)
        {
            InitializeComponent();
            this.parentWindow = parent;

        }

        private void thread()
        {
            Thread t = new Thread(new ThreadStart(modify));
            t.Start();
        }

        private void modify()
        {
            listBox1.Items.Add("Hi!!!");
        }

        private void ChildPage_Loaded(object sender, RoutedEventArgs e)
        {

            new Thread(wait2).Start();

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

        private void clearComments()
        {
            listBox1.Items.Clear();
        }

        private void showComment(String comment)
        {
            if (MyStringUtil.isEmpty(comment)) {
                //listBox1.Items.Add("");
                return;
            }

            listBox1.Items.Add(comment);
        }


        private void wait1()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                pipeServer.BeginWaitForConnection((o) =>
                {
                    NamedPipeServerStream pServer = (NamedPipeServerStream)o.AsyncState;
                    pServer.EndWaitForConnection(o);
                    StreamReader sr = new StreamReader(pServer);
                    string total = "";
                    while (true)
                    {
                        string lineStr = sr.ReadLine();
                        if (MyStringUtil.isEmpty(lineStr))
                            break;
                        total = total + lineStr + "\n";
                    }
                    update(total);
                }, pipeServer);
            });
        }

        private void wait2()
        {
            try
            {
                while (true)
                {
                    pipeServer.WaitForConnection();

                    StreamReader sr = new StreamReader(pipeServer);

                    StreamWriter sw = new StreamWriter(pipeServer);
                    //sw.Write("connected");
                    //sw.Flush();

                    string total = "";
                    while (true)
                    {
                        string lineStr = sr.ReadLine();
                        if (lineStr == null || lineStr.Equals(""))
                            break;
                        total = total + lineStr + "\n";

                        sw.Write("received:" + lineStr);
                        sw.Flush();

                    }

                    update(total);

                    

                    /*
                    Dispatcher.Invoke(new Action(delegate
                    {
                        listBox1.Items.Add(total);
            
                    }));
                    **/

                    pipeServer.Disconnect();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            //sendMessage1();
            sendMessage2();
        }

        private void sendMessage1()
        {
            NamedPipeClientStream pipeClient;
            StreamWriter streamWriter;
            pipeClient = new NamedPipeClientStream("localhost", PipeName, PipeDirection.InOut,
                     PipeOptions.Asynchronous, TokenImpersonationLevel.None);
            try
            {
                if (!pipeClient.IsConnected)
                    pipeClient.Connect(1000);
                streamWriter = new StreamWriter(pipeClient);
                streamWriter.AutoFlush = true;
                string str = textBox1.Text;
                if (MyStringUtil.isEmpty(str))
                    str = "测试";
                streamWriter.WriteLine(str);
            }
            catch (Exception)
            {
            }
        }

        private void sendMessage2()
        {
         
            if (isRunning)
                return;
            isRunning = true;

            NamedPipeClientStream pipeClient = null;
            try
            {
                pipeClient = new NamedPipeClientStream("localhost", PipeName);

                pipeClient.Connect();

                StreamWriter sw = new StreamWriter(pipeClient);

                StreamReader sr = new StreamReader(pipeClient);

                string result = "";

                Dispatcher.Invoke(new Action(delegate
                {
                    string str = textBox1.Text;
                    if (MyStringUtil.isEmpty(str))
                        str = "测试";
                    result = str;
                }));

                sw.WriteLine(result);

                sw.Flush();


                //while (true)
                /*
                Thread.Sleep(3000);

                {
                    string lineStr = sr.ReadLine();
                    //if (lineStr == null || lineStr.Equals(""))
                    //    break;

                    update(lineStr);

                }
                */
                pipeClient.Close();

            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
            }
            isRunning = false;
        }
    

        private void testByThread()
        {
            Receiver r = new Receiver(this);
            Thread receiveDataThread = new Thread(r.ReceiveDataFromClient);
            receiveDataThread.IsBackground = true;
            receiveDataThread.Start();

            input = textBox1.Text;
            Sender s = new Sender();
            Thread pipeThread = new Thread(s.SendData);
            pipeThread.IsBackground = true;
            pipeThread.Start();

        }



        class Sender
        {
            public void SendData()
            {
                while (true)
                {
                    try
                    {
                        _pipeClient = null;
                        _pipeClient = new NamedPipeClientStream("localhost", "closePipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);
                        _pipeClient.Connect();
                        StreamWriter sw = new StreamWriter(_pipeClient);
                        string msg = input;
                        sw.WriteLine(msg);
                        sw.Flush();
                        Thread.Sleep(1000);
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            private static NamedPipeClientStream _pipeClient;
        }

        class Receiver
        {
            private C4_SY6 page;
            public Receiver(C4_SY6 _page)
            {
                page = _page;
            }

            public void ReceiveDataFromClient()
            {
                while (true)
                {
                    try
                    {
                        _pipeServer = new NamedPipeServerStream("closePipe", PipeDirection.InOut, 1);
                        _pipeServer.WaitForConnection();
                        StreamReader sr = new StreamReader(_pipeServer);
                        string recData = sr.ReadLine();
                        page.listBox1.Dispatcher.Invoke(new Action(delegate
                        {

                            page.listBox1.Items.Add(recData);

                        }));
                        
                        sr.Close();
                        _pipeServer.Close();
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            private static NamedPipeServerStream _pipeServer;
        }

       
    }
}
