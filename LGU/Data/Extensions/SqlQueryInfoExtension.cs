﻿using LGU.Data.RDBMS;

namespace LGU.Data.Extensions
{
    public static class SqlQueryInfoExtension
    {
        public static SqlQueryInfo AddInputParameter(this SqlQueryInfo queryInfo, string parameterName, object value)
        {
            queryInfo.Parameters.AddInput(parameterName, value);
            return queryInfo;
        }

        public static SqlQueryInfo AddOutputParameter(this SqlQueryInfo queryInfo, string parameterName)
        {
            queryInfo.Parameters.AddOutput(parameterName);
            return queryInfo;
        }

        public static SqlQueryInfo AddInputOutputParameter(this SqlQueryInfo queryInfo, string parameterName, object value)
        {
            queryInfo.Parameters.AddInputOutput(parameterName, value);
            return queryInfo;
        }
    }
}
