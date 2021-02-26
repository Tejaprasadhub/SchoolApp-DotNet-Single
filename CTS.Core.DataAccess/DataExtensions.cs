using CTS.DataAccess.Core;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;

namespace CTS.Core.DataAccess
{
    public static class DbContextExtensions
    {
        //common method to get db connection
        public static DbConnection GetDbConnection(this CTSContext context)
        {
            return context.Database.GetDbConnection();
        }
        //common method to execute a stored procedure
        public static DataSet Execute(this CTSContext context, string query, CommandType type = CommandType.StoredProcedure, Dictionary<string, object> parameters = null,string connectionString = "")
        {
            try
            {
                CTSContext ctsContext = new CTSContext(connectionString);
                DataSet ds = new DataSet();
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = type;

                    ConstructParameters(parameters, command);

                    if (command.Connection.State != ConnectionState.Open)
                        command.Connection.Open();
                    using (var reader = command.ExecuteReader(behavior: CommandBehavior.CloseConnection))
                    {
                        do
                        {
                            //loads the DataTable(schema will be fetch automatically)
                            var tb = new DataTable();
                            tb.Load(reader);
                            ds.Tables.Add(tb);

                        } while (!reader.IsClosed);
                    }
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //to handle null values
        private static object HandleNullValues(object value)
        {
            if (value == null || value.ToString() == DateTime.MinValue.ToString() || string.IsNullOrEmpty(value.ToString()))
            {
                value = DBNull.Value;
            }

            return value;
        }
        //construct parameters based on type of request object
        private static void ConstructParameters(Dictionary<string, object> parameters, DbCommand command)
        {
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> param in parameters)
                {
                    if (param.Value != null && param.Value.GetType() == typeof(TableValueParameter))
                    {
                        MySqlParameter mySqlParameter = new MySqlParameter(param.Key, MySqlDbType.String);
                        var tv = param.Value as TableValueParameter;
                        mySqlParameter.Value = HandleNullValues(tv.Values);
                        mySqlParameter.ParameterName = tv.DatabaseTypeName; // need to check
                        command.Parameters.Add(mySqlParameter);
                    }
                    else if (param.Value != null && param.Value.GetType() == typeof(ParameterWithMetadata))
                    {
                        var temp = param.Value as ParameterWithMetadata;

                        DbParameter dbParameter = command.CreateParameter();
                        dbParameter.ParameterName = param.Key;
                        dbParameter.Value = HandleNullValues(temp.Value);
                        dbParameter.DbType = temp.Type;
                        dbParameter.Size = temp.Size;
                        dbParameter.Direction = temp.Direction;

                        command.Parameters.Add(dbParameter);
                    }
                    else
                    {
                        DbParameter dbParameter = command.CreateParameter();
                        dbParameter.ParameterName = param.Key;
                        dbParameter.Value = HandleNullValues(param.Value);

                        command.Parameters.Add(dbParameter);
                    }
                }
            }
        }


    }


}
