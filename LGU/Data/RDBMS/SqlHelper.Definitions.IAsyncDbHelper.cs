using LGU.Data.Extensions;
using LGU.Processes;
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
                if (connection == null)
                {
                    return new ProcessResult(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

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

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbDataQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                if (connection == null)
                {
                    return new ProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

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
                    return new ProcessResult<T>(ex);
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, IProcessResult<T>> getFromReader)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                if (connection == null)
                {
                    return new ProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
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
                                return new ProcessResult<T>(ProcessResultStatus.Success, "No result.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new ProcessResult<T>(ex);
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, Task<IProcessResult<T>>> getFromReaderAsync)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                if (connection == null)
                {
                    return new ProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
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
                                return new ProcessResult<T>(ProcessResultStatus.Success, "No result.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new ProcessResult<T>(ex);
                }
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, IEnumerableProcessResult<T>> getFromReader)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                if (connection == null)
                {
                    return new EnumerableProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
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
                                return new EnumerableProcessResult<T>(ProcessResultStatus.Success, "No result.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new EnumerableProcessResult<T>(ex);
                }
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, Task<IEnumerableProcessResult<T>>> getFromReaderAsync)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                if (connection == null)
                {
                    return new EnumerableProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
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
                                return new EnumerableProcessResult<T>(ProcessResultStatus.Success, "No result.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new EnumerableProcessResult<T>(ex);
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<object, IProcessResult<T>> converter)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync())
            {
                if (connection == null)
                {
                    return new ProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return converter(await command.ExecuteScalarAsync());
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new ProcessResult<T>(ex);
                }
            }
        }
    }
}
