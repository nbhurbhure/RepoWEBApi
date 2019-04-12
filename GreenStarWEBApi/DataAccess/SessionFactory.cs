using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Utilities;

namespace WebApiServiceDataAccess
{
    /// <summary>
    /// SessionFactory class
    /// </summary>
    public class SessionFactory
    {
        #region Fields

        private static string _connProviderName;
        private static string _conn;
        private static string _name;

        #endregion

        #region Constructors

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public SessionFactory()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// DataBaseProviderName
        /// </summary>
        public static string DataBaseProviderName
        {
            get
            {
                return _connProviderName;
            }
            set
            {
                _connProviderName = value;
            }
        }

        /// <summary>
        /// GetConnectionString
        /// </summary>
        private static string GetConnectionString
        {
            get
            {
                return _conn;
            }
            set
            {
                //GetDataBaseProviderName();
                _conn = value;
            }
        }
        private static string GetConnectionName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// GetDataBaseProviderName
        /// </summary>
        private static void GetDataBaseProviderName(string connName)
        {
            try
            {
                ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;

                foreach (ConnectionStringSettings connection in connectionStrings)
                {
                    _connProviderName = connection.ProviderName;
                    _conn = connection.ConnectionString;
                    _name = connection.Name;
                }
                //switch (connName)
                //{
                //    case ApplicationConstants.ConnName.SMC_USERConnectionString:
                //        _conn = ConfigurationManager.ConnectionStrings["SMC_USERConnectionString"].ConnectionString;
                //        _connProviderName = ConfigurationManager.ConnectionStrings["SMC_USERConnectionString"].ProviderName;
                //        break;
                //    case ApplicationConstants.ConnName.SMC_VTSConnectionString:
                //        _conn = ConfigurationManager.ConnectionStrings["SMC_VTSConnectionString"].ConnectionString;
                //        _connProviderName = ConfigurationManager.ConnectionStrings["SMC_VTSConnectionString"].ProviderName;
                //        break;
                //    case ApplicationConstants.ConnName.SMC_SCHEDULEConnectionString:
                //        _conn = ConfigurationManager.ConnectionStrings["SMC_SCHEDULEConnectionString"].ConnectionString;
                //        _connProviderName = ConfigurationManager.ConnectionStrings["SMC_SCHEDULEConnectionString"].ProviderName;
                //        break;
                //    case ApplicationConstants.ConnName.SMC_IMSConnectionString:
                //        _conn = ConfigurationManager.ConnectionStrings["SMC_IMSConnectionString"].ConnectionString;
                //        _connProviderName = ConfigurationManager.ConnectionStrings["SMC_IMSConnectionString"].ProviderName;
                //        break;
                //    case ApplicationConstants.ConnName.SMC_SolarWindsConnectionString:
                //        _conn = ConfigurationManager.ConnectionStrings["SMC_SolarWindsConnectionString"].ConnectionString;
                //        _connProviderName = ConfigurationManager.ConnectionStrings["SMC_SolarWindsConnectionString"].ProviderName;
                //        break;
                //    default:
                //        break;
                //}
            }
            catch (Exception)
            {
                Logger.WriteToLogFile("Error in GetDataBaseProviderName:" + string.Format(ApplicationConstants.Errors.FetchingConnStringError, DateTime.Now));
                //   Logger.LogError(ex);
            }
        }
        /// <summary>
        /// GetNewSession
        ///  Function to get new session
        /// </summary>
        /// <returns>GetSession - ISession</returns>
        public static ISession GetSession(string connName)
        {
            ISession session = null;
            try
            {
                GetDataBaseProviderName(connName);
                switch (DataBaseProviderName)
                {
                    case ApplicationConstants.ConnProvider.SQL:
                        session = new SqlSession(GetConnectionString);
                        session.Open();
                        break;
                    default:
                                                session = new SqlSession(GetConnectionString);
                        session.Open();
                        break;
                }
            }
            catch (Exception)
            {
                session = null;
                Logger.WriteToLogFile(string.Format("Erro in GetSession:" + ApplicationConstants.Errors.OpeningConnError, DateTime.Now));
                //   Logger.LogError(ex);
            }
            return session;
        }

        /// <summary>
        /// GetMySQLSession
        /// Function to get new my sql session
        /// </summary>
        /// <returns>GetMySQLSession - ISession</returns>
        public static ISession GetMySQLSession(string connName)
        {
            ISession session = null;
            try
            {
                GetDataBaseProviderName(connName);
                switch (DataBaseProviderName)
                {
                    case ApplicationConstants.ConnProvider.SQL:
                        session = new SqlSession(GetConnectionString);
                        session.Open();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                session = null;
                Logger.WriteToLogFile("GetMySQLSession:" + string.Format(ApplicationConstants.Errors.OpeningConnError, DateTime.Now));
                // Logger.LogError(ex);
            }
            return session;
        }

        /// <summary>
        /// GetPostGreSQLSession
        /// Function to get new post gre sql session
        /// </summary>
        /// <returns>GetPostGreSQLSession - ISession</returns>
        //public static ISession GetPostGreSQLSession()
        //{
        //    ISession session = null;
        //    try
        //    {
        //        DataBaseProviderName = ApplicationConstants.ConnProvider.NPGSQL;
        //        session = new PostGreSQLSession(UtilService.PostGreSQLConnString);
        //        session.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        session = null;
        //        Logger.WriteToLogFile(string.Format(ApplicationConstants.Errors.OpeningConnError, DateTime.Now));
        //        Logger.LogError(ex);
        //    }
        //    return session;
        //}

        /// <summary>
        /// CloseSession
        ///  Function to get close session
        /// </summary>
        public static void CloseSession(ISession session)
        {
            try
            {
                if (session != null)
                {
                    session.Connection.Close();
                    session.Connection.Dispose();
                    //session.Close();
                    session = null;
                }
            }
            catch (Exception)
            {
                session = null;
                Logger.WriteToLogFile("CloseSession" + string.Format(ApplicationConstants.Errors.ClosingConnError, DateTime.Now));
                // Logger.LogError(ex);
            }
        }

        /// <summary>
        /// IsValidSession
        /// Function to check valid session
        /// </summary>
        /// <param name="session">Session object</param>
        /// <returns>True : If valid session, False : If invalid session</returns>
        public static bool IsValidSession(ISession session)
        {
            if (session != null)
            {
                return true;
            }
            Logger.WriteToLogFile(string.Format("SessionNullError", DateTime.Now, SessionFactory.DataBaseProviderName));
            return false;
        }

        #endregion
    }
}
