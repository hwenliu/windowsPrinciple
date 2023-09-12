using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeTest
{
    [Serializable]
    public class Person
    {
        public string sno { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public string displayInfo()
        {
            return "我的学号是:" + sno + "\n我的名字是:" + name + "\n我的性别为:" + sex + "\n我的年龄:" + age + "\n";
        }
    }

    public class Student
    {
        public string sno { get; set; }
        public string name { get; set; }

        public string displayInfo()
        {
            return "我的学号是:" + sno + "\n我的名字是:" + name + "\n";
        }
    }
}
