namespace LGU.Entities.HumanResource
{
    public interface IDepartment : IEntity<int>
    {
        string Description { get; set; }
        string Abbreviation { get; set; }
        IDepartmentHead Head { get; set; }
    }
}
