using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LGU.Data.RDBMS
{
    public sealed class SqlDataQueryInfo<T> : IDbDataQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter>
    {
        public static SqlDataQueryInfo<T> CreateProcedureQueryInfo(T data, string storedProcedure, Func<T, SqlCommand, int, IDataProcessResult<T>> getProcessResult, bool useTransaction = false)
        {
            return new SqlDataQueryInfo<T>()
            {
                CommandText = storedProcedure,
                CommandType = CommandType.StoredProcedure,
                GetProcessResult = getProcessResult,
                UseTransaction = useTransaction,
                Data = data
            };
        }

        public List<SqlParameter> Parameters { get; } = new List<SqlParameter>();

        public CommandType CommandType { get; set; }
        public string CommandText { get; set; }
        public Func<T, SqlCommand, int, IDataProcessResult<T>> GetProcessResult { get; set; }
        public bool UseTransaction { get; set; }
        public T Data { get; set; }

        public SqlCommand CreateCommand(SqlConnection connection)
        {
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = CommandText,
                CommandType = CommandType
            };

            Parameters.ForEach((p) => command.Parameters.Add(p));

            return command;
        }

        public SqlCommand CreateCommand(SqlConnection connection, SqlTransaction transaction)
        {
            var command = new SqlCommand()
            {
                Connection = connection,
                Transaction = transaction,
                CommandText = CommandText,
                CommandType = CommandType
            };

            Parameters.ForEach((p) => command.Parameters.Add(p));

            return command;
        }
    }
}
