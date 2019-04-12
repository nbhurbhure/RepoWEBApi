using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;
using WebAPI.Utilities;
using WebApiServiceDataAccess;

namespace WebAPI.Service
{
    public class LoginService
    {
        public static DataTable GetLogins()
        {
            ISession session = null;
            DataTable dtGetLogins = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                                        
                    dtGetLogins = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetLogins, parameters, session, "GetLogins");
                    SessionFactory.CloseSession(session);
                }
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    SessionFactory.CloseSession(session);
                }
                Logger.LogError(ex);
                return null;
            }
            return dtGetLogins;
        }

        public static DataTable GetLoginsById(int Id)
        {
            ISession session = null;
            DataTable dtGetLogins = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));
                                        
                    dtGetLogins = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetLoginsById, parameters, session, "GetLoginsById");
                    SessionFactory.CloseSession(session);
                }
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    SessionFactory.CloseSession(session);
                }
                Logger.LogError(ex);
                return null;
            }
            return dtGetLogins;
        }

        internal static void PutLogin(int Id, Login objLogin)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objLogin.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@UserNam", DBHelper.GetNullableString(objLogin.UserNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Password", DBHelper.GetNullableString(objLogin.Password), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@OutreachName", DBHelper.GetNullableString(objLogin.OutreachName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@CityName", DBHelper.GetNullableString(objLogin.CityName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@SchoolName", DBHelper.GetNullableString(objLogin.SchoolName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FOutreachId", DBHelper.GetNullableString(objLogin.FOutreachId), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FCityId", DBHelper.GetNullableString(objLogin.FCityId), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FSchoolId", DBHelper.GetNullableString(objLogin.FSchoolId), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@argId", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PutLogin, parameters, session);
                    SessionFactory.CloseSession(session);
                }
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    SessionFactory.CloseSession(session);
                }
                Logger.LogError(ex);
            }
        }

        internal static void PostLogin(Login objLogin)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objLogin.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@UserNam", DBHelper.GetNullableString(objLogin.UserNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Password", DBHelper.GetNullableString(objLogin.Password), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@OutreachName", DBHelper.GetNullableString(objLogin.OutreachName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@CityName", DBHelper.GetNullableString(objLogin.CityName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@SchoolName", DBHelper.GetNullableString(objLogin.SchoolName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FOutreachId", DBHelper.GetNullableString(objLogin.FOutreachId), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FCityId", DBHelper.GetNullableString(objLogin.FCityId), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FSchoolId", DBHelper.GetNullableString(objLogin.FSchoolId), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PostLogin, parameters, session);
                    SessionFactory.CloseSession(session);
                }
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    SessionFactory.CloseSession(session);
                }
                Logger.LogError(ex);
            }
        }

        internal static void DeleteLogin(int Id)
        {
            ISession session = null;
            try 
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.DeleteLogin, parameters, session);
                    SessionFactory.CloseSession(session);
                }

            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    SessionFactory.CloseSession(session);
                }
                Logger.LogError(ex);
            }

        
        }
    }
}
