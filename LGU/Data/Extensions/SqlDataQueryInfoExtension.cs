using LGU.Data.RDBMS;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LGU.Data.Extensions
{
    public static class SqlDataQueryInfoExtension
    {
        public static SqlDataQueryInfo<T> AddInputParameter<T>(this SqlDataQueryInfo<T> queryInfo, string parameterName, object value)
        {
            queryInfo.Parameters.AddInput(parameterName, value);
            return queryInfo;
        }

        public static SqlDataQueryInfo<T> AddInputParameter<T>(this SqlDataQueryInfo<T> queryInfo, string parameterName, object value, SqlDbType type)
        {
            queryInfo.Parameters.Add(new SqlParameter(parameterName, value ?? DBNull.Value) { SqlDbType = type });
            return queryInfo;
        }

        public static SqlDataQueryInfo<T> AddOutputParameter<T>(this SqlDataQueryInfo<T> queryInfo, string parameterName, DbType dbType)
        {
            queryInfo.Parameters.AddOutput(parameterName, dbType);
            return queryInfo;
        }

        public static SqlDataQueryInfo<T> AddInputOutputParameter<T>(this SqlDataQueryInfo<T> queryInfo, string parameterName, object value)
        {
            queryInfo.Parameters.AddInputOutput(parameterName, value);
            return queryInfo;
        }

        public static SqlDataQueryInfo<T> AddLogByParameter<T>(this SqlDataQueryInfo<T> queryInfo)
        {
            queryInfo.Parameters.AddInput("@_LogBy", SystemRuntime.LogByInfo);
            return queryInfo;
        }
    }
}
