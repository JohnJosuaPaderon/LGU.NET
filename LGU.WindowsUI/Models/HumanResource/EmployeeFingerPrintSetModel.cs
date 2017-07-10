using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class EmployeeFingerPrintSetModel : ModelBase<EmployeeFingerPrintSet>
    {
        public EmployeeFingerPrintSetModel(EmployeeFingerPrintSet source) : base(source)
        {
            Employee = source.Employee;
            LeftThumb = new FingerPrintModel(source.LeftThumb);
            LeftIndexFinger = new FingerPrintModel(source.LeftIndexFinger);
            LeftMiddleFinger = new FingerPrintModel(source.LeftMiddleFinger);
            LeftRingFinger = new FingerPrintModel(source.LeftRingFinger);
            LeftLittleFinger = new FingerPrintModel(source.LeftLittleFinger);
            RightThumb = new FingerPrintModel(source.RightThumb);
            RightIndexFinger = new FingerPrintModel(source.RightIndexFinger);
            RightMiddleFinger = new FingerPrintModel(source.RightMiddleFinger);
            RightRingFinger = new FingerPrintModel(source.RightRingFinger);
            RightLittleFinger = new FingerPrintModel(source.RightLittleFinger);
        }

        private Employee _Employee;
        public Employee Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }

        private FingerPrintModel _LeftThumb;
        public FingerPrintModel LeftThumb
        {
            get { return _LeftThumb; }
            set { SetProperty(ref _LeftThumb, value); }
        }

        private FingerPrintModel _LeftIndexFinger;
        public FingerPrintModel LeftIndexFinger
        {
            get { return _LeftIndexFinger; }
            set { SetProperty(ref _LeftIndexFinger, value); }
        }

        private FingerPrintModel _LeftMiddleFinger;
        public FingerPrintModel LeftMiddleFinger
        {
            get { return _LeftMiddleFinger; }
            set { SetProperty(ref _LeftMiddleFinger, value); }
        }

        private FingerPrintModel _LeftRingFinger;
        public FingerPrintModel LeftRingFinger
        {
            get { return _LeftRingFinger; }
            set { SetProperty(ref _LeftRingFinger, value); }
        }

        private FingerPrintModel _LeftLittleFinger;
        public FingerPrintModel LeftLittleFinger
        {
            get { return _LeftLittleFinger; }
            set { SetProperty(ref _LeftLittleFinger, value); }
        }

        private FingerPrintModel _RightThumb;
        public FingerPrintModel RightThumb
        {
            get { return _RightThumb; }
            set { SetProperty(ref _RightThumb, value); }
        }

        private FingerPrintModel _RightIndexFinger;
        public FingerPrintModel RightIndexFinger
        {
            get { return _RightIndexFinger; }
            set { SetProperty(ref _RightIndexFinger, value); }
        }

        private FingerPrintModel _RightMiddleFinger;
        public FingerPrintModel RightMiddleFinger
        {
            get { return _RightMiddleFinger; }
            set { SetProperty(ref _RightMiddleFinger, value); }
        }

        private FingerPrintModel _RightRingFinger;
        public FingerPrintModel RightRingFinger
        {
            get { return _RightRingFinger; }
            set { SetProperty(ref _RightRingFinger, value); }
        }

        private FingerPrintModel _RightLittleFinger;
        public FingerPrintModel RightLittleFinger
        {
            get { return _RightLittleFinger; }
            set { SetProperty(ref _RightLittleFinger, value); }
        }

        public override EmployeeFingerPrintSet GetSource()
        {
            var fingerPrintSet = new EmployeeFingerPrintSet(Employee);
            fingerPrintSet.LeftThumb.Data = LeftThumb?.Data;
            fingerPrintSet.LeftIndexFinger.Data = LeftIndexFinger?.Data;
            fingerPrintSet.LeftMiddleFinger.Data = LeftMiddleFinger?.Data;
            fingerPrintSet.LeftRingFinger.Data = LeftRingFinger?.Data;
            fingerPrintSet.LeftLittleFinger.Data = LeftLittleFinger?.Data;
            fingerPrintSet.RightThumb.Data = RightThumb?.Data;
            fingerPrintSet.RightIndexFinger.Data = RightIndexFinger?.Data;
            fingerPrintSet.RightMiddleFinger.Data = RightMiddleFinger?.Data;
            fingerPrintSet.RightRingFinger.Data = RightRingFinger?.Data;
            fingerPrintSet.RightLittleFinger.Data = RightLittleFinger?.Data;

            return fingerPrintSet;
        }
    }
}
