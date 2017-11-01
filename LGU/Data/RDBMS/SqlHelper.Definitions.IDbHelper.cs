using LGU.Data.Extensions;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LGU.Data.Rdbms
{
    public partial class SqlHelper : IDbHelper<SqlConnection, SqlTransaction, SqlCommand, SqlParameter>
    {
        public SqlHelper(SqlConnectionEstablisher connectionEstablisher)
        {
            ConnectionEstablisher = connectionEstablisher;
        }
        
        private SqlConnectionEstablisher ConnectionEstablisher { get; }

        public IProcessResult ExecuteNonQuery(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    SqlTransaction transaction = null;

                    queryInfo.InvokeIfUsingTransaction(() =>
                    {
                        transaction = connection.BeginTransaction();
                    });

                    try
                    {
                        using (var command = queryInfo.CreateCommand(connection, transaction))
                        {
                            var result = queryInfo.GetProcessResult(command, command.ExecuteNonQuery());
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
            catch (Exception ex)
            {
                return new ProcessResult(ex);
            }
        }

        public IProcessResult ExecuteNonQuery(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, SqlConnection connection, SqlTransaction transaction)
        {
            using (var command = queryInfo.CreateCommand(connection, transaction))
            {
                return queryInfo.GetProcessResult(command, command.ExecuteNonQuery());
            }
        }

        public IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    SqlTransaction transaction = null;

                    queryInfo.InvokeInTransaction(() =>
                    {
                        transaction = connection.BeginTransaction();
                    });

                    try
                    {
                        using (var command = queryInfo.CreateCommand(connection, transaction))
                        {
                            var result = queryInfo.GetProcessResult(queryInfo.Data, command, command.ExecuteNonQuery());
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
                    finally
                    {
                        queryInfo.InvokeInTransaction(transaction.Dispose);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, SqlConnection connection, SqlTransaction transaction)
        {
            using (var command = queryInfo.CreateCommand(connection, transaction))
            {
                return queryInfo.GetProcessResult(queryInfo.Data, command, command.ExecuteNonQuery());
            }
        }

        public IProcessResult<T> ExecuteReader<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, IDataConverter<T> converter)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    try
                    {
                        using (var command = queryInfo.CreateCommand(connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    converter.InitializeDependency();

                                    return converter.FromReader(reader);
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
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public IEnumerableProcessResult<T> ExecuteReaderEnumerable<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, IDataConverter<T> converter)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    try
                    {
                        using (var command = queryInfo.CreateCommand(connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    converter.InitializeDependency();

                                    return converter.EnumerableFromReader(reader);
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
            catch (Exception ex)
            {
                return new EnumerableProcessResult<T>(ex);
            }
        }

        public IProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<object, T> converter)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    try
                    {
                        using (var command = queryInfo.CreateCommand(connection))
                        {
                            return new ProcessResult<T>(converter(command.ExecuteScalar()));
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
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
