
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

namespace WPFTest.UI.Chapter5
{
    /// <summary>
    /// C2_SY1.xaml 的交互逻辑
    /// </summary>
    public partial class C5_SY1 : ChildPage
    {

        public static Process cmdP;
        public static StreamWriter cmdStreamInput;

        FireAlarm globalFireAlarm = null;


        public C5_SY1()
        {
            InitializeComponent();

        }

        public C5_SY1(MainWindow parent)
        {
            InitializeComponent();
            this.parentWindow = parent;

        }

        private void ChildPage_Loaded(object sender, RoutedEventArgs e)
        {

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

     
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            OutStr.sw = new StreamWriter("dataout.txt");
            OutStr.sw.AutoFlush = true;


            //定义一个火情发生源类对象；
            FireAlarm myFireAlarm = new FireAlarm(this);

            globalFireAlarm = new FireAlarm(this);

            //定义一个火情处理类对象，并将源类对象作为参数传递给这个对象
            FireHandlerClass myFireHandler1 = new FireHandlerClass(this,myFireAlarm);
            
            FireWatcherClass myFireHandle2 = new FireWatcherClass(this, myFireAlarm);

            
            //发生一种火情，以事件机制执行
            myFireAlarm.activateFireAlarm("Kitchen", 3);
           

            myFireAlarm.fireEvent += new FireAlarm.FireEventHandler(MyWatchFire20211020);
            
            myFireAlarm.activateFireAlarm("Kitchen", 6);


            OutStr.sw.Close();

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            clearComments();

            OutStr.sw = new StreamWriter("dataout.txt");
            OutStr.sw.AutoFlush = true;

            //定义一个火情发生源类对象；
            FireAlarm myFireAlarm = new FireAlarm(this);
            //定义一个火情处理类对象，并将源类对象作为参数传递给这个对象
            //FireHandlerClass myFireHandler1 = new FireHandlerClass(myFireAlarm);
            FireWatcherClass myFireHandle2 = new FireWatcherClass(this,myFireAlarm);
            //发生一种火情，以事件机制执行
            myFireAlarm.activateFireAlarm("Kitchen", 3);
            myFireAlarm.activateFireAlarm("Kitchen", 6);

            String currentDate = "2022-01-01";
            myFireAlarm.ActivateFireAlarm(currentDate, "class room", 10);
            OutStr.sw.Close();
        }


        private void addEvent_Click(object sender, RoutedEventArgs e)
        {
            //FireAlarm myFireAlarm = new FireAlarm(this);
            //myFireAlarm.fireEvent += new FireAlarm.FireEventHandler(newHandler2022);
            globalFireAlarm.fireEvent += new FireAlarm.FireEventHandler(newHandler2022);
        }

        public void newHandler2022(object sender, FireEventArgs e)
        {
            Console.WriteLine("...");
        }

        private void removeEvent_Click(object sender, RoutedEventArgs e)
        {
            //FireAlarm myFireAlarm = new FireAlarm(this);
            //myFireAlarm.fireEvent -= new FireAlarm.FireEventHandler(newHandler2022);
            globalFireAlarm.fireEvent -= new FireAlarm.FireEventHandler(newHandler2022);
        }

        //信息输出类
        static class OutStr
        {
            public static StreamWriter sw;
        }

        //事件参数类
        public class FireEventArgs : EventArgs
        {
            public FireEventArgs(string _currentDate, string room, int ferocity)
            {
                this.room = room;
                this.ferocity = ferocity;
                if (MyStringUtil.isEmpty(_currentDate)) { 
                    this.currentDate = MyDateTimeUtil.GetNowTime24();
                }
                else
                {
                    this.currentDate = _currentDate;
                }
            }
            public string room; //火情发生地
            public int ferocity; //火情凶猛程度

            public String currentDate;
        }

        //事件源（发起者）类定义
        public class FireAlarm
        {
            private C5_SY1 parent;

            //将火情处理定义为FireEventHandler 代理(delegate) 类型，这个代理声明的事件的参数列表
            public delegate void FireEventHandler(object sender, FireEventArgs fe);

           

            //定义FireEvent 为FireEventHandler delegate 事件(event) 类型.
            public event FireEventHandler fireEvent;

            //激活事件的方法，创建了FireEventArgs 对象，发起事件，并将事件参数对象传递过去
            public void activateFireAlarm(string room, int ferocity)
            {
                FireEventArgs fireArgs = new FireEventArgs(null, room, ferocity);
                //执行对象事件处理函数指针，必须保证处理函数要和声明代理时的参数列表相同
                fireEvent(this, fireArgs);
            }

            public void ActivateFireAlarm(string currentDate, string room, int ferocity)
            {
                FireEventArgs fireArgs = new FireEventArgs(currentDate, room, ferocity);
                //执行对象事件处理函数指针，必须保证处理函数要和声明代理时的参数列表相同
                fireEvent(this, fireArgs);
            }

            public FireAlarm(C5_SY1 _parent)
            {
                parent = _parent;
                fireEvent += new FireEventHandler(parent.MyWatchFire20211020_2);

                //FireEvent += parent.MyWatchFire20211020_2;
            }
        }

        public void xxx(object s, FireEventArgs fe)
        {

        }

        //用于处理事件的类1：FireHandlerClass，这个类定义了实际事件处理代码
        class FireHandlerClass
        {
            private C5_SY1 parent;
            private FireAlarm fireAlarm;

            //事件处理类的构造函数使用事件源类作为参数
            public FireHandlerClass(C5_SY1 _parent,FireAlarm _fireAlarm)
            {
                parent = _parent;
                fireAlarm = _fireAlarm;
                //将事件处理的代理(函数指针) 添加到FireAlarm 类的FireEvent 事件中，当事件发生时，
                //就会执行指定的函数；
                fireAlarm.fireEvent += new FireAlarm.FireEventHandler(ExtinguishFire);
                fireAlarm.fireEvent += new FireAlarm.FireEventHandler(ExtinguishFire2);
            }
            //当起火事件发生时，用于处理火情的事件
    
            void ExtinguishFire(object sender, FireEventArgs fe)
            {
                OutStr.sw.WriteLine(" {0} 对象调用，灭火事件ExtinguishFire 函数.", sender.ToString());
                parent.showComment(sender.ToString() + " 对象调用，灭火事件ExtinguishFire 函数.");
                //根据火情状况，输出不同的信息.
                if (fe.ferocity < 2) { 
                    OutStr.sw.WriteLine(" 火情发生在{0}==={1}，主人浇水后火情被扑灭了",fe.currentDate, fe.room);
                    parent.showComment(" 火情发生在[" + fe.currentDate + "][" + fe.room + "]，主人浇水后火情被扑灭了");
                }
                else if (fe.ferocity < 5) {
                    OutStr.sw.WriteLine(" 主人正在使用灭火器处理{0}==={1} 火势.", fe.currentDate, fe.room);
                    parent.showComment(" 火情发生在[" + fe.currentDate + "][" + fe.room + "],主人正在使用灭火器处理 " + fe.room + " 火势.");
                }
                else { 
                    OutStr.sw.WriteLine("{0} 的火情无法控制，主人打119!", fe.room);
                    parent.showComment("火情发生在[" + fe.currentDate + "][" + fe.room + "]的火情无法控制，主人打119!");
                }
            }

            void ExtinguishFire2(object sender, FireEventArgs fe)
            {
                OutStr.sw.WriteLine(" {0} 对象调用，灭火事件ExtinguishFire2 函数，I don't care.", sender.ToString());
                parent.showComment(sender.ToString() + " 对象调用，灭火事件ExtinguishFire2 函数，，I don't care.");

            }

            /*
            void changeHander(String hander)
            {
                fireAlarm.FireEvent += new FireAlarm.FireEventHandler(hander);
            }
            */


        }

        //用于处理事件的类2：FireWatcherClass
        class FireWatcherClass
        {
            private C5_SY1 parent;

            //事件处理类的构造函数使用事件源类作为参数
            public FireWatcherClass(C5_SY1 _parent, FireAlarm fireAlarm)
            {
                parent = _parent;
                //将事件处理的代理(函数指针) 添加到FireAlarm 类的FireEvent 事件中，当事件发生
                //时，就会执行指定的函数；
                fireAlarm.fireEvent += new FireAlarm.FireEventHandler(WatchFire);
            }
            //当起火事件发生时，用于处理火情的事件
            void WatchFire(object sender, FireEventArgs fe)
            {
                OutStr.sw.WriteLine(" {0} 对象调用，群众发现火情WatchFire 函数.", sender.ToString());
                parent.showComment(sender.ToString() + " 对象调用，群众zai:" + fe.currentDate + "发现火情WatchFire 函数.");
                //根据火情状况，输出不同的信息.
                if (fe.ferocity < 2) { 
                    OutStr.sw.WriteLine(" 群众察到火情发生在{0}，主人浇水后火情被扑灭了", fe.room);
                    parent.showComment(" 群众察到火情发生在 " + fe.room + "，主人浇水后火情被扑灭了");
                }
                else if (fe.ferocity < 5) { 
                    OutStr.sw.WriteLine(" 群众察到火情发生在{0}，群众帮助主人{0} 火势.", fe.room);
                    parent.showComment(" 群众察到火情发生在 " + fe.room + "，群众帮助主人{0} 火势.");
                }
                else { 
                    OutStr.sw.WriteLine(" 群众无法控制{0} 的火情，消防官兵来到!", fe.room);
                    parent.showComment(" 群众无法控制 " + fe.room + " 的火情，消防官兵来到!");
                }
            }
        }


        void MyWatchFire20211020(object sender, FireEventArgs fe)
        {
            OutStr.sw.WriteLine(" {0} 对象调用，群众发现火情MyWatchFire20211020 函数.", sender.ToString());
            showComment(sender.ToString() + " 对象调用，群众发现火情MyWatchFire20211020 函数.");
            //根据火情状况，输出不同的信息.
            if (fe.ferocity < 2)
            {
                OutStr.sw.WriteLine(" 群众察到火情发生在{0}，主人浇水后火情被扑灭了", fe.room);
                showComment(" 群众察到火情发生在 " + fe.room + "，主人浇水后火情被扑灭了");
            }
            else if (fe.ferocity < 5)
            {
                OutStr.sw.WriteLine(" 群众察到火情发生在{0}，群众帮助主人{0} 火势.", fe.room);
                showComment(" 群众察到火情发生在 " + fe.room + "，群众帮助主人{0} 火势.");
            }
            else
            {
                OutStr.sw.WriteLine(" 群众无法控制{0} 的火情，消防官兵来到!", fe.room);
                showComment(" 群众无法控制 " + fe.room + " 的火情，消防官兵来到!");
            }
        }

        void MyWatchFire20211020_2(object sender, FireEventArgs fe)
        {
            OutStr.sw.WriteLine(" {0} 对象调用，群众发现火情MyWatchFire20211020_2 函数.", sender.ToString());
            showComment(sender.ToString() + " 对象调用，群众发现火情:" + fe.currentDate +  "MyWatchFire20211020_2 函数.");
            //根据火情状况，输出不同的信息.
            if (fe.ferocity < 2)
            {
                OutStr.sw.WriteLine(" 群众察到火情发生在{0}，主人浇水后火情被扑灭了", fe.room);
                showComment(" 群众察到火情发生在 " + fe.room + "，主人浇水后火情被扑灭了");
            }
            else if (fe.ferocity < 5)
            {
                OutStr.sw.WriteLine(" 群众察到火情发生在{0}，群众帮助主人{0} 火势.", fe.room);
                showComment(" 群众察到火情发生在 " + fe.room + "，群众帮助主人{0} 火势.");
            }
            else
            {
                OutStr.sw.WriteLine(" 群众无法控制{0} 的火情，消防官兵来到!", fe.room);
                showComment(" 群众无法控制 " + fe.room + " 的火情，消防官兵来到!");
            }
        }

    }
}
