using System.Threading.Tasks;

namespace LGU.Core.EntityManagers
{
    public interface IEntityManager<T, TIdentifier>
    {
        Task<T> InsertAsync(T data);
        Task<T> GetByIdAsync(ulong id);
        Task<T> DeleteAsync(T data);
        Task<T> UpdateAsync(T data);
    }
}
