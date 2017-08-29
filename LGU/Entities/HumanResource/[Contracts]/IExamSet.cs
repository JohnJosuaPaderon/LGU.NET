namespace LGU.Entities.HumanResource
{
    public interface IExamSet : IEntity<int>
    {
        string Description { get; set; }
        int PassingScore { get; set; }
    }
}
