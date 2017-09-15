namespace LGU.Entities.HumanResource
{
    public interface IPdsNonAcademicRecognition : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; set; }
        string Description { get; set; }
    }
}
