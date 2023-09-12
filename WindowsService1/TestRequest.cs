using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    [DataContract]
    public class TestRequest
    {
        [DataMember]
        public int i { get; set; }

        [DataMember]
        public double d { get; set; }

        [DataMember]
        public string s { get; set; }
    }
}
