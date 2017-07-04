using LGU.Data.Extensions;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LGU.Data.RDBMS
{
    partial class SqlHelper : IAsyncDbHelper<SqlConnection, SqlTransaction, SqlCommand, SqlParameter, SqlDataReader>
    {
        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                SqlTransaction transaction = null;

                queryInfo.InvokeIfUsingTransaction(() => transaction = connection.BeginTransaction());

                try
                {
                    using (var command = queryInfo.CreateCommand(connection, transaction))
                    {
                        var result = queryInfo.GetProcessResult(command, await command.ExecuteNonQueryAsync());
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

        public async Task<IDataProcessResult<T>> ExecuteNonQueryAsync<T>(IDbDataQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                SqlTransaction transaction = null;

                queryInfo.InvokeInTransaction(() => transaction = connection.BeginTransaction());

                try
                {
                    using (var command = queryInfo.CreateCommand(connection, transaction))
                    {
                        var result = queryInfo.GetProcessResult(queryInfo.Data, command, await command.ExecuteNonQueryAsync());
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

        public async Task<IDataProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, IDataProcessResult<T>> getFromReader)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            return getFromReader(reader);
                        }
                        else
                        {
                            return new DataProcessResult<T>(ProcessResultStatus.Success, "No result.");
                        }
                    }
                }
            }
        }

        public async Task<IDataProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, Task<IDataProcessResult<T>>> getFromReaderAsync)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
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

        public async Task<IEnumerableDataProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, IEnumerableDataProcessResult<T>> getFromReader)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            return getFromReader(reader);
                        }
                        else
                        {
                            return new EnumerableDataProcessResult<T>(ProcessResultStatus.Success, "No result.");
                        }
                    }
                }
            }
        }

        public async Task<IEnumerableDataProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, Task<IEnumerableDataProcessResult<T>>> getFromReaderAsync)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
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

        public async Task<IDataProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<object, IDataProcessResult<T>> converter)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    return converter(await command.ExecuteScalarAsync());
                }
            }
        }
    }
}
