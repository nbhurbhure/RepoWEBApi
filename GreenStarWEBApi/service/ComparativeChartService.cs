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
    public class ComparativeChartService
    {
        public static DataTable GetComparativeCharts()
        {
            ISession session = null;
            DataTable dtGetComparativeCharts = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                                        
                    dtGetComparativeCharts = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetComparativeCharts, parameters, session, "GetComparativeCharts");
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
            return dtGetComparativeCharts;
        }

        public static DataTable GetComparativeChartsById(int Id)
        {
            ISession session = null;
            DataTable dtGetComparativeCharts = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));
                                        
                    dtGetComparativeCharts = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetComparativeChartsById, parameters, session, "GetComparativeChartsById");
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
            return dtGetComparativeCharts;
        }

        internal static void PutComparativeChart(int Id, ComparativeChart objComparativeChart)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objComparativeChart.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@StandardNam", DBHelper.GetNullableString(objComparativeChart.StandardNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@SectionNam", DBHelper.GetNullableString(objComparativeChart.SectionNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@ParameterNam", DBHelper.GetNullableString(objComparativeChart.ParameterNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@MonthNam", DBHelper.GetNullableString(objComparativeChart.MonthNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@MonthPercent", DBHelper.GetNullableString(objComparativeChart.MonthPercent), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@IncreasePercent", DBHelper.GetNullableString(objComparativeChart.IncreasePercent), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@argId", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PutComparativeChart, parameters, session);
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

        internal static void PostComparativeChart(ComparativeChart objComparativeChart)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objComparativeChart.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@StandardNam", DBHelper.GetNullableString(objComparativeChart.StandardNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@SectionNam", DBHelper.GetNullableString(objComparativeChart.SectionNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@ParameterNam", DBHelper.GetNullableString(objComparativeChart.ParameterNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@MonthNam", DBHelper.GetNullableString(objComparativeChart.MonthNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@MonthPercent", DBHelper.GetNullableString(objComparativeChart.MonthPercent), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@IncreasePercent", DBHelper.GetNullableString(objComparativeChart.IncreasePercent), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PostComparativeChart, parameters, session);
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

        internal static void DeleteComparativeChart(int Id)
        {
            ISession session = null;
            try 
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.DeleteComparativeChart, parameters, session);
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
