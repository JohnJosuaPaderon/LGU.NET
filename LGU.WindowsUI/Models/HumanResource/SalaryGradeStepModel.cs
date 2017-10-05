using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class SalaryGradeStepModel : ModelBase<ISalaryGradeStep>
    {
        public SalaryGradeStepModel(ISalaryGradeStep source) : base(source)
        {
            Id = source?.Id ?? default(long);
            SalaryGrade = source?.SalaryGrade;
            Step = source?.Step ?? default(int);
            Amount = source?.Amount ?? default(decimal);
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private ISalaryGrade _SalaryGrade;
        public ISalaryGrade SalaryGrade
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
            if (Source != null)
            {
                Source.Id = Id;
                Source.Amount = Amount;

                return Source;
            }
            else
            {
                return null;
            }
        }
    }
}
