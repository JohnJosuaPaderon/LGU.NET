namespace LGU.Entities.Core
{
    public interface IUserStatus : IEntity<short>
    {
        string Description { get; set; }
    }
}
