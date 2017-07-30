namespace LGU.Entities.HumanResource
{
    public sealed class EssayQuestion : ExamQuestion
    {
        public EssayQuestion(ExamSet set) : base(set, ExamQuestionType.Essay)
        {
        }

        public int? MaxAnswerLength { get; set; }
    }
}
