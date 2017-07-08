using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace LGU.Data.Extensions
{
    public static class DbParameterListExtension
    {
        private static bool ValidateParameterName<T>(List<T> parameters, string parameterName)
            where T : DbParameter
        {
            return !(string.IsNullOrWhiteSpace(parameterName) || parameters.Any(p => p.ParameterName == parameterName));
        }

        public static void AddInput<T>(this List<T> arg, string parameterName, object value)
            where T : DbParameter, new()
        {
            if (ValidateParameterName(arg, parameterName))
            {
                arg.Add(
                    new T()
                    {
                        ParameterName = parameterName,
                        Value = value,
                        Direction = ParameterDirection.Input
                    });
            }
        }

        public static void AddOutput<T>(this List<T> arg, string parameterName, DbType dbType)
            where T : DbParameter, new()
        {
            if (ValidateParameterName(arg, parameterName))
            {
                arg.Add(
                    new T()
                    {
                        ParameterName = parameterName,
                        Direction = ParameterDirection.Output,
                        DbType = dbType
                    });
            }
        }

        public static void AddInputOutput<T>(this List<T> arg, string parameterName, object value)
            where T : DbParameter, new()
        {
            if (ValidateParameterName(arg, parameterName))
            {
                arg.Add(
                    new T()
                    {
                        ParameterName = parameterName,
                        Value = value,
                        Direction = ParameterDirection.InputOutput
                    });
            }
        }
    }
}
