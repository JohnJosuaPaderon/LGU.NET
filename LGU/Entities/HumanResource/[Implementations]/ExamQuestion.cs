using System;

namespace LGU.Entities.HumanResource
{
    public abstract class ExamQuestion : Entity<long>, IExamQuestion
    {
        public ExamQuestion(IExamSet set, ExamQuestionType type)
        {
            Set = set ?? throw new ArgumentNullException(nameof(set));
            Type = type;
        }

        public IExamSet Set { get; }
        public string Description { get; set; }
        public ExamQuestionType Type { get; }
        public int Points { get; set; }
    }
}
