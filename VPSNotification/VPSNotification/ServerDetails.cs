using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace VPSNotification
{
    class ServerDetails
    {
        public static string servername { get; set; }
        public static string database { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public static string outputPath_Email { get; set; }
        public static string outputPath_Dispatch { get; set; }
        public static string reportPath { get; set; }

        public static void Set()
        {
            try
            {
                servername = ConfigurationManager.AppSettings["serverName"];
                database = ConfigurationManager.AppSettings["databaseName"];
                username = ConfigurationManager.AppSettings["userName"];
                password = ConfigurationManager.AppSettings["passWord"];
                outputPath_Email = ConfigurationManager.AppSettings["outputPath_Email"];
                outputPath_Dispatch = ConfigurationManager.AppSettings["outputPath_Dispatch"];
                reportPath = ConfigurationManager.AppSettings["reportPath"];
            }
            catch
            {
                throw;
            }
        }
    }
}
