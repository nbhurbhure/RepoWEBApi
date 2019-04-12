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
    public class MonthInfoService
    {
        public static DataTable GetMonthInfos()
        {
            ISession session = null;
            DataTable dtGetMonthInfos = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                                        
                    dtGetMonthInfos = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetMonthInfos, parameters, session, "GetMonthInfos");
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
            return dtGetMonthInfos;
        }

        public static DataTable GetMonthInfosById(int Id)
        {
            ISession session = null;
            DataTable dtGetMonthInfos = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));
                                        
                    dtGetMonthInfos = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetMonthInfosById, parameters, session, "GetMonthInfosById");
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
            return dtGetMonthInfos;
        }

        internal static void PutMonthInfo(int Id, MonthInfo objMonthInfo)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objMonthInfo.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@Name", DBHelper.GetNullableString(objMonthInfo.Name), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Month", DBHelper.GetNullableString(objMonthInfo.Month), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@YearInfoName", DBHelper.GetNullableString(objMonthInfo.YearInfoName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FYearInfoId", DBHelper.GetNullableString(objMonthInfo.FYearInfoId), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@argId", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PutMonthInfo, parameters, session);
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

        internal static void PostMonthInfo(MonthInfo objMonthInfo)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objMonthInfo.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@Name", DBHelper.GetNullableString(objMonthInfo.Name), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Month", DBHelper.GetNullableString(objMonthInfo.Month), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@YearInfoName", DBHelper.GetNullableString(objMonthInfo.YearInfoName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FYearInfoId", DBHelper.GetNullableString(objMonthInfo.FYearInfoId), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PostMonthInfo, parameters, session);
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

        internal static void DeleteMonthInfo(int Id)
        {
            ISession session = null;
            try 
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.DeleteMonthInfo, parameters, session);
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
