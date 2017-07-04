using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LGU.Data.RDBMS
{
    public class SqlQueryInfo : IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter>
    {
        public List<SqlParameter> Parameters { get; } = new List<SqlParameter>();

        public CommandType CommandType { get; set; }
        public string CommandText { get; set; }
        public Func<SqlCommand, int, IProcessResult> GetProcessResult { get; set; }
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
}
