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
}
