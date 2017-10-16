using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class EmployeeWorkdayScheduleModel : ModelBase<IEmployeeWorkdaySchedule>
    {
        public EmployeeWorkdayScheduleModel(IEmployeeWorkdaySchedule source) : base(source)
        {
            Employee = source?.Employee != null ? new EmployeeModel(source.Employee) : null;
            Sunday = source?.Sunday ?? default(bool);
            Monday = source?.Monday ?? default(bool);
            Tuesday = source?.Tuesday ?? default(bool);
            Wednesday = source?.Wednesday ?? default(bool);
            Thursday = source?.Thursday ?? default(bool);
            Friday = source?.Friday ?? default(bool);
            Saturday = source?.Saturday ?? default(bool);
        }

        private EmployeeModel _Employee;
        public EmployeeModel Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }

        private bool _Sunday;
        public bool Sunday
        {
            get { return _Sunday; }
            set { SetProperty(ref _Sunday, value); }
        }

        private bool _Monday;
        public bool Monday
        {
            get { return _Monday; }
            set { SetProperty(ref _Monday, value); }
        }

        private bool _Tuesday;
        public bool Tuesday
        {
            get { return _Tuesday; }
            set { SetProperty(ref _Tuesday, value); }
        }

        private bool _Wednesday;
        public bool Wednesday
        {
            get { return _Wednesday; }
            set { SetProperty(ref _Wednesday, value); }
        }

        private bool _Thursday;
        public bool Thursday
        {
            get { return _Thursday; }
            set { SetProperty(ref _Thursday, value); }
        }

        private bool _Friday;
        public bool Friday
        {
            get { return _Friday; }
            set { SetProperty(ref _Friday, value); }
        }

        private bool _Saturday;
        public bool Saturday
        {
            get { return _Saturday; }
            set { SetProperty(ref _Saturday, value); }
        }

        public override IEmployeeWorkdaySchedule GetSource()
        {
            if (Source != null)
            {
                Source.Employee = Employee?.GetSource();
                Source.Sunday = Sunday;
                Source.Monday = Monday;
                Source.Tuesday = Tuesday;
                Source.Wednesday = Wednesday;
                Source.Thursday = Thursday;
                Source.Friday = Friday;
                Source.Saturday = Saturday;
            }

            return Source;
        }
    }
}
