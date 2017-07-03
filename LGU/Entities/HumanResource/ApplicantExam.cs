using System;

namespace LGU.Entities.HumanResource
{
    public class ApplicantExam : Entity<ulong>
    {
        public ApplicantExam(Applicant applicant)
        {
            Applicant = applicant ?? throw new ArgumentNullException(nameof(applicant));
        }

        public Applicant Applicant { get; }
        public ExamType ExamType { get; set; }
        public ExamStatus ExamStatus { get; set; }
        public int ExamScore { get; set; }
        public DateTime ExamDate { get; set; }

        public override string ToString()
        {
            return Applicant.ToString();
        }
    }
}
