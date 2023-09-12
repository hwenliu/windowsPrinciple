
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

using dll_csharp;

namespace WPFTest.UI.Chapter2
{
    /// <summary>
    /// C2_SY1.xaml 的交互逻辑
    /// </summary>
    public partial class C2_SY2 : ChildPage
    {
        public C2_SY2()
        {
            InitializeComponent();

        }

        private void btn1_Click_1(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox1.Text.Trim();
            string strText2 = textBox2.Text.Trim();
            int ret = DllTest.testAdd2(int.Parse(strText1), int.Parse(strText2));
            textBox3.Text = String.Concat(ret);
        }



        private void btn2_Click_1(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox5.Text.Trim();
            string strText2 = textBox6.Text.Trim();
            //int ret = DllTest.testMulti(int.Parse(strText1), int.Parse(strText2));

            int ret = DllTest.testMulti20211013(int.Parse(strText1), int.Parse(strText2));

            textBox7.Text = String.Concat(ret);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox8.Text.Trim();
            string strText2 = textBox9.Text.Trim();
            int ret = DllTest.testMinus(int.Parse(strText1), int.Parse(strText2));
            textBox10.Text = String.Concat(ret);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox11.Text.Trim();
            string strText2 = textBox12.Text.Trim();
            int ret = DllTest.testMax(int.Parse(strText1), int.Parse(strText2));
            textBox13.Text = String.Concat(ret);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox21.Text.Trim();
            string strText2 = textBox22.Text.Trim();
            int ret = DllTest.testMinXX(int.Parse(strText1), int.Parse(strText2));
            textBox23.Text = String.Concat(ret);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox31.Text.Trim();
            StringBuilder inSb = new StringBuilder();
            inSb.Append(strText1);

            StringBuilder retSb = new StringBuilder();
            
            int ret = DllTest.testStringXX(inSb, retSb);
            textBox32.Text = retSb.ToString();

            //失败
            //string retStr = "";
            //int ret = DllTest.testStringYY(strText1, ref retStr);
            //textBox32.Text = retStr;

        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox41.Text.Trim();
            int a = int.Parse(strText1);
            int b = 0;

            int ret = DllTest.testIntZz(a, ref b);
            textBox42.Text = String.Concat(b);
        }
    }
}
