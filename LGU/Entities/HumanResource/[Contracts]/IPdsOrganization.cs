namespace LGU.Entities.HumanResource
{
    public interface IPdsOrganization : IEntity<long>
    {
        string Name { get; set; }
        string Address { get; set; }
        bool AllowVoluntaryWork { get; set; }
    }
}
