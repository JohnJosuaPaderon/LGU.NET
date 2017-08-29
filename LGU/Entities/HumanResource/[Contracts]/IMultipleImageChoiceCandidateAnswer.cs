namespace LGU.Entities.HumanResource
{
    public interface IMultipleImageChoiceCandidateAnswer : IEntity<long>
    {
        IMultipleImageChoiceQuestion Question { get; }
        string Path { get; set; }
        byte[] Data { get; set; }
        bool IsCorrect { get; set; }
    }
}
