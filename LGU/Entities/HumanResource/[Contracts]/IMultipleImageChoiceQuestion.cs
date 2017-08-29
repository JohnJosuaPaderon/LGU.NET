namespace LGU.Entities.HumanResource
{
    public interface IMultipleImageChoiceQuestion : IExamQuestion
    {
        int? MaxAnswerCount { get; }
    }
}
