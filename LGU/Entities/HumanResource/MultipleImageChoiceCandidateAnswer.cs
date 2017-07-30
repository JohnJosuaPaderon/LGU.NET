using System;

namespace LGU.Entities.HumanResource
{
    public class MultipleImageChoiceCandidateAnswer : Entity<long>
    {
        public MultipleImageChoiceCandidateAnswer(MultipleImageChoiceQuestion question)
        {
            Question = question ?? throw new ArgumentNullException(nameof(question));
        }

        public MultipleImageChoiceQuestion Question { get; }
        public string Path { get; set; }
        public byte[] Data { get; set; }
        public bool IsCorrect { get; set; }
    }
}
