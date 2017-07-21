namespace LGU.Entities.HumanResource
{
    public class MultipleChoiceQuestion : ExamQuestion
    {
        public MultipleChoiceQuestion(ExamSet set, bool isMultipleAnswer) : base(set)
        {
            IsMultipleAnswer = isMultipleAnswer;
        }

        public bool IsMultipleAnswer { get; }
    }
}
