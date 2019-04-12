using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebAPI.Utilities
{
    public static class Clscommon
    {
        public static string LogFolderpath
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings[ApplicationConstants.ConfigParameters.LogFolderpath]);
            }
            set { }
        }

        public static string LogFileName
        {
            get
            {
                return Convert.ToString(ConfigurationManager.AppSettings[ApplicationConstants.ConfigParameters.LogFileName]);
            }
            set { }
        }


        public static string connectionString 
        {
            get
            {
                return Convert.ToString(ConfigurationManager.ConnectionStrings[ApplicationConstants.ConnName.ConnectionString]);
            }
        }
    }
}
