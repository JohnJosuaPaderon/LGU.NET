using System;

namespace LGU.Entities.HumanResource
{
    public abstract class ExamQuestion : Entity<long>
    {
        public ExamQuestion(ExamSet set, ExamQuestionType type)
        {
            Set = set ?? throw new ArgumentNullException(nameof(set));
            Type = type;
        }

        public ExamSet Set { get; }
        public string Description { get; set; }
        public ExamQuestionType Type { get; }
        public int Points { get; set; }
    }
}
