using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Processes
{
    public interface IDbDataReaderToEnumerableProcessResultConverter
    {
        IEnumerableProcessResult<T> EnumerableFromReader<T>(DbDataReader reader, Func<DbDataReader, T> convert);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync<T>(DbDataReader reader, Func<DbDataReader, Task<T>> convertAsync);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync<T>(DbDataReader reader, Func<DbDataReader, T> convert);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync<T>(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, CancellationToken, Task<T>> convertAsync);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync<T>(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, T> convert);
    }
}
