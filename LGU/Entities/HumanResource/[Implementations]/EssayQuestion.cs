namespace LGU.Entities.HumanResource
{
    public sealed class EssayQuestion : ExamQuestion, IEssayQuestion
    {
        public EssayQuestion(IExamSet set) : base(set, ExamQuestionType.Essay)
        {
        }

        public int? MaxAnswerLength { get; set; }
    }
}
