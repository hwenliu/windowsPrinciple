using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MyServer : IServer
    {
        public string sayHello()
        {
            return "hello";
        }

        public TestResponse sayJson(TestRequest test)
        {
            MyLog.Write(test.ToString());

            TestResponse res = new TestResponse();

            if (test.i == 1)
            {
                res.code = 200;
                res.message = test.s + "-" + test.d;
                MyLog.Write(res.message);
            }
            else
            {
                res.code = 500;
                res.message = "错误";
                MyLog.Write(res.message);
            }
            return res;
        }
    }
}
