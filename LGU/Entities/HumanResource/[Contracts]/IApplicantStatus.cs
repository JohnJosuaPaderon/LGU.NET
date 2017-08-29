namespace LGU.Entities.HumanResource
{
    public interface IApplicantStatus : IEntity<short>
    {
        string Description { get; set; }
    }
}
