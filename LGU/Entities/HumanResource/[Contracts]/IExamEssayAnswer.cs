namespace LGU.Entities.HumanResource
{
    public interface IExamEssayAnswer
    {
        IExam Exam { get; }
        IEssayQuestion Question { get; }
        string Description { get; set; }
        bool? IsCorrect { get; set; }
    }
}
