namespace LGU.Entities.HumanResource
{
    public interface IMultipleChoiceCandidateAnswer : IEntity<long>
    {
        IMultipleChoiceQuestion Question { get; }
        string Description { get; set; }
        bool IsCorrect { get; set; }
    }
}
