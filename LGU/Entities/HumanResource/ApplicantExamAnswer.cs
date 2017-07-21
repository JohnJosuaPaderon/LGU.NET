using System;

namespace LGU.Entities.HumanResource
{
    public class ApplicantExamAnswer : Entity<long>
    {
        public ApplicantExamAnswer(Applicant applicant, ExamQuestion question)
        {
            Applicant = applicant ?? throw new ArgumentNullException(nameof(applicant));
            Question = question ?? throw new ArgumentNullException(nameof(question));
        }

        public Applicant Applicant { get; }
        public ExamQuestion Question { get; }
    }
}
