namespace LGU.Entities.Core
{
    public interface IUserType : IEntity<short>
    {
        string Description { get; set; }
    }
}
