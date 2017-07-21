using LGU.Data.Extensions;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Data.Rdbms
{
    partial class SqlHelper
    {
        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
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

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
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
                        var result = queryInfo.GetProcessResult(queryInfo.Data, command, await command.ExecuteNonQueryAsync(cancellationToken));
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

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, IDataConverter<T, SqlDataReader> converter, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                if (connection == null)
                {
                    return new ProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (reader.HasRows)
                            {
                                return await converter.FromReaderAsync(reader, cancellationToken);
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

        public async Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, IDataConverter<T, SqlDataReader> converter, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                if (connection == null)
                {
                    return new EnumerableProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (reader.HasRows)
                            {
                                return await converter.EnumerableFromReaderAsync(reader, cancellationToken);
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

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<object, T> converter, CancellationToken cancellationToken)
        {
            using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
            {
                if (connection == null)
                {
                    return new ProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return new ProcessResult<T>(converter(await command.ExecuteScalarAsync(cancellationToken)));
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
