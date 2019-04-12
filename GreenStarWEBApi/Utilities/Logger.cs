using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Utilities
{
    /// <summary>
    /// Logger class
    /// </summary>
    public class Logger
    {
        #region Methods

        /// <summary>
        /// Log folder path
        /// </summary>
        private static string LogFolder
        {
            get
            {
                String folderPath = string.Empty;
                try
                {
                    folderPath = Clscommon.LogFolderpath + "\\WebApi Logs\"";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                }
                catch
                {
                    folderPath = Clscommon.LogFolderpath;
                }

                return folderPath;
            }
        }

        /// <summary>
        /// Log file name
        /// </summary>
        private static string GetFileName()
        {
            StringBuilder fileName = new StringBuilder();
            if (string.IsNullOrEmpty(Clscommon.LogFileName))
            {
                fileName.Append(LogFolder + "\\Log_");
                fileName.Append(DateTime.Now.ToString("dd") + "_");
                fileName.Append(DateTime.Now.ToString("MM") + "_");
                fileName.Append(DateTime.Now.ToString("yyyy") + "_");
                fileName.Append(DateTime.Now.ToString("HH") + "_");
                fileName.Append(DateTime.Now.ToString("mm") + "_");
                fileName.Append(DateTime.Now.ToString("ss") + ".txt");
                Clscommon.LogFileName = fileName.ToString();
            }
            else
            {
                if (!IsTodaysLogFile(Clscommon.LogFileName))
                {
                   // Clscommon.LogFileName = string.Empty;
                   // GetFileName();
                }
                else
                {
                    FileInfo file = new FileInfo(Clscommon.LogFileName);
                    if (file.Length > 1048576)
                    {
                        Clscommon.LogFileName = string.Empty;
                        GetFileName();
                    }
                }
            }
            return Clscommon.LogFileName;
        }

        /// <summary>
        /// LogError
        /// Function to Log Error
        /// </summary>
        /// <param name="Exception">Exception</param>
        public static void LogError(Exception ex)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                WriteToEventLog(String.Format(ApplicationConstants.Errors.FunctionError,
                                  stackTrace.GetFrame(1).GetMethod().Name, stackTrace.GetFrame(1).GetType().FullName, ex.Message, ex.StackTrace), EventLogEntryType.Error);
            }
            catch
            {
                //Do nothing
                //Supress exception when unable to log the errors
            }
        }

        /// <summary>
        /// WriteToEventLog
        /// Function to Write Log To EventLog
        /// </summary>
        /// <param name="message">String</param>
        /// <param name="EventType">EventLogEntryType</param>
        private static void WriteToEventLog(String message, EventLogEntryType EventType)
        {
            WriteToLogFile(message);

            EventLog objEventLog = new EventLog();
            try
            {
                if (!EventLog.SourceExists(ApplicationConstants.Logging.Source))
                    EventLog.CreateEventSource(ApplicationConstants.Logging.Source, ApplicationConstants.Logging.Log);

            }
            catch (Exception)
            {
                //Do nothing
            }

            try
            {
                objEventLog.Log = ApplicationConstants.Logging.Log;
                objEventLog.Source = ApplicationConstants.Logging.Source;
                objEventLog.WriteEntry(message, EventType);
                objEventLog.Close();
            }
            catch (Exception)
            {
                //Do nothing
            }

        }

        /// <summary>
        /// WriteToLogFile
        /// Function to Write Log To log text file
        /// </summary>
        /// <param name="message">String</param>
        public static void WriteToLogFile(String message)
        {
            try
            {
                FileInfo file = null;
                file = new FileInfo(GetFileName());

                using (StreamWriter writer = file.AppendText())
                {
                    //Write message to the log file
                    writer.WriteLine("----------------------------------");
                    writer.WriteLine(message);
                    writer.WriteLine("----------------------------------");
                }
            }
            catch
            {
                //do nothing
            }
        }

        /// <summary>
        /// IsTodaysLogFile
        /// Function to check log file of current date
        /// </summary>
        /// <param name="logfilename">Log file name</param>
        /// <returns>True: If file of current date, False: Otherwise</returns>
        private static bool IsTodaysLogFile(string logfilename)
        {
            try
            {
                string[] result = logfilename.Split(new string[] { "\\", "." }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(s => s.Contains("Log_")).Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                if (result != null)
                {
                    var filedate = new DateTime(Convert.ToInt32(result[3]), Convert.ToInt32(result[2]), Convert.ToInt32(result[1]));
                    if (DateTime.Today != filedate)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
