using System.Threading;
using System.Threading.Tasks;

namespace LGU.Processes
{
    public interface IDataManager<T>
    {
        IProcessResult<T> Insert(T data);
        IProcessResult<T> Update(T data);
        IProcessResult<T> Delete(T data);
        IEnumerableProcessResult<T> GetList();
        Task<IProcessResult<T>> InsertAsync(T data);
        Task<IProcessResult<T>> UpdateAsync(T data);
        Task<IProcessResult<T>> DeleteAsync(T data);
        Task<IEnumerableProcessResult<T>> GetListAsync();
        Task<IProcessResult<T>> InsertAsync(T data, CancellationToken cancellationToken);
        Task<IProcessResult<T>> UpdateAsync(T data, CancellationToken cancellationToken);
        Task<IProcessResult<T>> DeleteAsync(T data, CancellationToken cancellationToken);
        Task<IEnumerableProcessResult<T>> GetListAsync(CancellationToken cancellationToken);
    }
}
