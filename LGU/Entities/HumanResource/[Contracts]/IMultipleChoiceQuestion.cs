namespace LGU.Entities.HumanResource
{
    public interface IMultipleChoiceQuestion : IExamQuestion
    {
        int? MaxAnswerCount { get; }
    }
}
