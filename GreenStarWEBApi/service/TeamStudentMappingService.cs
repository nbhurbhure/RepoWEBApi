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
    public class TeamStudentMappingService
    {
        public static DataTable GetTeamStudentMappings()
        {
            ISession session = null;
            DataTable dtGetTeamStudentMappings = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                                        
                    dtGetTeamStudentMappings = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetTeamStudentMappings, parameters, session, "GetTeamStudentMappings");
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
            return dtGetTeamStudentMappings;
        }

        public static DataTable GetTeamStudentMappingsById(int Id)
        {
            ISession session = null;
            DataTable dtGetTeamStudentMappings = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));
                                        
                    dtGetTeamStudentMappings = DataAccessLayer.ExecuteDataRowToDataTable(ApplicationConstants.SPNames.GetTeamStudentMappingsById, parameters, session, "GetTeamStudentMappingsById");
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
            return dtGetTeamStudentMappings;
        }

        internal static void PutTeamStudentMapping(int Id, TeamStudentMapping objTeamStudentMapping)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objTeamStudentMapping.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@TeamName", DBHelper.GetNullableString(objTeamStudentMapping.TeamName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@StudentName", DBHelper.GetNullableString(objTeamStudentMapping.StudentName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FTeamId", DBHelper.GetNullableString(objTeamStudentMapping.FTeamId), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FStudentId", DBHelper.GetNullableString(objTeamStudentMapping.FStudentId), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@argId", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PutTeamStudentMapping, parameters, session);
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

        internal static void PostTeamStudentMapping(TeamStudentMapping objTeamStudentMapping)
        {
            ISession session = null;
            try
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(objTeamStudentMapping.Id), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@TeamName", DBHelper.GetNullableString(objTeamStudentMapping.TeamName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.String, "@StudentName", DBHelper.GetNullableString(objTeamStudentMapping.StudentName), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FTeamId", DBHelper.GetNullableString(objTeamStudentMapping.FTeamId), 0, ParameterDirection.Input));
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@FStudentId", DBHelper.GetNullableString(objTeamStudentMapping.FStudentId), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.PostTeamStudentMapping, parameters, session);
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

        internal static void DeleteTeamStudentMapping(int Id)
        {
            ISession session = null;
            try 
            {
                session = SessionFactory.GetSession(Clscommon.connectionString);
                if (SessionFactory.IsValidSession(session))
                {
                    List<SQLParameter> parameters = new List<SQLParameter>();
                    parameters.Add(new SQLParameter(System.Data.DbType.Int32, "@Id", DBHelper.GetNullableString(Id), 0, ParameterDirection.Input));

                    DataAccessLayer.ExecuteNonQuery(ApplicationConstants.SPNames.DeleteTeamStudentMapping, parameters, session);
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
