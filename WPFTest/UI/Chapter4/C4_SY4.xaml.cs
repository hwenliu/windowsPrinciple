
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
using System.Threading;

namespace WPFTest.UI.Chapter4
{
    /// <summary>
    /// C4_SY4.xaml 的交互逻辑
    /// </summary>
    public partial class C4_SY4 : ChildPage
    {

       
        public C4_SY4()
        {
            InitializeComponent();
           
        }

        public C4_SY4(MainWindow parent)
        {
            InitializeComponent();
            this.parentWindow = parent;

        }

        private void ChildPage_Loaded(object sender, RoutedEventArgs e)
        {
            ConsoleManager.Show();//打开控制台窗口
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
        private delegate void updateDelegate(string comment);
        public void update(string comment)
        {
            //showComment((string)comment);
            
            
            if (!listBox1.Dispatcher.CheckAccess())
            {
                //声明，并实例化回调
                //updateDelegate d = new updateDelegate(showComment);
                updateDelegate d = showComment;
                //使用回调
                listBox1.Dispatcher.Invoke(d, comment);
            }
            else
            {
                showComment(comment);
            }
            
            

        }

        //定义回调
        private delegate void setTextValueCallBack(String comment);
        //声明回调
        private setTextValueCallBack setCallBack;


        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            //获取正在运行的线程
            Thread thread = Thread.CurrentThread;
            //设置线程的名字
            thread.Name = "主线程";
            //获取当前线程的唯一标识符
            int id = thread.ManagedThreadId;
            //获取当前线程的状态
            System.Threading.ThreadState state = thread.ThreadState;
            //获取当前线程的优先级
            ThreadPriority priority = thread.Priority;
            string strMsg = string.Format("Thread ID:{0}\n" + "Thread Name:{1}\n" +
                "Thread State:{2}\n" + "Thread Priority:{3}\n", id, thread.Name,
                state, priority);

            Console.WriteLine(strMsg);
            //Console.ReadKey();

            showComment(strMsg);

        }

        /// <summary>
        /// 创建无参的方法
        /// </summary>
        void Thread1()
        {
            string strMsg = "这是无参的方法";
            Console.WriteLine(strMsg);
            update(strMsg);

            //使用回调
            //listBox1.Dispatcher.Invoke(setCallBack, comment);
        }

        class ThreadTest
        {
            private C4_SY4 parent;
            public ThreadTest(C4_SY4 _parent)
            {
                parent = _parent;
            }

            public void Thread2()
            {
                string strMsg = "这是一个个实例方法";
                Console.WriteLine(strMsg);
                //showComment(strMsg);
                parent.update(strMsg);
            }
        }

        void Thread5(object obj)
        {
            Console.WriteLine(obj);
            update((string)obj);
        }


        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            //实例化回调
            setCallBack = new setTextValueCallBack(showComment);

            //创建无参的线程
            Thread thread1 = new Thread(new ThreadStart(Thread1));
            //调用Start方法执行线程
            thread1.Start();

            //创建ThreadTest类的一个实例
            ThreadTest test = new ThreadTest(this);
            //调用test实例的MyThread方法
            Thread thread2 = new Thread(new ThreadStart(test.Thread2));
            //启动线程
            thread2.Start();

            //通过匿名委托创建
            Thread thread3 = new Thread(delegate () {
                String comment = "我是通过匿名委托创建的线程";
                //update("我是通过匿名委托创建的线程");
                listBox1.Dispatcher.Invoke(setCallBack, comment);
                //showComment(comment);
            }
            );
            thread3.Start();
            //通过Lambda表达式创建
            Thread thread4 = new Thread(() => update("我是通过Lambda表达式创建的委托"));
            thread4.Start();


            //通过ParameterizedThreadStart创建线程
            Thread thread5 = new Thread(new ParameterizedThreadStart(Thread5));
            //给方法传值
            thread5.Start("这是一个有参数的委托");
            
            //Console.ReadKey();
        }


        class BackGroundTest
        {
            private C4_SY4 parent;
            private int Count;
            public BackGroundTest(C4_SY4 _parent,int count)
            {
                this.parent = _parent;
                this.Count = count;
            }
            public void RunLoop()
            {
                //获取当前线程的名称
                string threadName = Thread.CurrentThread.Name;
                if (MyStringUtil.isEmpty(threadName))
                    threadName = "main thred";

                for (int i = 0; i < Count; i++)
                {
                    Console.WriteLine("{0}计数：{1}", threadName, i.ToString());
                    parent.update(threadName.ToString() + "计数:" + i.ToString());
                    //parent.showComment(threadName.ToString() + "完成计数");
                    //线程休眠2000毫秒
                    Thread.Sleep(2000);
                }
                Console.WriteLine("{0}完成计数", threadName);
                parent.update(threadName.ToString() + "完成计数");
                //parent.showComment(threadName.ToString() + "完成计数");
            }
        }

        //演示前台线程先结束，会自动结束后台线程（没有执行完的后台线程，不继续执行）
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            //演示前台、后台线程
            BackGroundTest background = new BackGroundTest(this,10);
            //background.RunLoop();

            
            //创建前台线程
            Thread fThread = new Thread(new ThreadStart(background.RunLoop));
            //给线程命名
            fThread.Name = "前台线程";

            /*
            BackGroundTest background1 = new BackGroundTest(this,20);
            //创建后台线程
            Thread bThread = new Thread(new ThreadStart(background1.RunLoop));
            bThread.Name = "后台线程";
            //设置为后台线程
            bThread.IsBackground = true;

            //启动线程
            fThread.Start();
            bThread.Start();
            */
            fThread.Start();

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            //演示前台、后台线程
            BackGroundTest background = new BackGroundTest(this, 10);
            //创建前台线程
            Thread fThread = new Thread(new ThreadStart(background.RunLoop));
            //给线程命名
            fThread.Name = "前台线程";


            BackGroundTest background1 = new BackGroundTest(this, 20);
            //创建后台线程
            Thread bThread = new Thread(new ThreadStart(background1.RunLoop));
            bThread.Name = "后台线程";
            //设置为后台线程
            //bThread.IsBackground = true;

            //启动线程
            fThread.Start();
            bThread.Start();
        }

        private void threadMethod6(Object obj)
        {
            Thread.Sleep(Int32.Parse(obj.ToString()));
            Console.WriteLine(obj + "毫秒任务结束");
            update(obj + "毫秒任务结束");
        }
        private void joinAllThread6(object obj)
        {
            Thread[] threads = obj as Thread[];
            foreach (Thread t in threads)
                t.Join();
            Console.WriteLine("所有的线程结束");
            update("所有的线程结束");
        }


        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            Thread thread1 = new Thread(threadMethod6);
            Thread thread2 = new Thread(threadMethod6);
            Thread thread3 = new Thread(threadMethod6);

            

            Thread joinThread = new Thread(joinAllThread6);
            joinThread.Start(new Thread[] { thread1, thread2, thread3 });

            thread1.Start(3000);
            thread2.Start(5000);
            thread3.Start(7000);
            
        }


        private void DoSomethingLong(string name)
        {

            Console.WriteLine($"****************DoSomethingLong {name} Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            update($"****************DoSomethingLong " + name + " Start " + Thread.CurrentThread.ManagedThreadId.ToString("00") + " " +  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "***************");
            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }
            Console.WriteLine($"****************DoSomethingLong {name}   End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {lResult}***************");
            update($"****************DoSomethingLong " + name + " End " + Thread.CurrentThread.ManagedThreadId.ToString("00") + "  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + lResult + "***************");

        }

        //线程同步方法
        private void btnSync_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            Console.WriteLine($"****************btnSync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            update($"****************btnSync_Click Start " + Thread.CurrentThread.ManagedThreadId.ToString("00")  +  " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "***************");
            int j = 3;
            int k = 5;
            int m = j + k;
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                this.DoSomethingLong(name);
            }
            Console.WriteLine($"****************btnSync_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            update($"****************btnSync_Click End " + Thread.CurrentThread.ManagedThreadId.ToString("00") + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "***************");


        }

        //线程异步方法
        private void btnAsync_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            Console.WriteLine($"***************btnAsync_Click Start {Thread.CurrentThread.ManagedThreadId}");
            update($"***************btnAsync_Click Start " + Thread.CurrentThread.ManagedThreadId);

            Action<string> action = this.DoSomethingLong;
            // 调用委托(同步调用)
            //action.Invoke("btnAsync_Click_1");

            // 异步调用委托
            //action.BeginInvoke("btnAsync_Click_2", null, null);

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                action.BeginInvoke(name, null, null);
            }

            Console.WriteLine($"***************btnAsync_Click End    {Thread.CurrentThread.ManagedThreadId}");
            update($"***************btnAsync_Click End " + Thread.CurrentThread.ManagedThreadId);

        }


        
        //用于异步回调时，回传返回值
        class StateObject
        {
            public String msg { get; set; }
        }
        //线程异步的回调方法，实现同步
        private void btnAsyncAdvanced_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            Console.WriteLine($"***************btnAsyncAdvanced_Click Start {Thread.CurrentThread.ManagedThreadId}");
            update($"***************btnAsyncAdvanced_Click Start " + Thread.CurrentThread.ManagedThreadId);

            Action<string> action = this.DoSomethingLong;

            //IAsyncResult asyncResult = null;

            // 定义一个回调，其中lamda表达式中的p为参数
            AsyncCallback callback = p =>
            {
                StateObject state = (StateObject)p.AsyncState;

                state.msg = "";

                Console.WriteLine($"到这里计算已经完成了。{Thread.CurrentThread.ManagedThreadId.ToString("00")}。");
                update($"到这里计算已经完成了。" + Thread.CurrentThread.ManagedThreadId.ToString("00") + ",p=" + state.msg + "。");
            };



            for (int i = 0; i < 5; i++)
            {
                StateObject state = new StateObject();
                state.msg = String.Format($"My Paramerter Value is {i}"); 
                string name = string.Format($"btnAsyncAdvanced_Click_{i}");
                action.BeginInvoke(name, callback, state);
                //asyncResult = action.BeginInvoke(name, callback, null);

            }

            Console.WriteLine($"***************btnAsyncAdvanced_Click End    {Thread.CurrentThread.ManagedThreadId}");
            update($"***************btnAsyncAdvanced_Click End " + Thread.CurrentThread.ManagedThreadId);

        }


        class AutoResetEventTest
        {
            private C4_SY4 parent;

            public AutoResetEvent event1 = new AutoResetEvent(false);
            public AutoResetEvent event2 = new AutoResetEvent(false);
            public AutoResetEvent event3 = new AutoResetEvent(false);

            public AutoResetEventTest(C4_SY4 _parent)
            {
                parent = _parent;
            }

            public void Method1()
            {
                parent.update("thread1 begin");
                Thread.Sleep(5000);
                parent.update("thread1 end");
                Console.WriteLine("thread1 end;");
                event1.Set();
            }

            public void Method2()
            {
                parent.update("thread2 begin");
                Thread.Sleep(2000);
                parent.update("thread2 end");
                Console.WriteLine("thread2 end;");
                event2.Set();
            }

            public void Method3()
            {
                parent.update("thread3 begin");
                Thread.Sleep(3000);
                parent.update("thread3 end");
                Console.WriteLine("thread3 end;");
                event3.Set();
            }

        }

        void autoResetEvent_waitAnyTest()
        {
            clearComments();

            AutoResetEventTest test = new AutoResetEventTest(this);
            Thread vThread1 = new Thread(new ThreadStart(test.Method1));
            vThread1.IsBackground = true;
            Thread vThread2 = new Thread(new ThreadStart(test.Method2));
            vThread2.IsBackground = true;
            Thread vThread3 = new Thread(new ThreadStart(test.Method3));
            vThread3.IsBackground = true;

            AutoResetEvent[] vEventInProgress = new AutoResetEvent[3]
            {
                test.event1,
                test.event2,
                test.event3
            };

            vThread1.Start();
            vThread2.Start();
            vThread3.Start();

            //WaitHandle.WaitAll(vEventInProgress, 8000);
            //update("全部收到信息，完成任务,current thread end;");

            int index = WaitHandle.WaitAny(vEventInProgress, 10000);
            
            
            while (index >=0) {
                if (index == 0)
                {
                    update("收到信息0，完成任务,current thread end;");
                    index = -1;
                }
                else if (index == 1)
                {
                    update("收到信息1，完成任务,current thread end;");
                    index = -1;
                }
                else if (index == 2) { 
                    update("收到信息2，完成任务,current thread end;");
                    index = -1;
                }
                else
                    index = AutoResetEvent.WaitAny(vEventInProgress, 1000);
            }
            

            update("收到任何一个信息，完成任务,current thread end;" + index);
            Console.WriteLine("收到任何一个信息，完成任务,current thread end;" + index);

            

            /*
            if (vThread1 != null)
                vThread1.Abort();
            if (vThread2 != null)
                vThread2.Abort();
            if (vThread3 != null)
                vThread3.Abort();
            */
        }


        void ok(object i)
        {
            AutoResetEvent reset = (AutoResetEvent)i;
            //update("程序往下执行。");
            Console.WriteLine("程序往下执行。");
            Thread.Sleep(1000);
            reset.Set();//设置为有信号。
        }

        void autoResetEvent_waitAllTest()
        {
            clearComments();

            AutoResetEvent[] AutoR = new AutoResetEvent[5];
            for (int i = 0; i < AutoR.Length; i++)
            {

                AutoR[i] = new AutoResetEvent(false);
                Thread td = new Thread(new ParameterizedThreadStart(ok));
                td.IsBackground = true;
                td.Start(AutoR[i]);
            }

            //WaitHandle.WaitAll(AutoR,10000);
            foreach (var v in AutoR)
            {
                v.WaitOne();
            }
           

            Console.WriteLine("全部收到信息，完成任务");
            //update("全部收到信息，完成任务");
        }


        private void autoResetEvent_waitOneTest()
        {
            Boolean leaveContext = true;
            AutoResetEvent mansig = new AutoResetEvent(false);

            bool signalled = mansig.WaitOne(9000, leaveContext);
            Console.WriteLine("AutoResetEvent After WaitOne " + signalled);
            if (signalled)
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait AutoResetEvent released 1");
            else
            {
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait AutoResetEvent timeout 1");
            }

            signalled = mansig.WaitOne(9000, leaveContext);
            Console.WriteLine("AutoResetEvent After WaitOne " + signalled);
            if (signalled)
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait AutoResetEvent released 2");
            else
            {
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait AutoResetEvent timeout 2");
            }

            mansig.Set();
            signalled = mansig.WaitOne(9000, leaveContext);
            Console.WriteLine("AutoResetEvent After WaitOne" + signalled);
            if (signalled)
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait AutoResetEvent released 3");
            else
            {
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait AutoResetEvent timeout 3");
            }

            signalled = mansig.WaitOne(9000, leaveContext);
            Console.WriteLine("AutoResetEvent After WaitOne" + signalled);
            if (signalled)
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait AutoResetEvent released 4");
            else
            {
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait AutoResetEvent timeout 4");
            }
        }

        private void BtbAutoResetEvent(object sender, RoutedEventArgs e)
        {
            autoResetEvent_waitAnyTest();
            //autoResetEvent_waitAllTest();
            //autoResetEvent_waitOneTest();
        }

        class ManualResetEventTest
        {
            private C4_SY4 parent;

            public ManualResetEvent event4 = new ManualResetEvent(false);
            public ManualResetEvent event5 = new ManualResetEvent(false);
            public ManualResetEvent event6 = new ManualResetEvent(false);

            public ManualResetEventTest(C4_SY4 _parent)
            {
                parent = _parent;
            }

            public void Method4()
            {
                //event4.Reset();
                //parent.update("thread4 begin");
                Console.WriteLine("thread4 begin");
                Thread.Sleep(10000);
                //parent.update("thread4 end");
                Console.WriteLine("thread4 end");
                event4.Set();
            }

            public void Method5()
            {
                //event5.Reset();
                //parent.update("thread5 begin");
                Console.WriteLine("thread5 begin");
                Thread.Sleep(5000);
                //parent.update("thread5 end");
                Console.WriteLine("thread5 end");
                event5.Set();
            }

            public void Method6()
            {
                //event6.Reset();
                //parent.update("thread6 begin");
                Console.WriteLine("thread6 begin");
                Thread.Sleep(3000);
                //parent.update("thread6 end");
                Console.WriteLine("thread6 end");
                event6.Set();
            }
        }

            


        /*
         WaitHandle类用于线程的同步。WaitOne方法用于阻止当前线程，直到当前WaitHandle接收到信号。
            WaitOne(int, bool)方法是其中的一个重载。
            第一个参数很好理解，表示当前线程等待信号的超时时间，单位是ms。
            第二个参数表示等待之前是否退出上下文的同步域，true表示退出，false表示不退出
        */
         private void manualResetEvent_waitOneTest()
        {
            Boolean leaveContext = true;
            ManualResetEvent mansig = new ManualResetEvent(false);

            bool signalled = mansig.WaitOne(9000, leaveContext);
            Console.WriteLine("ManualResetEvent After WaitOne" + signalled);
            if (signalled)
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait ManualResetEvent released 1");
            else
            {
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait ManualResetEvent timeout 1");
            }

            mansig.Reset();
            signalled = mansig.WaitOne(9000, leaveContext);
            Console.WriteLine("ManualResetEvent After WaitOne" + signalled);
            if (signalled)
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait ManualResetEvent released 2");
            else
            {
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait ManualResetEvent timeout 2");
            }

            mansig.Set();
            signalled = mansig.WaitOne(9000, leaveContext);
            Console.WriteLine("ManualResetEvent After WaitOne" + signalled);
            if (signalled)
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait ManualResetEvent released 3");
            else
            {
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait ManualResetEvent timeout 3");
            }

            signalled = mansig.WaitOne(9000, leaveContext);
            Console.WriteLine("ManualResetEvent After WaitOne" + signalled);
            if (signalled)
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait ManualResetEvent released 4");
            else
            {
                update("Thread:" + Thread.CurrentThread.GetHashCode() + " Wait ManualResetEvent timeout 4");
            }
        }

        //WaitAll：等待指定数组中的所有元素收到信号
        //WaitAny：等待指定数组中的任一元素收到信号
        private void manualResetEvent_waitAnyTest()
        {
            ManualResetEventTest test = new ManualResetEventTest(this);
            Thread vThread1 = new Thread(new ThreadStart(test.Method4));
            Thread vThread2 = new Thread(new ThreadStart(test.Method5));
            Thread vThread3 = new Thread(new ThreadStart(test.Method6));

            ManualResetEvent[] vEventInProgress = new ManualResetEvent[3]
            {
                test.event4,
                test.event5,
                test.event6
            };

            vThread1.Start();
            vThread2.Start();
            vThread3.Start();

            int index = WaitHandle.WaitAny(vEventInProgress, 10000);
            //Console.WriteLine("current thread end;");
            //update("current thread end;");
            
            while (index >= 0)
            {
                if (index == 0)
                {
                    Console.WriteLine("current thread 4 end;");
                    vEventInProgress[0].Reset();
                    index = -1;
                }
                else if (index == 1)
                {
                    //update("current thread end;");
                    Console.WriteLine("current thread 5 end;");
                    vEventInProgress[1].Reset();
                    index = -1;
                    /*
                    if (vThread1 != null)
                        vThread1.Abort();
                    if (vThread2 != null)
                        vThread2.Abort();
                    if (vThread3 != null)
                        vThread3.Abort();
                    */
                }
                else if (index == 2)
                {
                    Console.WriteLine("current thread 6 end;");
                    vEventInProgress[2].Reset();
                    index = -1;
                }
                else
                    index = ManualResetEvent.WaitAny(vEventInProgress, 1000);
                    
            }
            
        }

        private void BtbManualResetEvent(object sender, RoutedEventArgs e)
        {
            clearComments();

            manualResetEvent_waitAnyTest();
            //manualResetEvent_waitOneTest();

        }

        private void BtbAutoAndManualResetEvent(object sender, RoutedEventArgs e)
        {
            EventWaitHandleDemo ewhd = new EventWaitHandleDemo(this);
            this.update("Result　=　{" + ewhd.Result(234).ToString() + "}");
            this.update("Result　=　{" + ewhd.Result(567).ToString() + "}");
        }

        class EventWaitHandleDemo
        {
            private C4_SY4 parent;
            double baseNumber;
            double firstTerm = 1, secondTerm = 2, thirdTerm =4;
            AutoResetEvent[] autoEvents;
            
            ManualResetEvent manualEvent;
            int manualEventFlag = 0;
            //产生随机数的类.
            Random random;

            //构造函数
            public EventWaitHandleDemo(C4_SY4 _parent)
            {
                parent = _parent;

                autoEvents = new AutoResetEvent[]
                {
                            new AutoResetEvent(false),
                            new AutoResetEvent(false),
                            new AutoResetEvent(false)
                };
                manualEvent = new ManualResetEvent(false);
            }

            //计算基数
            void CalculateBase(object stateInfo)
            {
                baseNumber = 10;
                //baseNumber = random.NextDouble();
                //指示基数已经算好.
                Thread.Sleep(10000);
                manualEvent.Set();
                Console.WriteLine("指示基数已经算好");
                //parent.update("指示基数已经算好");
            }
            //计算第一项
            void CalculateFirstTerm(object stateInfo)
            {
                //生成随机数
                double preCalc = random.NextDouble();
                
                //等待基数以便计算.
                Console.WriteLine("第一项，等待指示基数");
                //parent.update("第一项，等待指示基数");
                manualEvent.WaitOne();

                Thread.Sleep(2000);
                //通过preCalc和baseNumber计算第一项.
                //firstTerm = preCalc * baseNumber * random.NextDouble();
                firstTerm = 1 * baseNumber;
                //发出信号指示计算完成.
                autoEvents[0].Set();
                //parent.update("第一项，已经算好");
                Console.WriteLine("第一项，已经算好");
            }
            //计算第二项
            void CalculateSecondTerm(object stateInfo)
            {
                double preCalc = random.NextDouble();
                //等待基数以便计算.
                Console.WriteLine("第二项，等待指示基数"); 
                //parent.update("第二项，等待指示基数");
                manualEvent.WaitOne();
                //发出信号指示计算完成.
                Thread.Sleep(2000);
                //secondTerm = preCalc * baseNumber * random.NextDouble();
                secondTerm = 2 * baseNumber;
                autoEvents[1].Set();
                //parent.update("第二项，已经算好");
                Console.WriteLine("第二项，已经算好");
            }
            //计算第三项
            void CalculateThirdTerm(object stateInfo)
            {
                double preCalc = random.NextDouble();
                //等待基数以便计算.
                Console.WriteLine("第三项，等待指示基数");
                //parent.update("第三项，等待指示基数");
                manualEvent.WaitOne();
                
                Thread.Sleep(2000);
                //thirdTerm = preCalc * baseNumber * random.NextDouble();
                thirdTerm = 3 * baseNumber;
                //发出信号指示计算完成.
                autoEvents[2].Set();
                //parent.update("第三项，已经算好");
                Console.WriteLine("第三项，已经算好");
            }

            //计算结果
            public double Result(int seed)
            {

                random = new Random(seed);

                //同时计算
                ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateFirstTerm));
                ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateSecondTerm));
                ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateThirdTerm));
                ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateBase));

                //等待任何的信号.
                //parent.update("综合计算：等待任何信号");
                //WaitHandle.WaitAny(autoEvents);

                //等待所有的信号.
                Console.WriteLine("综合计算：等待所有信号");
                //parent.update("综合计算：等待所有信号");
                //WaitHandle.WaitAll(autoEvents);

                
                foreach (var v in autoEvents) { 
                    v.WaitOne();
                };
                
                Thread.Sleep(2000);
                double ret = firstTerm + secondTerm + thirdTerm;

                //重置信号，以便等待下一次计算.
                baseNumber = 1000;
                //manualEvent.Reset();
                //返回计算结果
                //parent.update("综合计算：完成");
                Console.WriteLine("综合计算：完成");

                
                return ret;
            }
        }


        private void produceConsume(object sender, RoutedEventArgs e)
        {
            /*
            ProducerConsumer pc = new ProducerConsumer(this);
            ProducerConsumer.SharedBuffer = 20;
            ProducerConsumer.mut = new Mutex(false, "Tr");
            ProducerConsumer.threadVec = new Thread[2];
            ProducerConsumer.threadVec[0] = new Thread(new ThreadStart(pc.Consumer));
            ProducerConsumer.threadVec[1] = new Thread(new ThreadStart(pc.Producer));
            ProducerConsumer.threadVec[0].Start();
            ProducerConsumer.threadVec[1].Start();
            ProducerConsumer.threadVec[0].Join();
            ProducerConsumer.threadVec[1].Join();
            */
        }


        public class ProducerConsumer
        {
            public static Mutex mut;
            public static Thread[] threadVec;
            public static int SharedBuffer;

            private C4_SY4 parent;
            public ProducerConsumer(C4_SY4 _parent)
            {
                parent = _parent;
            }

            public void Consumer()
            {
                while (true)
                {
                    int result;
                    mut.WaitOne();
                    if (SharedBuffer == 0)
                    {
                        Console.WriteLine("Consumed {0}: end of data\r\n", SharedBuffer);
                        parent.update("Consumed " + SharedBuffer + " : end of data\r\n");
                        mut.ReleaseMutex();
                        break;
                    }
                    if (SharedBuffer > 0)
                    { // ignore negative values
                        result = SharedBuffer;
                        Console.WriteLine("Consumed: {0}", result);
                        parent.update("Consumed: " + result);
                        mut.ReleaseMutex();
                    }
                }
            }

            public void Producer()
            {
                int i;
                for (i = 20; i >= 0; i--)
                {
                    mut.WaitOne();
                    Console.WriteLine("Produce: {0}", i);
                    parent.update("Produce: "  + i);
                    SharedBuffer = i;
                    mut.ReleaseMutex();
                    Thread.Sleep(1000);
                }
            }
        }

        
    }
}
