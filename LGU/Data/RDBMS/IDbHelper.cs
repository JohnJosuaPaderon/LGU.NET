using LGU.Processes;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Data.Rdbms
{
    public interface IDbHelper<TConnection, TTransaction, TCommand, TParameter, TDataReader>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
        where TCommand : DbCommand
        where TParameter : DbParameter
        where TDataReader : DbDataReader
    {
        IProcessResult ExecuteNonQuery(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo);
        IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo);
        IProcessResult<T> ExecuteReader<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IProcessResult<T>> getFromReader);
        IEnumerableProcessResult<T> ExecuteReaderEnumerable<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IEnumerableProcessResult<T>> getFromReader);
        IProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, T> converter); Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IProcessResult<T>> getFromReader);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, Task<IProcessResult<T>>> getFromReaderAsync);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IEnumerableProcessResult<T>> getFromReader);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, Task<IEnumerableProcessResult<T>>> getFromReaderAsync);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, T> converter);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, CancellationToken, Task<IProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, CancellationToken, Task<IEnumerableProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, T> converter, CancellationToken cancellationToken);
    }   
}
