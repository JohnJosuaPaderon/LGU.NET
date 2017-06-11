namespace LGU.Entities
{
    /// <summary>
    /// Base class for every entity that is represented by <see cref="Entity{TIdentifier}.Id"/>
    /// </summary>
    /// <typeparam name="TIdentifier">Type of the <see cref="Entity{TIdentifier}.Id"/> property</typeparam>
    public abstract class Entity<TIdentifier> : IEntity<TIdentifier>
    {
        /// <summary>
        /// The identifier of the entity
        /// </summary>
        public TIdentifier Id { get; set; }

        /// <summary>
        /// Default equality operator for <see cref="Entity{TIdentifier}"/>
        /// </summary>
        /// <param name="left">The left operand of the equality comparison</param>
        /// <param name="right">The right operand of the equality comparison</param>
        /// <returns></returns>
        public static bool operator ==(Entity<TIdentifier> left, Entity<TIdentifier> right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Default inequality operator for <see cref="Entity{TIdentifier}"/>; This only negates the equality operator
        /// </summary>
        /// <param name="left">The left operand of the inequality comparison</param>
        /// <param name="right">The right operand of the inequality comparison</param>
        /// <returns></returns>
        public static bool operator !=(Entity<TIdentifier> left, Entity<TIdentifier> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines the equality of the argument and of the instance
        /// </summary>
        /// <param name="obj">The argument to be compared to</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            
            var value = obj as Entity<TIdentifier>;
            return Id.Equals(value.Id);
        }

        /// <summary>
        /// Returns the hashcode of the instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
