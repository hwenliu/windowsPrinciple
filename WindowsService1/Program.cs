using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            /*
            try
            {
                WebServiceHost _serviceHost = null;

                //PersonInfoQueryServices service = new PersonInfoQueryServices();

                IServer service = new MyServer();
                Uri baseAddress = new Uri(MyParameter.Get().uri);

                //使用新的方式
                _serviceHost = new WebServiceHost(service, baseAddress);
                _serviceHost.Open();
                //Console.WriteLine("Web服务已开启...");
                //Console.WriteLine("输入任意键关闭程序！");
                MyLog.Write("Web服务已开启...");
                Console.ReadKey();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Web服务开启失败：{0}\r\n{1}", ex.Message, ex.StackTrace);
                MyLog.Write("Web服务开启失败:");
                MyLog.Write(ex.Message);
                MyLog.Write(ex.StackTrace);
            }
            */
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
            
        }
    }
}
