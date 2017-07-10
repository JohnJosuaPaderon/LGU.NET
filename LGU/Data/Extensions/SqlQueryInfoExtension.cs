using LGU.Data.RDBMS;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LGU.Data.Extensions
{
    public static class SqlQueryInfoExtension
    {
        public static SqlQueryInfo AddInputParameter(this SqlQueryInfo queryInfo, string parameterName, object value)
        {
            queryInfo.Parameters.AddInput(parameterName, value);
            return queryInfo;
        }

        public static SqlQueryInfo AddInputParameter(this SqlQueryInfo queryInfo, string parameterName, object value, SqlDbType type)
        {
            queryInfo.Parameters.Add(new SqlParameter(parameterName, value ?? DBNull.Value) { SqlDbType = type });
            return queryInfo;
        }

        public static SqlQueryInfo AddOutputParameter(this SqlQueryInfo queryInfo, string parameterName, DbType dbType)
        {
            queryInfo.Parameters.AddOutput(parameterName, dbType);
            return queryInfo;
        }

        public static SqlQueryInfo AddInputOutputParameter(this SqlQueryInfo queryInfo, string parameterName, object value)
        {
            queryInfo.Parameters.AddInputOutput(parameterName, value);
            return queryInfo;
        }
    }
}
