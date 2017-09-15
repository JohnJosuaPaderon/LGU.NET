namespace LGU.Entities.HumanResource
{
    public interface IPdsEducationLevel : IEntity<short>
    {
        string Description { get; set; }
        string SortCode { get; set; }
    }
}
