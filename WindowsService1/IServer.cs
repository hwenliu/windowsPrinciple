using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    [ServiceContract(Name = "IServices")]
    public interface IServer
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "IService/sayHello", BodyStyle = WebMessageBodyStyle.Bare, 
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string sayHello();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "IService/sayJson", BodyStyle = WebMessageBodyStyle.Bare, 
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        TestResponse sayJson(TestRequest test);
    }
}
