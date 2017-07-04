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
        Task<IDataProcessResult<T>> ExecuteNonQueryAsync<T>(IDataDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo);
        Task<IDataProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IDataProcessResult<T>> getFromReader);
        Task<IDataProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, Task<IDataProcessResult<T>>> getFromReaderAsync);
        Task<IEnumerableDataProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IEnumerableDataProcessResult<T>> getFromReader);
        Task<IEnumerableDataProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, Task<IEnumerableDataProcessResult<T>>> getFromReaderAsync);
        Task<IDataProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, IDataProcessResult<T>> converter);
    }
}
