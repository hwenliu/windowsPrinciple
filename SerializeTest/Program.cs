using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Person me = new Person
            {
                sno = "200719",
                name = "张三",
                sex = "男",
                age = 22
            };

            Serialize.Instance.WriteToBinary<Person>("D:/personInfo.txt", me);
            Person x = (Person)Serialize.Instance.ReadFromBinary<Person>("D:/personInfo.txt");
            Console.WriteLine(x.displayInfo());
            Console.WriteLine("");


            /*
            Serialize.Instance.Write("D:/personInfo.xml", me);
            Person x = Serialize.Instance.Read("D:/personInfo.xml");
            Console.WriteLine(x.displayInfo());
            Console.WriteLine("");
            */


            Student s = new Student {
                sno = "200719",
                name = "李四"
            };

            /*
            Serialize.Instance.WriteXml<Student>("D:/personInfo.xml", s);
            Student x = Serialize.Instance.ReadXml<Student>("D:/personInfo.xml");
            Console.WriteLine(x.displayInfo());
            */

            String str = Serialize.Instance.writeJson<Student>(s);
            Console.WriteLine(str);

            Student y = (Student)Serialize.Instance.readJson<Student>(str);
            Console.WriteLine(y.displayInfo());
            Console.WriteLine("");
        }
    }
}
