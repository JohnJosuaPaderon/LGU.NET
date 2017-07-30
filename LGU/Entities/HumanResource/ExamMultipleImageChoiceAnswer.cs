using System;

namespace LGU.Entities.HumanResource
{
    public class ExamMultipleImageChoiceAnswer
    {
        public ExamMultipleImageChoiceAnswer(Exam exam, MultipleImageChoiceQuestion question)
        {
            Exam = exam ?? throw new ArgumentNullException(nameof(exam));
            Question = question ?? throw new ArgumentNullException(nameof(question));
        }

        public Exam Exam { get; }
        public MultipleImageChoiceQuestion Question { get; }
        public MultipleImageChoiceCandidateAnswer Answer { get; set; }
        public bool? IsCorrect { get; set; }

        public static bool operator ==(ExamMultipleImageChoiceAnswer left, ExamMultipleImageChoiceAnswer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExamMultipleImageChoiceAnswer left, ExamMultipleImageChoiceAnswer right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as ExamMultipleImageChoiceAnswer;
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
