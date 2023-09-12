using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializeTest
{
    class Serialize
    {
        private Serialize() { }

        private static Serialize instance;
        public static Serialize Instance
        {
            get
            {
                if (instance == null)
                    instance = new Serialize();
                return instance;
            }
        }

        public void WriteToBinary<T>(String path, T t)
        {
           
            //创建一个格式化程序实例
            IFormatter formatter = new BinaryFormatter();
            try
            {
                //创建一个文件流,如果D盘目录下没有就会自动创建一个此文件
                Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, t);
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public T ReadFromBinary<T>(String path)
        {
 
            //创建一个格式化程序的实例
            IFormatter foramtter = new BinaryFormatter();
            Stream destream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            return (T)foramtter.Deserialize(destream);
            //Console.WriteLine(stillme.displayInfo());
            //Console.WriteLine("");
        }

        public void Write(String path, Person t)
        {
            //创建一个格式化程序实例
            XmlSerializer formatter = new XmlSerializer(t.GetType());
            //序列化
            try
            {
                using (Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                    formatter.Serialize(stream, t);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Person Read(String path)
        {
            Person p = new Person();
            XmlSerializer formatter = new XmlSerializer(p.GetType());
            //反序列化
            try
            {
                using (Stream destream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    p =(Person)formatter.Deserialize(destream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return p;
        }

        public void WriteXml<T>(String path, T t)
        {
            //创建一个格式化程序实例
            XmlSerializer formatter = new XmlSerializer(t.GetType());
            //序列化
            try
            {
                using (Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                    formatter.Serialize(stream, t);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public T ReadXml<T>(String path)
        {
            //Person p = new Person();
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            //反序列化
            try
            {
                using (Stream destream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (T)formatter.Deserialize(destream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }

        public String writeJson<T>(T t)
        {
            string str = JsonConvert.SerializeObject(t);
            return str;
        }

        public T readJson<T>(String str)
        {
            T x = JsonConvert.DeserializeObject<T>(str);
            return x;
        }


    }
}
