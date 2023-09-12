using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public class MyLog
    {
        private string LogFileName = @"log.txt";
        /// <summary>
        /// The single object.
        /// </summary>
        private static MyLog _log;

        /// <summary>
        /// Whether the log is enabled.
        /// </summary>
        private static bool enabled;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static MyLog()
        {
            enabled = true;
            _log = new MyLog();
        }

        /// <summary>
        /// The writer to the log file.
        /// </summary>
        StreamWriter writer;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MyLog()
        {
            string str = System.Environment.CurrentDirectory;
            // 获取和设置当前目录（即该进程从中启动的目录）的完全限定路径。
            //result: X:\xxx\xxx(.exe文件所在的目录)

            //string str = System.AppDomain.CurrentDomain.BaseDirectory;
            // 获取当前 Thread 的当前应用程序域的基目录，它由程序集冲突解决程序用来探测程序集。
            //result: X:\xxx\xxx\ (.exe文件所在的目录 + " \ ")

            //string currentDir = System.AppDomain.CurrentDomain.BaseDirectory;
            //string logFile = currentDir + "log.txt";

            string fileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + LogFileName;
            writer = new StreamWriter(fileName, false, new UTF8Encoding());
        }

        /// <summary>
        /// Write a line to the log file.
        /// </summary>
        /// <param name="line">The text line to write.</param>
        public static void Write(string line)
        {
            if (!enabled)
                return;

            _log.writer.WriteLine(MyDateTimeUtil.GetNowDateTime() + " " + line);
            _log.writer.Flush();
        }

        /// <summary>
        /// Enable or disable the log.
        /// </summary>
        /// <param name="e">Enable or disable.</param>
        public static void Enable(bool e)
        {
            enabled = e;
        }
    }
}
