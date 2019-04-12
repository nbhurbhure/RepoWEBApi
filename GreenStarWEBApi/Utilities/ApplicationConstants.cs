using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Utilities
{
    public static partial class ApplicationConstants
    {
        public struct Errors
        {
            public const String FunctionError = "Error occured. Function : in {0}, Class : {1}, Error Message : {2} Stack Trace : {3}";
            public const String ExecuteNonQueryError = "{0} : Error in executing query for insert/update command....";
            public const String ExecuteScalarError = "{0} : Error in executing scalar query on database....";
            public const String ExecuteDataRowError = "{0} : Error in fetching list of data row....";
            public const String FetchingConnStringError = "{0} :Error in fetching connection....";
            public const String OpeningConnError = "{0} :Error in opening database connection....";
            public const String ClosingConnError = "{0} :Error in closing connection....";
        }

        public struct ConnProvider
        {
            public const String SQL = "System.Data.SqlClient";
        }
        public struct ConnName
        {
            public const String ConnectionString = "connectionString";
        }

        public struct Logging
        {
            public const String Log = "WebApi";
            public const String Source = "WebApiServer";
        }

        public struct ConfigParameters
        {
            public static string LogFolderpath = "LogFolderpath";
            public static string LogFileName = "LogFileName"; 
        
        }
    }
}
