using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace LGU.Data.RDBMS
{
    public interface IDbDataQueryInfo<TData, TConnection, TTransaction, TCommand, TParameter>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
        where TCommand : DbCommand
        where TParameter : DbParameter
    {
        List<TParameter> Parameters { get; }
        CommandType CommandType { get; set; }
        string CommandText { get; set; }
        TData Data { get; set; }
        Func<TData, TCommand, int, IDataProcessResult<TData>> GetProcessResult { get; set; }
        TCommand CreateCommand(TConnection connection);
        TCommand CreateCommand(TConnection connection, TTransaction transaction);
        bool UseTransaction { get; set; }
    }
}
