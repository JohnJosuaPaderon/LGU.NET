using System;
using System.Data.Common;

namespace LGU.Data.RDBMS
{
    public interface IDbHelper<TConnection, TTransaction, TCommand, TParameter, TDataReader>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
        where TCommand : DbCommand
        where TParameter : DbParameter
        where TDataReader : DbDataReader
    {
        IProcessResult ExecuteNonQuery(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo);
        IDataProcessResult<T> ExecuteNonQuery<T>(IDataDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo);
        IDataProcessResult<T> ExecuteReader<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IDataProcessResult<T>> getFromReader);
        IEnumerableDataProcessResult<T> ExecuteReaderEnumerable<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IEnumerableDataProcessResult<T>> getFromReader);
        IDataProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, IDataProcessResult<T>> converter);
    }
}
