using System;

namespace LGU.Entities.HumanResource
{
    public class ExamMultipleChoiceAnswer
    {
        public ExamMultipleChoiceAnswer(Exam exam, MultipleChoiceQuestion question)
        {
            Exam = exam ?? throw new ArgumentNullException(nameof(exam));
            Question = question ?? throw new ArgumentNullException(nameof(question));
        }

        public Exam Exam { get; }
        public MultipleChoiceQuestion Question { get; }
        public MultipleChoiceCandidateAnswer Answer { get; set; }

        public static bool operator ==(ExamMultipleChoiceAnswer left, ExamMultipleChoiceAnswer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExamMultipleChoiceAnswer left, ExamMultipleChoiceAnswer right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as ExamMultipleChoiceAnswer;
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
