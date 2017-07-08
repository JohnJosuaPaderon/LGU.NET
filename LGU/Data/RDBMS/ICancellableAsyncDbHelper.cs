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
        Task<IDataProcessResult<T>> ExecuteNonQueryAsync<T>(IDbDataQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        Task<IDataProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, CancellationToken, Task<IDataProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken);
        Task<IEnumerableDataProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, CancellationToken, Task<IEnumerableDataProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken);
        Task<IDataProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, IDataProcessResult<T>> converter, CancellationToken cancellationToken);
    }
}
