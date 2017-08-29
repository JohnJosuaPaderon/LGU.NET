namespace LGU.Entities.Core
{
    public interface IModule : IEntity<short>
    {
        string Name { get; set; }
    }
}
