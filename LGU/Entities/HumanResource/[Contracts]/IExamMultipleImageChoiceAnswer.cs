namespace LGU.Entities.HumanResource
{
    public interface IExamMultipleImageChoiceAnswer
    {
        IExam Exam { get; }
        IMultipleImageChoiceQuestion Question { get; }
        IMultipleImageChoiceCandidateAnswer Answer { get; set; }
        bool? IsCorrect { get; set; }
    }
}
