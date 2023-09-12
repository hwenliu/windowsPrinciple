using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebServiceClient
{
    public class WebServiceClient
    {
        public static void test() { 
            WebService_Employee.GetEmployeeInfoClient client = new WebService_Employee.GetEmployeeInfoClient();
            String ret = client.getEmployeeInfoByID("1");
            Console.WriteLine(ret);
        }
    }
}
