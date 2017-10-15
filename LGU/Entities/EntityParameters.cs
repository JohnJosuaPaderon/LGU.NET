namespace LGU.Entities
{
    public abstract class EntityParameters : IEntityParameters
    {
        public EntityParameters()
        {
            Id = "@_Id";
        }

        public string Id { get; }
    }
}
