using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Utilities;


namespace WebApiServiceDataAccess
{
    /// <summary>
    /// DataAccessLayer class
    /// </summary>
    public class DataAccessLayer
    {
        #region Private Methods

        /// <summary>
        /// UpdateParameters
        /// </summary>
        /// <param name="parameters">List of SQL parameter</param>
        private static void UpdateParameters(List<SQLParameter> parameters)
        {
            if (parameters != null)
            {
                foreach (SQLParameter parameter in parameters)
                {
                    if (parameter.Type == System.Data.DbType.Guid && parameter.Value != null && new Guid(parameter.Value.ToString()) == Guid.Empty)
                    {
                        parameter.Value = null;
                    }
                }
            }
        }

        /// <summary>
        /// GetSqlCommand
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <returns>SQL command</returns>
        private static SqlCommand GetSqlCommand(String storedProcedureName, List<SQLParameter> parameters, ISession session)
        {
            UpdateParameters(parameters);

            SqlCommand command = new SqlCommand(storedProcedureName, (SqlConnection)session.Connection);
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (SQLParameter parameter in parameters)
                {
                    if (parameter.Direction == ParameterDirection.Input)
                    {
                        command.Parameters.AddWithValue(parameter.Name, parameter.Value);
                    }
                    else
                    {
                        command.Parameters.Add(parameter.Name, (SqlDbType)parameter.Type, parameter.Size);
                        command.Parameters[parameter.Name].Direction = ParameterDirection.Output;
                    }
                }
            }
            return command;
        }

        /// <summary>
        /// GetMySqlCommand
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <returns>MYSQL command</returns>
        //private static MySqlCommand GetMySqlCommand(String storedProcedureName, List<SQLParameter> parameters, ISession session)
        //{
        //    UpdateParameters(parameters);
        //    MySqlCommand command = new MySqlCommand(storedProcedureName, (MySqlConnection)session.Connection);
        //    command.CommandType = CommandType.StoredProcedure;

        //    if (parameters != null)
        //    {
        //        foreach (SQLParameter parameter in parameters)
        //        {
        //            if (parameter.Direction == ParameterDirection.Input)
        //            {
        //                command.Parameters.AddWithValue(parameter.Name, parameter.Value);
        //            }
        //            else
        //            {
        //                command.Parameters.Add(parameter.Name, (MySqlDbType)parameter.Type, parameter.Size);
        //                command.Parameters[parameter.Name].Direction = ParameterDirection.Output;
        //            }
        //        }
        //    }
        //    return command;
        //}

        /// <summary>
        /// GetCommand
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <returns>SQL command</returns>
        private static SqlCommand GetCommand(String storedProcedureName, List<SQLParameter> parameters, ISession session)
        {
            UpdateParameters(parameters);
            SqlCommand command = new SqlCommand(storedProcedureName, (SqlConnection)session.Connection);
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (SQLParameter parameter in parameters)
                {
                    if (parameter.Direction == ParameterDirection.Input)
                    {
                        command.Parameters.AddWithValue(parameter.Name, parameter.Value);
                    }
                    else
                    {
                        command.Parameters.Add(parameter.Name, (SqlDbType)parameter.Type, parameter.Size);
                        command.Parameters[parameter.Name].Direction = ParameterDirection.Output;
                    }
                }
            }
            return command;
        }

        ///// <summary>
        ///// GetNpgSqlCommand
        ///// </summary>
        ///// <param name="storedProcedureName">Stored procedure name</param>
        ///// <param name="parameters">List of SQL parameter</param>
        ///// <param name="session">Session object</param>
        ///// <returns>Npgsql command</returns>
        //private static NpgsqlCommand  GetNpgSqlCommand(String storedProcedureName, List<SQLParameter> parameters, ISession session)
        //{
        //    UpdateParameters(parameters);
        //    NpgsqlCommand command = new NpgsqlCommand(storedProcedureName, (NpgsqlConnection)session.Connection);
        //    command.CommandType = CommandType.StoredProcedure;

        //    if (parameters != null)
        //    {
        //        foreach (SQLParameter parameter in parameters)
        //        {
        //            if (parameter.Direction == ParameterDirection.Input)
        //            {
        //                command.Parameters.AddWithValue(parameter.Name, parameter.Value);
        //            }
        //            else
        //            {
        //                command.Parameters.Add(parameter.Name, (NpgsqlDbType)parameter.Type, parameter.Size);
        //                command.Parameters[parameter.Name].Direction = ParameterDirection.Output;
        //            }
        //        }
        //    }
        //    return command;
        //}

        #endregion

        #region Public Methods

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="session">Session object</param>
        /// <returns>Data reader object</returns>
        public static IDataReader ExecuteReader(String storedProcedureName, ISession session)
        {
            return ExecuteReader(storedProcedureName, null, session);
        }

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <returns>Data reader object</returns>
        public static IDataReader ExecuteReader(String storedProcedureName, List<SQLParameter> parameters, ISession session)
        {
            UpdateParameters(parameters);
            IDbCommand command = GetCommand(storedProcedureName, parameters, session);
            return command.ExecuteReader();
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="session">Session object</param>
        /// <returns>Number of afftected rows</returns>
        public static int ExecuteNonQuery(String storedProcedureName, ISession session)
        {
            return ExecuteNonQuery(storedProcedureName, null, session);
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <returns>Number of afftected rows</returns>
        public static int ExecuteNonQuery(String storedProcedureName, List<SQLParameter> parameters, ISession session)
        {
            int rowAffected = 0;
           // MySqlCommand mysqlcommand = null;
            // NpgsqlCommand npgsqlcommand = null;
            try
            {
                switch (SessionFactory.DataBaseProviderName)
                {
                    default://ApplicationConstants.ConnProvider.SQL:
                        UpdateParameters(parameters);
                        SqlCommand sqlcommand = GetSqlCommand(storedProcedureName, parameters, session);
                        rowAffected = sqlcommand.ExecuteNonQuery();

                        if (parameters != null)
                        {
                            foreach (SQLParameter parameter in parameters)
                            {
                                if (parameter.Direction == ParameterDirection.Output)
                                {
                                    parameter.Value = sqlcommand.Parameters[parameter.Name].Value;
                                }
                            }
                        }
                        break;
                    //case ApplicationConstants.ConnProvider.NPGSQL:
                    //    UpdateParameters(parameters);
                    //    npgsqlcommand = GetNpgSqlCommand(storedProcedureName, parameters, session);
                    //    rowAffected = npgsqlcommand.ExecuteNonQuery();

                    //    if (parameters != null)
                    //    {
                    //        foreach (SQLParameter parameter in parameters)
                    //        {
                    //            if (parameter.Direction == ParameterDirection.Output)
                    //            {
                    //                parameter.Value = npgsqlcommand.Parameters[parameter.Name].Value;
                    //            }
                    //        }
                    //    }
                    //    break;
                    //default:
                }
            }
            catch (Exception)
            {
                Logger.WriteToLogFile(storedProcedureName + string.Format(ApplicationConstants.Errors.ExecuteNonQueryError, DateTime.Now));
                //Logger.LogError(ex);
            }
            finally
            {
                //if (npgsqlcommand != null)
                //{
                //    npgsqlcommand.Dispose();
                //    npgsqlcommand = null;
                //}
                SessionFactory.CloseSession(session);
            }
            return rowAffected;
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="session">Session object</param>
        /// <returns>Object</returns>
        public static Object ExecuteScalar(String storedProcedureName, ISession session)
        {
            return ExecuteScalar(storedProcedureName, null, session);
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <returns>Object</returns>
        public static Object ExecuteScalar(String storedProcedureName, List<SQLParameter> parameters, ISession session)
        {
            object result = null;
            try
            {
                switch (SessionFactory.DataBaseProviderName)
                {
                    case ApplicationConstants.ConnProvider.SQL:
                        UpdateParameters(parameters);
                        SqlCommand sqlcommand = GetSqlCommand(storedProcedureName, parameters, session);
                        result = sqlcommand.ExecuteScalar();
                        break;
                    //case ApplicationConstants.ConnProvider.NPGSQL:
                    //    UpdateParameters(parameters);
                    //    NpgsqlCommand npgsqlcommand = GetNpgSqlCommand(storedProcedureName, parameters, session);
                    //    result = npgsqlcommand.ExecuteScalar();
                    //    break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                result = null;
                Logger.WriteToLogFile(storedProcedureName + string.Format(ApplicationConstants.Errors.ExecuteScalarError, DateTime.Now));
                //   Logger.LogError(ex);
            }
            return result;
        }

        /// <summary>
        /// ExecuteDataSet
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="session">Session object</param>
        /// <param name="dataSetName">Data set name</param>
        /// <returns>Data set object</returns>
        public static DataSet ExecuteDataSet(String storedProcedureName, ISession session, String dataSetName)
        {
            return ExecuteDataSet(storedProcedureName, null, session, dataSetName);
        }

        /// <summary>
        /// ExecuteDataSet
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <param name="dataSetName">Data set name</param>
        /// <returns>Data set object</returns>
        public static DataSet ExecuteDataSet(String storedProcedureName, List<SQLParameter> parameters, ISession session, String dataSetName)
        {
            UpdateParameters(parameters);
            DataSet ds = new DataSet();
            if (!String.IsNullOrEmpty(dataSetName))
            {
                ds.DataSetName = dataSetName;
            }
            SqlCommand command = GetCommand(storedProcedureName, parameters, session);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// ExecuteDataRowList
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="session">Session object</param>
        /// <param name="tableName">Table name</param>
        /// <returns>List of data rows</returns>
        public static List<DataRow> ExecuteDataRowList(String storedProcedureName, ISession session, String tableName)
        {
            return ExecuteDataRowList(storedProcedureName, null, session, tableName);
        }

        /// <summary>
        /// ExecuteDataRowList
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <param name="tableName">Table name</param>
        /// <returns>List of data rows</returns>
        public static List<DataRow> ExecuteDataRowList(String storedProcedureName, List<SQLParameter> parameters, ISession session, String tableName)
        {
            DataTable dt = null;
            //SqlCommand sqlcommand = null;
            //SqlDataAdapter da = null;
            //NpgsqlCommand npgsqlcommand = null;
            //NpgsqlDataAdapter danpgsql = null;
            try
            {
                //switch (SessionFactory.DataBaseProviderName)
                //{
                    //case ApplicationConstants.ConnProvider.SQL:
                        UpdateParameters(parameters);
                        dt = new DataTable();
                        if (!String.IsNullOrEmpty(tableName))
                        {
                            dt.TableName = tableName;
                        }
                        SqlCommand sqlcommand = GetSqlCommand(storedProcedureName, parameters, session);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcommand;
                        da.Fill(dt);
                      //  break;
                    //case ApplicationConstants.ConnProvider.NPGSQL:
                    //    UpdateParameters(parameters);
                    //    dt = new DataTable();
                    //    if (!String.IsNullOrEmpty(tableName))
                    //    {
                    //        dt.TableName = tableName;
                    //    }
                    //    npgsqlcommand = GetNpgSqlCommand(storedProcedureName, parameters, session);
                    //    danpgsql = new NpgsqlDataAdapter();
                    //    danpgsql.SelectCommand = npgsqlcommand;
                    //    danpgsql.Fill(dt);
                    //    break;
                    //default:
                      //  break;
                //}
                return dt.Select().Cast<DataRow>().ToList();
            }
            catch (Exception)
            {
                Logger.WriteToLogFile(storedProcedureName + ",lst," + string.Format(ApplicationConstants.Errors.ExecuteDataRowError, DateTime.Now));
                //   Logger.LogError(ex);
            }
            finally
            {
                //if (npgsqlcommand != null)
                //{
                //    npgsqlcommand.Dispose();
                //    npgsqlcommand = null;
                //}
                //if (danpgsql != null)
                //{
                //    danpgsql.Dispose();
                //    danpgsql = null;
                //}
                SessionFactory.CloseSession(session);
            }
            return null;
        }

        /// <summary>
        /// ExecuteDataRow
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="session">Session object</param>
        /// <param name="tableName">Table name</param>
        /// <returns>Data row</returns>
        public static DataRow ExecuteDataRow(String storedProcedureName, ISession session, String tableName)
        {
            return ExecuteDataRow(storedProcedureName, null, session, tableName);
        }

        /// <summary>
        /// ExecuteDataRow
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <param name="tableName">Table name</param>
        /// <returns>Data row</returns>
        public static DataRow ExecuteDataRow(String storedProcedureName, List<SQLParameter> parameters, ISession session, String tableName)
        {
            DataTable dt = null;
            //NpgsqlCommand npgsqlcommand = null;
            //NpgsqlDataAdapter danpgsql = null;
            try
            {
                        UpdateParameters(parameters);
                        dt = new DataTable();
                        if (!String.IsNullOrEmpty(tableName))
                        {
                            dt.TableName = tableName;
                        }
                        SqlCommand sqlcommand = GetSqlCommand(storedProcedureName, parameters, session);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcommand;
                        da.Fill(dt);
                List<DataRow> lst = dt.Select().Cast<DataRow>().ToList();
                if (lst.Count > 0)
                {
                    return lst[0];
                }
            }
            catch (Exception)
            {
                Logger.WriteToLogFile(storedProcedureName + ",dr," + string.Format(ApplicationConstants.Errors.ExecuteDataRowError, DateTime.Now));
                //  Logger.LogError(ex);
            }
            finally
            {
                //if (npgsqlcommand != null)
                //{
                //    npgsqlcommand.Dispose();
                //    npgsqlcommand = null;
                //}
                //if (danpgsql != null)
                //{
                //    danpgsql.Dispose();
                //    danpgsql = null;
                //}
                SessionFactory.CloseSession(session);
            }
            return null;
        }

        /// <summary>
        /// ExecuteDataRowToDataTable
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="session">Session object</param>
        /// <param name="tableName">Table name</param>
        /// <returns>DataTable object</returns>
        public static DataTable ExecuteDataRowToDataTable(String storedProcedureName, ISession session, String tableName)
        {
            return ExecuteDataRowToDataTable(storedProcedureName, null, session, tableName);
        }

        /// <summary>
        /// ExecuteDataRowToDataTable
        /// </summary>
        /// <param name="storedProcedureName">Stored procedure name</param>
        /// <param name="parameters">List of SQL parameter</param>
        /// <param name="session">Session object</param>
        /// <param name="tableName">Table name</param>
        /// <returns>DataTable object</returns>
        public static DataTable ExecuteDataRowToDataTable(String storedProcedureName, List<SQLParameter> parameters, ISession session, String tableName)
        {
            DataTable dt = null;
            //NpgsqlCommand npgsqlcommand = null;
            //NpgsqlDataAdapter danpgsql = null;
            try
            {
//                switch (SessionFactory.DataBaseProviderName)
  //              {
    //                case ApplicationConstants.ConnProvider.SQL:
                        UpdateParameters(parameters);
                        dt = new DataTable();
                        if (!String.IsNullOrEmpty(tableName))
                        {
                            dt.TableName = tableName;
                        }
                        SqlCommand sqlcommand = GetSqlCommand(storedProcedureName, parameters, session);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = sqlcommand;
                        da.Fill(dt);
            //            break;

                    //case ApplicationConstants.ConnProvider.NPGSQL:
                    //    UpdateParameters(parameters);
                    //    dt = new DataTable();
                    //    if (!String.IsNullOrEmpty(tableName))
                    //    {
                    //        dt.TableName = tableName;
                    //    }
                    //    npgsqlcommand = GetNpgSqlCommand(storedProcedureName, parameters, session);
                    //    danpgsql = new NpgsqlDataAdapter();
                    //    danpgsql.SelectCommand = npgsqlcommand;
                    //    danpgsql.Fill(dt);
                    //    break;
      //              default:
        //                break;
          //      }
                //return dt.Select().Cast<DataRow>().ToList();
            }
            catch (Exception)
            {
                Logger.WriteToLogFile(storedProcedureName + ",dt," + string.Format(ApplicationConstants.Errors.ExecuteDataRowError, DateTime.Now));
                //   Logger.LogError(ex);
                return null;
            }
            finally
            {
                //if (npgsqlcommand != null)
                //{
                //    npgsqlcommand.Dispose();
                //    npgsqlcommand = null;
                //}
                //if (danpgsql != null)
                //{
                //    danpgsql.Dispose();
                //    danpgsql = null;
                //}
                SessionFactory.CloseSession(session);
            }
            return dt;
        }

        #endregion
    }
}
