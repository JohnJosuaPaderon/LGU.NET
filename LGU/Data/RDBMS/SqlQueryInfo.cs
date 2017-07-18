using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LGU.Data.Rdbms
{
    public sealed class SqlQueryInfo : IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter>
    {
        public static SqlQueryInfo CreateProcedureQueryInfo(string storedProcedure, GetProcessResultDelegate<SqlCommand> getProcessResult, bool useTransaction = false)
        {
            return new SqlQueryInfo()
            {
                CommandText = storedProcedure,
                CommandType = CommandType.StoredProcedure,
                GetProcessResult = getProcessResult,
                UseTransaction = useTransaction
            };
        }

        public static SqlQueryInfo CreateProcedureQueryInfo(string storedProcedure, bool useTransaction = false)
        {
            return CreateProcedureQueryInfo(storedProcedure, null, useTransaction);
        }

        public List<SqlParameter> Parameters { get; } = new List<SqlParameter>();

        public CommandType CommandType { get; set; }
        public string CommandText { get; set; }
        public GetProcessResultDelegate<SqlCommand> GetProcessResult { get; set; }
        public bool UseTransaction { get; set; }

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

    public sealed class SqlQueryInfo<T> : IDbQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter>
    {
        public static SqlQueryInfo<T> CreateProcedureQueryInfo(T data, string storedProcedure, GetProcessResultDelegate<T, SqlCommand> getProcessResult, bool useTransaction = false)
        {
            return new SqlQueryInfo<T>()
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
        public GetProcessResultDelegate<T, SqlCommand> GetProcessResult { get; set; }
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
