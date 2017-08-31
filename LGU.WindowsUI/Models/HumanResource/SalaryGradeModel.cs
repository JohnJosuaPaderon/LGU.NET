using LGU.Entities.HumanResource;
using System.Collections.ObjectModel;

namespace LGU.Models.HumanResource
{
    public sealed class SalaryGradeModel : ModelBase<ISalaryGrade>
    {
        public SalaryGradeModel(ISalaryGrade source) : base(source)
        {
            Id = source.Id;
            Number = source.Number;
            Batch = source.Batch;
            Steps = new ObservableCollection<SalaryGradeStepModel>();
            Steps.Add(new SalaryGradeStepModel(new SalaryGradeStep(source, 1)));
            Steps.Add(new SalaryGradeStepModel(new SalaryGradeStep(source, 2)));
            Steps.Add(new SalaryGradeStepModel(new SalaryGradeStep(source, 3)));
            Steps.Add(new SalaryGradeStepModel(new SalaryGradeStep(source, 4)));
            Steps.Add(new SalaryGradeStepModel(new SalaryGradeStep(source, 5)));
            Steps.Add(new SalaryGradeStepModel(new SalaryGradeStep(source, 6)));
            Steps.Add(new SalaryGradeStepModel(new SalaryGradeStep(source, 7)));
            Steps.Add(new SalaryGradeStepModel(new SalaryGradeStep(source, 8)));
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
            return new SalaryGrade(Batch, Number)
            {
                Id = Id
            };
        }
    }
}
