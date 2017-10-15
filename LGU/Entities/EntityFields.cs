namespace LGU.Entities
{
    public abstract class EntityFields : IEntityFields
    {
        public EntityFields()
        {
            Id = "Id";
        }

        public string Id { get; }
    }
}
