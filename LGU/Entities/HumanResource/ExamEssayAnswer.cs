using System;

namespace LGU.Entities.HumanResource
{
    public class ExamEssayAnswer
    {
        public ExamEssayAnswer(Exam exam, EssayQuestion question)
        {
            Exam = exam ?? throw new ArgumentNullException(nameof(exam));
            Question = question ?? throw new ArgumentNullException(nameof(question));
        }

        public Exam Exam { get; }
        public EssayQuestion Question { get; }
        public string Description { get; set; }

        public static bool operator ==(ExamEssayAnswer left, ExamEssayAnswer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExamEssayAnswer left, ExamEssayAnswer right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as ExamEssayAnswer;
            return
                Exam.Equals(value.Exam) &&
                Question.Equals(value.Question);
        }

        public override int GetHashCode()
        {
            return
                Exam.GetHashCode() ^
                Question.GetHashCode();
        }
    }
}
