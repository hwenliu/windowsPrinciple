
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
using DeviceInterfaces;
using dll_csharp;
using MyInterfaces;

namespace WPFTest.UI.Chapter3
{
    /// <summary>
    /// C2_SY1.xaml 的交互逻辑
    /// </summary>
    public partial class C3_SY1 : ChildPage
    {
        public C3_SY1()
        {
            InitializeComponent();

        }

        private void btn1_Click_1(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox1.Text.Trim();
            string strText2 = textBox2.Text.Trim();
            string ret = ComTest.add("B218DF77-16A0-44E7-A1D7-79394D0EA674", "Simulation Transaction",int.Parse(strText1), int.Parse(strText2));
            textBox3.Text = String.Concat(ret);
        }



        private void btn2_Click_1(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox5.Text.Trim();
            string strText2 = textBox6.Text.Trim();

            /*
            string guid = "B218DF77-16A0-44E7-A1D7-79394D0EA674";
            ITransaction transaction = ComTest.CreateTransaction(guid, "");
            string ret = transaction.add(int.Parse(strText1), int.Parse(strText2));
            */

            string ret = ComTest.multi("D61A457C-DBEF-43DE-80F4-394703BD3D41", "User Transaction", int.Parse(strText1), int.Parse(strText2));
            textBox7.Text = String.Concat(ret);
        }

        private void btn11_Click_1(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox11.Text.Trim();
            string strText2 = textBox12.Text.Trim();
            //string ret = ComTest.add("B218DF77-16A0-44E7-A1D7-79394D0EA674", "Simulation Transaction", int.Parse(strText1), int.Parse(strText2));

            string _guid = "22222222-DBEF-43DE-80F4-394703BD3D41";
            Guid guid = new Guid(_guid);
            Type type = Type.GetTypeFromCLSID(guid);
            object compute = Activator.CreateInstance(type);
            ICompute iCompute = compute as ICompute;
            double ret = iCompute.add(double.Parse(strText1), double.Parse(strText2));


            textBox13.Text = String.Concat(ret);
        }
    }
}
