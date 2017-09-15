namespace LGU.Entities.HumanResource
{
    public interface IPdsSpecialSkill : IEntity<long>
    {
        IPersonalDataSheet PersonalDataSheet { get; set; }
        string Description { get; set; }
    }
}
