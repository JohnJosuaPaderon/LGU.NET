namespace LGU.Entities.HumanResource
{
    public interface IExamQuestion : IEntity<long>
    {
        IExamSet Set { get; }
        string Description { get; set; }
        ExamQuestionType Type { get; }
        int Points { get; set; }
    }
}
