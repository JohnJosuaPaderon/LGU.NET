using System;

namespace LGU.Entities.HumanResource
{
    public class MultipleChoiceCandidateAnswer : Entity<long>, IMultipleChoiceCandidateAnswer
    {
        public MultipleChoiceCandidateAnswer(IMultipleChoiceQuestion question)
        {
            Question = question ?? throw new ArgumentNullException(nameof(question));
        }

        public IMultipleChoiceQuestion Question { get; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
