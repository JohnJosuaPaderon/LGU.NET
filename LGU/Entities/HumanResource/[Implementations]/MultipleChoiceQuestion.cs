namespace LGU.Entities.HumanResource
{
    public sealed class MultipleChoiceQuestion : ExamQuestion, IMultipleChoiceQuestion
    {
        public MultipleChoiceQuestion(IExamSet set, int? maxAnswerCount) : base(set, ExamQuestionType.MultipleChoice)
        {
            MaxAnswerCount = maxAnswerCount;
        }

        public int? MaxAnswerCount { get; }
    }
}
