using LGU.Data.Extensions;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Data.RDBMS
{
    partial class SqlHelper : ICancellableAsyncDbHelper<SqlConnection, SqlTransaction, SqlCommand, SqlParameter, SqlDataReader>
    {
        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                SqlTransaction transaction = null;

                queryInfo.InvokeIfUsingTransaction(() => transaction = connection.BeginTransaction());

                try
                {
                    using (var command = queryInfo.CreateCommand(connection, transaction))
                    {
                        var result = queryInfo.GetProcessResult(command, await command.ExecuteNonQueryAsync(cancellationToken));
                        queryInfo.InvokeIfUsingTransaction(transaction.Commit);

                        return result;
                    }
                }
                catch (Exception ex)
                {
                    queryInfo.InvokeIfUsingTransaction(transaction.Rollback);
                    Debug.WriteLine(ex);
                    return new ProcessResult(ex);
                }
                finally
                {
                    queryInfo.InvokeIfUsingTransaction(transaction.Dispose);
                }
            }
        }

        public async Task<IDataProcessResult<T>> ExecuteNonQueryAsync<T>(IDataDbQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                SqlTransaction transaction = null;

                queryInfo.InvokeInTransaction(() => transaction = connection.BeginTransaction());

                try
                {
                    using (var command = queryInfo.CreateCommand(connection, transaction))
                    {
                        var result = queryInfo.GetProcessResult(command, await command.ExecuteNonQueryAsync(cancellationToken));
                        queryInfo.InvokeInTransaction(transaction.Commit);

                        return result;
                    }
                }
                catch (Exception ex)
                {
                    queryInfo.InvokeInTransaction(transaction.Rollback);
                    Debug.WriteLine(ex);
                    return new DataProcessResult<T>(ex);
                }
            }
        }

        public async Task<IDataProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, Task<IDataProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                    {
                        if (reader.HasRows)
                        {
                            await reader.ReadAsync(cancellationToken);
                            return await getFromReaderAsync(reader);
                        }
                        else
                        {
                            return new DataProcessResult<T>(ProcessResultStatus.Success, "No result.");
                        }
                    }
                }
            }
        }

        public async Task<IDataProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, CancellationToken, Task<IDataProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                    {
                        if (reader.HasRows)
                        {
                            await reader.ReadAsync(cancellationToken);
                            return await getFromReaderAsync(reader, cancellationToken);
                        }
                        else
                        {
                            return new DataProcessResult<T>(ProcessResultStatus.Success, "No result.");
                        }
                    }
                }
            }
        }

        public async Task<IEnumerableDataProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, CancellationToken, Task<IEnumerableDataProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                    {
                        if (reader.HasRows)
                        {
                            return await getFromReaderAsync(reader, cancellationToken);
                        }
                        else
                        {
                            return new EnumerableDataProcessResult<T>(ProcessResultStatus.Success, "No result.");
                        }
                    }
                }
            }
        }

        public async Task<IEnumerableDataProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, Task<IEnumerableDataProcessResult<T>>> getFromReaderAsync, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                    {
                        if (reader.HasRows)
                        {
                            return await getFromReaderAsync(reader);
                        }
                        else
                        {
                            return new EnumerableDataProcessResult<T>(ProcessResultStatus.Success, "No result.");
                        }
                    }
                }
            }
        }

        public async Task<IDataProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<object, IDataProcessResult<T>> converter, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    return converter(await command.ExecuteScalarAsync(cancellationToken));
                }
            }
        }
    }
}
