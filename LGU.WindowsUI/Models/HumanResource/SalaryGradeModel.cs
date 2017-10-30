using LGU.Entities.HumanResource;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LGU.Models.HumanResource
{
    public sealed class SalaryGradeModel : ModelBase<ISalaryGrade>
    {
        public static SalaryGradeModel TryCreate(ISalaryGrade salaryGrade)
        {
            return salaryGrade != null ? new SalaryGradeModel(salaryGrade) : null;
        }

        public static SalaryGradeModel TryCreate(ISalaryGrade salaryGrade, IEnumerable<SalaryGradeStepModel> steps)
        {
            return salaryGrade != null ? new SalaryGradeModel(salaryGrade, steps) : null;
        }

        public SalaryGradeModel(ISalaryGrade source) : base(source)
        {
            Id = source.Id;
            Number = source.Number;
            Batch = source.Batch;
            Steps = new ObservableCollection<SalaryGradeStepModel>
            {
                new SalaryGradeStepModel(new SalaryGradeStep(source, 1)),
                new SalaryGradeStepModel(new SalaryGradeStep(source, 2)),
                new SalaryGradeStepModel(new SalaryGradeStep(source, 3)),
                new SalaryGradeStepModel(new SalaryGradeStep(source, 4)),
                new SalaryGradeStepModel(new SalaryGradeStep(source, 5)),
                new SalaryGradeStepModel(new SalaryGradeStep(source, 6)),
                new SalaryGradeStepModel(new SalaryGradeStep(source, 7)),
                new SalaryGradeStepModel(new SalaryGradeStep(source, 8))
            };
        }

        public SalaryGradeModel(ISalaryGrade source, IEnumerable<SalaryGradeStepModel> steps) : base(source)
        {
            Id = source.Id;
            Number = source.Number;
            Batch = source.Batch;
            Steps = new ObservableCollection<SalaryGradeStepModel>(steps);
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private int _Number;
        public int Number
        {
            get { return _Number; }
            set { SetProperty(ref _Number, value); }
        }

        private ISalaryGradeBatch _Batch;
        public ISalaryGradeBatch Batch
        {
            get { return _Batch; }
            set { SetProperty(ref _Batch, value); }
        }

        public ObservableCollection<SalaryGradeStepModel> Steps { get; set; }

        public override ISalaryGrade GetSource()
        {
            Source.Id = Id;

            return Source;
        }

        public static bool operator ==(SalaryGradeModel left, SalaryGradeModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SalaryGradeModel left, SalaryGradeModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is SalaryGradeModel value)
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
