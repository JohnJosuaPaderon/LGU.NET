using System;

namespace LGU.Entities.HumanResource
{
    public class Exam : Entity<long>, IExam
    {
        public Exam(IApplication application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public IApplication Application { get; }
        public DateTime Date { get; set; }
        public IExamSet Set { get; set; }
        public int TotalScore { get; set; }
    }
}
