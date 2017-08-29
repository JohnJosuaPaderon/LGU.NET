using System;

namespace LGU.Entities.HumanResource
{
    public class MultipleImageChoiceCandidateAnswer : Entity<long>, IMultipleImageChoiceCandidateAnswer
    {
        public MultipleImageChoiceCandidateAnswer(IMultipleImageChoiceQuestion question)
        {
            Question = question ?? throw new ArgumentNullException(nameof(question));
        }

        public IMultipleImageChoiceQuestion Question { get; }
        public string Path { get; set; }
        public byte[] Data { get; set; }
        public bool IsCorrect { get; set; }
    }
}
