using System;

namespace LGU.Entities.HumanResource
{
    public class MultipleChoiceCandidateAnswer : Entity<long>
    {
        public MultipleChoiceCandidateAnswer(MultipleChoiceQuestion question)
        {
            Question = question ?? throw new ArgumentNullException(nameof(question));
        }

        public MultipleChoiceQuestion Question { get; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
