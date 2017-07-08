using System.Threading;
using System.Threading.Tasks;

namespace LGU
{
    public interface IDataManager<T>
    {
        IDataProcessResult<T> Insert(T data);
        IDataProcessResult<T> Update(T data);
        IDataProcessResult<T> Delete(T data);
        IEnumerableDataProcessResult<T> GetList();
        Task<IDataProcessResult<T>> InsertAsync(T data);
        Task<IDataProcessResult<T>> UpdateAsync(T data);
        Task<IDataProcessResult<T>> DeleteAsync(T data);
        Task<IEnumerableDataProcessResult<T>> GetListAsync();
        Task<IDataProcessResult<T>> InsertAsync(T data, CancellationToken cancellationToken);
        Task<IDataProcessResult<T>> UpdateAsync(T data, CancellationToken cancellationToken);
        Task<IDataProcessResult<T>> DeleteAsync(T data, CancellationToken cancellationToken);
        Task<IEnumerableDataProcessResult<T>> GetListAsync(CancellationToken cancellationToken);
    }
}
