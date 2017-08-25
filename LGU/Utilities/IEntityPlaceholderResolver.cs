using LGU.Entities;

namespace LGU.Utilities
{
    public interface IEntityPlaceholderResolver<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        string Resolve(T entity, string placeholder);
    }
}
