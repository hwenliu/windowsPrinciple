using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public class MyParameter
    {
        private const string ConfigFileName = @"App.config";

        public string default_ip = "127.0.0.1";
        public string default_port = "8899";

        public string uri = "";


        private static MyParameter _this;

        static MyParameter()
        {
            _this = new MyParameter();
        }

        public MyParameter()
        {

            string ip = getConfig("ip");
            string port = getConfig("port");
           

            if (ip==null || "".Equals(ip))
            {
                ip = default_ip;
            }

            if (port == null || "".Equals(port))
            {
                port = default_port;
            }

            uri = "http://" + ip + ":" + port;


        }

        public static MyParameter Get()
        {
            return _this;
        }


        private string getConfig(string key)
        {
            string fileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + ConfigFileName;
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = fileName;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key].Value == null ? "" : config.AppSettings.Settings[key].Value;
        }

        private Configuration OpenConfigFile()
        {
            var configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = ConfigFileName
            };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            return config;
        }

        


    }
}
