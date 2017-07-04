using LGU.Data.RDBMS;

namespace LGU.Data.Extensions
{
    public static class SqlDataQueryInfoExtension
    {
        public static SqlDataQueryInfo<T> AddInputParameter<T>(this SqlDataQueryInfo<T> queryInfo, string parameterName, object value)
        {
            queryInfo.Parameters.AddInput(parameterName, value);
            return queryInfo;
        }

        public static SqlDataQueryInfo<T> AddOutputParameter<T>(this SqlDataQueryInfo<T> queryInfo, string parameterName)
        {
            queryInfo.Parameters.AddOutput(parameterName);
            return queryInfo;
        }

        public static SqlDataQueryInfo<T> AddInputOutputParameter<T>(this SqlDataQueryInfo<T> queryInfo, string parameterName, object value)
        {
            queryInfo.Parameters.AddInputOutput(parameterName, value);
            return queryInfo;
        }
    }
}
