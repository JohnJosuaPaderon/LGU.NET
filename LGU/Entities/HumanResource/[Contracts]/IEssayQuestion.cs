namespace LGU.Entities.HumanResource
{
    public interface IEssayQuestion : IExamQuestion
    {
        int? MaxAnswerLength { get; set; }
    }
}
