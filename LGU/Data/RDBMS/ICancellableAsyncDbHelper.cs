using LGU.Processes;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Data.RDBMS
{
    public interface ICancellableAsyncDbHelper<TConnection, TTransaction, TCommand, TParameter, TDataReader>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
        where TCommand : DbCommand
        where TParameter : DbParameter
        where TDataReader : DbDataReader
    {
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbDataQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, CancellationToken, Task<IProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, CancellationToken, Task<IEnumerableProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, IProcessResult<T>> converter, CancellationToken cancellationToken);
    }
}
