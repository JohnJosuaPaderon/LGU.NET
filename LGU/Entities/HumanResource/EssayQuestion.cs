namespace LGU.Entities.HumanResource
{
    public class EssayQuestion : ExamQuestion
    {
        public EssayQuestion(ExamSet set) : base(set, ExamQuestionType.Essay)
        {
        }
    }
}
