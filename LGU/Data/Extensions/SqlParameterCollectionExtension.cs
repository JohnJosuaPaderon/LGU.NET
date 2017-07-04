using System.Data;
using System.Data.SqlClient;

namespace LGU.Data.Extensions
{
    public static class SqlParameterCollectionExtension
    {
        private static bool ValidateParameterName(SqlParameterCollection parameters, string parameterName)
        {
            return !(string.IsNullOrWhiteSpace(parameterName) || parameters.Contains(parameterName));
        }

        public static void AddInput(this SqlParameterCollection arg, string parameterName, object value)
        {
            if (ValidateParameterName(arg, parameterName))
            {
                arg.Add(new SqlParameter()
                {
                    ParameterName = parameterName,
                    Value = value,
                    Direction = ParameterDirection.Input
                });
            }
        }

        public static void AddOutput(this SqlParameterCollection arg, string parameterName)
        {
            if (ValidateParameterName(arg, parameterName))
            {
                arg.Add(new SqlParameter()
                {
                    ParameterName = parameterName,
                    Direction = ParameterDirection.Output
                });
            }
        }

        public static void AddInputOutput(this SqlParameterCollection arg, string parameterName, object value)
        {
            if (ValidateParameterName(arg, parameterName))
            {
                arg.Add(new SqlParameter()
                {
                    ParameterName = parameterName,
                    Value = value,
                    Direction = ParameterDirection.InputOutput
                });
            }
        }
    }
}
