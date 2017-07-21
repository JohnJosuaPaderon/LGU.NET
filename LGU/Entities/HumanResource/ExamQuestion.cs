using System;

namespace LGU.Entities.HumanResource
{
    public class ExamQuestion : Entity<long>
    {
        public ExamQuestion(ExamSet set)
        {
            Set = set ?? throw new ArgumentNullException(nameof(set));
        }

        public ExamSet Set { get; }
        public string Description { get; set; }
        public ExamQuestionType Type { get; set; }
    }
}
