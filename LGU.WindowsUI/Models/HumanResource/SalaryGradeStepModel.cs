using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class SalaryGradeStepModel : ModelBase<ISalaryGradeStep>
    {
        public static SalaryGradeStepModel TryCreate(ISalaryGradeStep salaryGradeStep)
        {
            return salaryGradeStep != null ? new SalaryGradeStepModel(salaryGradeStep) : null;
        }

        public SalaryGradeStepModel(ISalaryGradeStep source) : base(source)
        {
            Id = source.Id;
            SalaryGrade = SalaryGradeModel.TryCreate(source.SalaryGrade);
            Step = source.Step;
            Amount = source.Amount;
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private SalaryGradeModel _SalaryGrade;
        public SalaryGradeModel SalaryGrade
        {
            get { return _SalaryGrade; }
            set { SetProperty(ref _SalaryGrade, value); }
        }

        private int _Step;
        public int Step
        {
            get { return _Step; }
            set { SetProperty(ref _Step, value); }
        }

        private decimal _Amount;
        public decimal Amount
        {
            get { return _Amount; }
            set { SetProperty(ref _Amount, value); }
        }

        public override ISalaryGradeStep GetSource()
        {
            Source.Id = Id;
            Source.Amount = Amount;

            return Source;
        }

        public static bool operator ==(SalaryGradeStepModel left, SalaryGradeStepModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SalaryGradeStepModel left, SalaryGradeStepModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is SalaryGradeStepModel value)
            {
                return (Id == 0 || value.Id == 0) ? false : Id == value.Id;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
