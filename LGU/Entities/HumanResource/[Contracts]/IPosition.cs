namespace LGU.Entities.HumanResource
{
    public interface IPosition : IEntity<int>
    {
        string Description { get; set; }
        string Abbreviation { get; set; }
    }
}
