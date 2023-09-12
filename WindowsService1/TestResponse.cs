using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    [DataContract]
    public class TestResponse
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public string message { get; set; }
    }
}
