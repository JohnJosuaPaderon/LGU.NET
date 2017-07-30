namespace LGU.Entities.HumanResource
{
    public sealed class MultipleImageChoiceQuestion : ExamQuestion
    {
        public MultipleImageChoiceQuestion(ExamSet set, int? maxAnswerCount) : base(set, ExamQuestionType.MultipleImageChoice)
        {
            MaxAnswerCount = maxAnswerCount;
        }

        public int? MaxAnswerCount { get; }
    }
}
