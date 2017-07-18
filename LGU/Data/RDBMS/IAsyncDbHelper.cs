using LGU.Processes;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace LGU.Data.RDBMS
{
    public interface IAsyncDbHelper<TConnection, TTransaction, TCommand, TParameter, TDataReader>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
        where TCommand : DbCommand
        where TParameter : DbParameter
        where TDataReader : DbDataReader
    {
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbDataQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IProcessResult<T>> getFromReader);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, Task<IProcessResult<T>>> getFromReaderAsync);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IEnumerableProcessResult<T>> getFromReader);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, Task<IEnumerableProcessResult<T>>> getFromReaderAsync);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, IProcessResult<T>> converter);
    }
}
