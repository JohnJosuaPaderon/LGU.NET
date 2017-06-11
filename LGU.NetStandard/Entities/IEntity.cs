namespace LGU.Entities
{
    /// <summary>
    /// Exposes a single property that represents the whole entity
    /// </summary>
    /// <typeparam name="TIdentifier">Type of the <see cref="IEntity{TIdentifier}.Id"/> property</typeparam>
    public interface IEntity<TIdentifier>
    {
        /// <summary>
        /// The property that represents the whole entity
        /// </summary>
        TIdentifier Id { get; }
    }
}
