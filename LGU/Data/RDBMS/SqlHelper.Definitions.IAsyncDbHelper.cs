using LGU.Data.Extensions;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LGU.Data.Rdbms
{
    partial class SqlHelper
    {
        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            try
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
                        return new ProcessResult(ex);
                    }
                    finally
                    {
                        queryInfo.InvokeIfUsingTransaction(transaction.Dispose);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult(ex);
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, SqlConnection connection, SqlTransaction transaction)
        {
            using (var command = queryInfo.CreateCommand(connection, transaction))
            {
                return queryInfo.GetProcessResult(command, await command.ExecuteNonQueryAsync());
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            try
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
                        return new ProcessResult<T>(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, SqlConnection connection, SqlTransaction transaction)
        {
            using (var command = queryInfo.CreateCommand(connection, transaction))
            {
                return queryInfo.GetProcessResult(queryInfo.Data, command, await command.ExecuteNonQueryAsync());
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, IDataConverter<T, SqlDataReader> converter)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync())
                {
                    try
                    {
                        using (var command = queryInfo.CreateCommand(connection))
                        {
                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                if (reader.HasRows)
                                {
                                    return await converter.FromReaderAsync(reader);
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
                        return new ProcessResult<T>(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, IEnumerableProcessResult<T>> getFromReader)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync())
                {
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
                        return new EnumerableProcessResult<T>(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<T>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, IDataConverter<T, SqlDataReader> converter)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync())
                {
                    try
                    {
                        using (var command = queryInfo.CreateCommand(connection))
                        {
                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                if (reader.HasRows)
                                {
                                    return await converter.EnumerableFromReaderAsync(reader);
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
                        return new EnumerableProcessResult<T>(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<T>(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<object, T> converter)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync())
                {
                    try
                    {
                        using (var command = queryInfo.CreateCommand(connection))
                        {
                            return new ProcessResult<T>(converter(await command.ExecuteScalarAsync()));
                        }
                    }
                    catch (Exception ex)
                    {
                        return new ProcessResult<T>(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }
    }
}
