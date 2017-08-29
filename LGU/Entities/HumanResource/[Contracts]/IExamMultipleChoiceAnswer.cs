namespace LGU.Entities.HumanResource
{
    public interface IExamMultipleChoiceAnswer
    {
        IExam Exam { get; }
        IMultipleChoiceQuestion Question { get; }
        IMultipleChoiceCandidateAnswer Answer { get; set; }
        bool? IsCorrect { get; set; }
    }
}
