namespace LGU.Entities.HumanResource
{
    public class MultipleChoiceQuestion : ExamQuestion
    {
        public MultipleChoiceQuestion(ExamSet set, int? maxAnswerCount) : base(set, ExamQuestionType.MultipleChoice)
        {
            MaxAnswerCount = maxAnswerCount;
        }

        public int? MaxAnswerCount { get; }
    }
}
