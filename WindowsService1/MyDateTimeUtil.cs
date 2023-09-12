using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public class MyDateTimeUtil
    {
        public static DateTime firstDate = new DateTime(1900, 1, 1, 0, 0, 0);


        public static String GetNowDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static String Format(DateTime dt, String format)
        {
            //return String.Format(format, dt);
            return dt.ToString(format, DateTimeFormatInfo.InvariantInfo);
        }



        
    }
}
