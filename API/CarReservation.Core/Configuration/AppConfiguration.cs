using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Configuration
{
    public class AppConfiguration
    {
        private static string _deploymentURL = string.IsNullOrEmpty(ConfigurationManager.AppSettings["DeploymentURL"]) ? System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) : ConfigurationManager.AppSettings["DeploymentURL"].ToString();

        private static string _csvFilePath = string.IsNullOrEmpty(ConfigurationManager.AppSettings["CSVFilePath"]) ? @"C:\Users\tahir.hassan\Desktop\UserStatus_12-13-2016.csv" : ConfigurationManager.AppSettings["CSVFilePath"].ToString();

        public static string DeploymentURL
        {
            get { return _deploymentURL; }
        }

        public static string CSVFilePath
        {
            get { return _csvFilePath; }
        }
    }
}
