using System;

namespace LGU.Entities.HumanResource
{
    public class Exam : Entity<long>
    {
        public Exam(Application application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public Application Application { get; }
        public DateTime ExamDate { get; set; }
        public ExamSet Set { get; set; }
        public int TotalScore { get; set; }
    }
}
