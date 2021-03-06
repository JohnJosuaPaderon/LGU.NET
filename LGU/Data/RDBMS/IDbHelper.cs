﻿using LGU.Processes;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Data.Rdbms
{
    public interface IDbHelper<TConnection, TTransaction, TCommand, TParameter>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
        where TCommand : DbCommand
        where TParameter : DbParameter
    {
        IProcessResult ExecuteNonQuery(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo);
        IProcessResult ExecuteNonQuery(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, TConnection connection, TTransaction transaction);
        IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo);
        IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo, TConnection connection, TTransaction transaction);
        IProcessResult<T> ExecuteReader<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, IDataConverter<T> converter);
        IEnumerableProcessResult<T> ExecuteReaderEnumerable<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, IDataConverter<T> converter);
        IProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, T> converter);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, TConnection connection, TTransaction transaction);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo, TConnection connection, TTransaction transaction);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, IDataConverter<T> converter);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, IDataConverter<T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, T> converter);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, TConnection connection, TTransaction transaction, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo, TConnection connection, TTransaction transaction,    CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, IDataConverter<T> converter, CancellationToken cancellationToken);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, IDataConverter<T> converter, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, T> converter, CancellationToken cancellationToken);
    }   
}
