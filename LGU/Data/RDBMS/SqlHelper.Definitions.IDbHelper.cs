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

        public IDataProcessResult<T> ExecuteNonQuery<T>(IDataDbQueryInfo<T, SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo)
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
                        var result = queryInfo.GetProcessResult(command, command.ExecuteNonQuery());
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
        }

        public IEnumerableDataProcessResult<T> ExecuteReaderEnumerable<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<SqlDataReader, IEnumerableDataProcessResult<T>> getFromReader)
        {
            using (var connection = ConnectionEstablisher.Establish())
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
        }

        public IDataProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<SqlConnection, SqlTransaction, SqlCommand, SqlParameter> queryInfo, Func<object, IDataProcessResult<T>> converter)
        {
            using (var connection = ConnectionEstablisher.Establish())
            {
                using (var command = queryInfo.CreateCommand(connection))
                {
                    return converter(command.ExecuteScalar());
                }
            }
        }
    }
}
