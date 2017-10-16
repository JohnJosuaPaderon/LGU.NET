using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Processes
{
    public interface IDataConverter<T, TDataReader>
        where TDataReader : DbDataReader
    {
        IProcessResult<T> FromReader(TDataReader reader);
        Task<IProcessResult<T>> FromReaderAsync(TDataReader reader);
        Task<IProcessResult<T>> FromReaderAsync(TDataReader reader, CancellationToken cancellationToken);
        IEnumerableProcessResult<T> EnumerableFromReader(TDataReader reader);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(TDataReader reader);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(TDataReader reader, CancellationToken cancellationToken);
    }

    public interface IDataConverter<T>
    {
        IProcessResult<T> FromReader(DbDataReader reader);
        Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader);
        Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken);
        IEnumerableProcessResult<T> EnumerableFromReader(DbDataReader reader);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader);
        Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken);
    }
}
