using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utils;

namespace WPFTest.UI.Chapter4
{
    /// <summary>
    /// C4_SY7.xaml 的交互逻辑
    /// </summary>
    public partial class C4_SY7 : ChildPage
    {   
        int curCnt   = 0;
        int totalCnt = 0;
        int remainedCnt = 0;
        static Mutex mutex = new Mutex();
        const int BUFFER_SIZE = 20;
        static Semaphore produce = new Semaphore(BUFFER_SIZE, BUFFER_SIZE);
        static Semaphore consume = new Semaphore(0, BUFFER_SIZE);


        public C4_SY7()
        {
            InitializeComponent();
        }


        //生产者线程
        private void produceItem(string name, int rate)
        {
            while (true)
            {
                while (!produce.WaitOne(10))
                {
                    Console.WriteLine(name + " wants to produce an item, but the buffer is full");
                    update(name + " wants to produce an item, but the buffer is full");
                }
                mutex.WaitOne();
                ++curCnt;
                remainedCnt++;
                
                Dispatcher.Invoke(new Action(() => {
                    listBox1.Items.Add(name + " produces an item, totally " + curCnt + ", now there are " + remainedCnt + " items in the buffer");
                }));
                Console.WriteLine(name + " produces an item, totally " + curCnt + ", now there are " + remainedCnt + " items in the buffer");
                //update(name + " produces an item, now there are " + remainedCnt + " items");
                mutex.ReleaseMutex();
                consume.Release();
                Thread.Sleep(rate * 1000);

                if (curCnt >= totalCnt)
                {
                    //Thread.CurrentThread.Abort();
                    break;
                }
            }
        }

        //消费者线程
        private void consumeItem(string name, int rate)
        {
            while (true)
            {
                while (!consume.WaitOne(10))
                {
                    Console.WriteLine(name + " wants to consume an item, but the buffer is empty");
                }
                mutex.WaitOne();
                remainedCnt--;
                
                Dispatcher.Invoke(new Action(() => {
                    listBox1.Items.Add(name + " consumes an item, now there are " + remainedCnt + " items in the buffer");
                }));
                
                Console.WriteLine(name + " consumes an item, now there are " + remainedCnt + " items");
                //update(name + " consumes an item, now there are " + remainedCnt + " items");
                mutex.ReleaseMutex();
                produce.Release();
                Thread.Sleep(rate * 1000);

                if (curCnt >= totalCnt)
                {
                    //Thread.CurrentThread.Abort();
                    break;
                }
            }
        }

        //
        void ProducerConsumer(int producerCnt, int consumerCnt, int productRate, int consumeRate
            , int buffer_size, int _totalProductNum)
        {
            //MessageBox.Show("begin of producer consumer problem");
            clearComments();
            showComment("begin of producer consumer problem");
            totalCnt = _totalProductNum;
            
            Thread[] producers = new Thread[producerCnt];
            for (int i = 0; i < producerCnt; i++)
            {
                producers[i] = new Thread(() => { produceItem("producer" + i, productRate); });
                producers[i].IsBackground = true;
                producers[i].Start();
            }
            Thread.Sleep(2000);
            
            Thread[] consumers = new Thread[consumerCnt];
            for (int i = 0; i < consumerCnt; i++)
            {
                consumers[i] = new Thread(() => { consumeItem("consumer" + i, consumeRate); });
                consumers[i].IsBackground = true;
                consumers[i].Start();
            }

            /*
             for (int i = 0; i < producerCnt; i++)
                 producers[i].Join();

             for (int i = 0; i < consumerCnt; i++)
                 consumers[i].Join();
             **/
            Console.WriteLine("End of producer consumer problem");
            //showComment("End of producer consumer problem");
            //MessageBox.Show("End of producer consumer problem");
            
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            int producer_count = 0;
            producer_count = int.Parse(textBox1.Text.Trim());
            if (producer_count <= 0)
            {
                MessageBox.Show("生产者数量只能大于0");
                return;
            }

            int comsumer_count = 0;
            comsumer_count = int.Parse(textBox2.Text.Trim());
            if (comsumer_count <= 0)
            {
                MessageBox.Show("消费者数量只能大于0");
                return;
            }

            int productRate = 1;
            productRate = int.Parse(textBox3.Text.Trim());
            if (productRate <= 0)
            {
                MessageBox.Show("生产速率只能大于0");
                return;
            }


            int consumeRate = 1;
            consumeRate = int.Parse(textBox4.Text.Trim());
            if (consumeRate <= 0)
            {
                MessageBox.Show("消费速率只能大于0");
                return;
            }
            /*
            int buffer_size = 0;
            buffer_size = int.Parse(textBox5.Text.Trim());
            if (buffer_size <= 0)
            {
                MessageBox.Show("缓存只能大于0");
                return;
            }
            */

            int _totalProductNum = 0;
            _totalProductNum = int.Parse(textBox6.Text.Trim());
            if (_totalProductNum <= 0)
            {
                MessageBox.Show("产品总数只能大于0");
                return;
            }

            btn1.IsEnabled = false;
            ProducerConsumer(producer_count, comsumer_count,productRate,consumeRate, BUFFER_SIZE, _totalProductNum);
            btn1.IsEnabled = true;
        }


        //定义回调
        private delegate void updateDelegate(string comment);
        public void update(string comment)
        {
            //showComment((string)comment);
            if (!listBox1.Dispatcher.CheckAccess())
            {
                //声明，并实例化回调
                updateDelegate d = showComment;
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
            if (MyStringUtil.isEmpty(comment))
            {
                //listBox1.Items.Add("");
                return;
            }

            listBox1.Items.Add(comment);
        }
    }
}
