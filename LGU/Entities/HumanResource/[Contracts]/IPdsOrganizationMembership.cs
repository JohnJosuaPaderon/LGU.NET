namespace LGU.Entities.HumanResource
{
    public interface IPdsOrganizationMembership : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; set; }
        IPdsOrganization Organization { get; set; }
        string Description { get; set; }
    }
}
