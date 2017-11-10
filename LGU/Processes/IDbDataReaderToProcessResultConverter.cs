using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Processes
{
    public interface IDbDataReaderToProcessResultConverter
    {
        IProcessResult<T> FromReader<T>(DbDataReader reader, Func<DbDataReader, T> convert);
        Task<IProcessResult<T>> FromReaderAsync<T>(DbDataReader reader, Func<DbDataReader, Task<T>> convertAsync);
        Task<IProcessResult<T>> FromReaderAsync<T>(DbDataReader reader, Func<DbDataReader, T> convert);
        Task<IProcessResult<T>> FromReaderAsync<T>(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, CancellationToken, Task<T>> convertAsync);
        Task<IProcessResult<T>> FromReaderAsync<T>(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, T> convertAsync);
    }
}
