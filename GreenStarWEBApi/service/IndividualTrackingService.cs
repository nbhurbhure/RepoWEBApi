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
    public class IndividualTrackingService
    {
        public static DataTable GetIndividualTrackings()
        {
            ISession session = null;
            DataTable dtGetIndividualTrackings = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                                        
                    dtGetIndividualTrackings = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetIndividualTrackings, parameters, session, "GetIndividualTrackings");
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
            return dtGetIndividualTrackings;
        }

        public static DataTable GetIndividualTrackingsById(int Id)
        {
            ISession session = null;
            DataTable dtGetIndividualTrackings = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));
                                        
                    dtGetIndividualTrackings = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetIndividualTrackingsById, parameters, session, "GetIndividualTrackingsById");
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
            return dtGetIndividualTrackings;
        }

        internal static void PutIndividualTracking(int Id, IndividualTracking objIndividualTracking)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objIndividualTracking.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@SchoolNam", DBHelper.GetNullableString(objIndividualTracking.SchoolNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@RollNo", DBHelper.GetNullableString(objIndividualTracking.RollNo), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@StudentNam", DBHelper.GetNullableString(objIndividualTracking.StudentNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@StudentCaste", DBHelper.GetNullableString(objIndividualTracking.StudentCaste), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@DayInfo", DBHelper.GetNullableString(objIndividualTracking.DayInfo), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@MonthInfo", DBHelper.GetNullableString(objIndividualTracking.MonthInfo), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@YearInfo", DBHelper.GetNullableString(objIndividualTracking.YearInfo), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@ParameterNam", DBHelper.GetNullableString(objIndividualTracking.ParameterNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@DataValue", DBHelper.GetNullableString(objIndividualTracking.DataValue), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@argId", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PutIndividualTracking, parameters, session);
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

        internal static void PostIndividualTracking(IndividualTracking objIndividualTracking)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objIndividualTracking.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@SchoolNam", DBHelper.GetNullableString(objIndividualTracking.SchoolNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@RollNo", DBHelper.GetNullableString(objIndividualTracking.RollNo), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@StudentNam", DBHelper.GetNullableString(objIndividualTracking.StudentNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@StudentCaste", DBHelper.GetNullableString(objIndividualTracking.StudentCaste), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@DayInfo", DBHelper.GetNullableString(objIndividualTracking.DayInfo), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@MonthInfo", DBHelper.GetNullableString(objIndividualTracking.MonthInfo), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@YearInfo", DBHelper.GetNullableString(objIndividualTracking.YearInfo), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@ParameterNam", DBHelper.GetNullableString(objIndividualTracking.ParameterNam), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@DataValue", DBHelper.GetNullableString(objIndividualTracking.DataValue), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PostIndividualTracking, parameters, session);
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

        internal static void DeleteIndividualTracking(int Id)
        {
            ISession session = null;
            try 
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.DeleteIndividualTracking, parameters, session);
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
