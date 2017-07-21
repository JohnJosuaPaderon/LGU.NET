using LGU.Data.Extensions;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LGU.Data.Rdbms
{
    public partial class SqlHelper : IDbHelper<SqlConnection, SqlTransaction, SqlCommand, SqlParameter, SqlDataReader>
    {
        public SqlHelper(SqlConnectionEstablisher connectionEstablisher)
        {
            ConnectionEstablisher = connectionEstablisher;
        }
        
        private SqlConnectionEstablisher ConnectionEstablisher { get; }

        public IProcessResult ExecuteNonQuery(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                if (connection == null)
                {
                    return new ProcessResult(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

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

        public IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                if (connection == null)
                {
                    return new ProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

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

        public IProcessResult<T> ExecuteReader<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, IDataConverter<T, SqlDataReader> converter)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                if (connection == null)
                {
                    return new ProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
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

        public IEnumerableProcessResult<T> ExecuteReaderEnumerable<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, IDataConverter<T, SqlDataReader> converter)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                if (connection == null)
                {
                    return new EnumerableProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
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

        public IProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<object, T> converter)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                if (connection == null)
                {
                    return new ProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

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
    }
}
