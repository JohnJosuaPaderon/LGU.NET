using LGU.Processes;
using System;
using System.Data.Common;

namespace LGU.Data.Rdbms
{
    public interface IDbHelper<TConnection, TTransaction, TCommand, TParameter, TDataReader>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
        where TCommand : DbCommand
        where TParameter : DbParameter
        where TDataReader : DbDataReader
    {
        IProcessResult ExecuteNonQuery(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo);
        IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, TConnection, TTransaction, TCommand, TParameter> queryInfo);
        IProcessResult<T> ExecuteReader<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IProcessResult<T>> getFromReader);
        IEnumerableProcessResult<T> ExecuteReaderEnumerable<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<TDataReader, IEnumerableProcessResult<T>> getFromReader);
        IProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> queryInfo, Func<object, IProcessResult<T>> converter);
    }   
}
