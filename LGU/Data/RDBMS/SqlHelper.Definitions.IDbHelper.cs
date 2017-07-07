using LGU.Data.Extensions;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LGU.Data.RDBMS
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

        public IDataProcessResult<T> ExecuteNonQuery<T>(IDbDataQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                if (connection == null)
                {
                    return new DataProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
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
                    return new DataProcessResult<T>(ex);
                }
                finally
                {
                    queryInfo.InvokeInTransaction(transaction.Dispose);
                }
            }
        }

        public IDataProcessResult<T> ExecuteReader<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, IDataProcessResult<T>> getFromReader)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                if (connection == null)
                {
                    return new DataProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
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
                                return getFromReader(reader);
                            }
                            else
                            {
                                return new DataProcessResult<T>(ProcessResultStatus.Success, "No result.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new DataProcessResult<T>(ex);
                }
            }
        }

        public IEnumerableDataProcessResult<T> ExecuteReaderEnumerable<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, IEnumerableDataProcessResult<T>> getFromReader)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                if (connection == null)
                {
                    return new EnumerableDataProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = command.ExecuteReader())
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
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new EnumerableDataProcessResult<T>(ex);
                }
                
            }
        }

        public IDataProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<object, IDataProcessResult<T>> converter)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                if (connection == null)
                {
                    return new DataProcessResult<T>(ProcessResultStatus.Failed, "Unable to connect to database.");
                }

                try
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return converter(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new DataProcessResult<T>(ex);
                }
            }
        }
    }
}
