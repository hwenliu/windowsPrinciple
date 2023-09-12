using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        WebServiceHost _serviceHost = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {

                //PersonInfoQueryServices service = new PersonInfoQueryServices();

                IServer service = new MyServer();
                Uri baseAddress = new Uri(MyParameter.Get().uri);

                //使用新的方式
                _serviceHost = new WebServiceHost(service, baseAddress);
                _serviceHost.Open();
                //Console.WriteLine("Web服务已开启...");
                //Console.WriteLine("输入任意键关闭程序！");
                MyLog.Write("Web服务已开启...");
                //Console.ReadKey();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Web服务开启失败：{0}\r\n{1}", ex.Message, ex.StackTrace);
                //MyLog.Write("Web服务开启失败:");
                //MyLog.Write(ex.Message);
                //MyLog.Write(ex.StackTrace);
            }
        }

        protected override void OnStop()
        {
            try
            {
                if (_serviceHost != null && _serviceHost.State == System.ServiceModel.CommunicationState.Opened)
                    _serviceHost.Close();

                MyLog.Write("Web服务关闭");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Web服务开启失败：{0}\r\n{1}", ex.Message, ex.StackTrace);
                MyLog.Write("Web服务关闭失败:");
                MyLog.Write(ex.Message);
                MyLog.Write(ex.StackTrace);
            }
        }
    }
}
