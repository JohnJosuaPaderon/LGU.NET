using LGU.Entities.HumanResource;
using LGU.Utilities;

namespace LGU.Models.HumanResource
{
    public class EmployeeModel : ModelBase<IEmployee>
    {
        public EmployeeModel(IEmployee source) : base(source ?? new Employee())
        {
            Id = source?.Id ?? default(long);
            FirstName = source?.FirstName;
            MiddleName = source?.MiddleName;
            LastName = source?.LastName;
            NameExtension = source?.NameExtension;
            Department = new DepartmentModel(source?.Department);
            Position = new PositionModel(source?.Position);
            Type = new EmployeeTypeModel(source?.Type);
            EmploymentStatus = new EmploymentStatusModel(source?.EmploymentStatus);
            WorkTimeSchedule = new WorkTimeScheduleModel(source?.WorkTimeSchedule);
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { SetProperty(ref _FirstName, value, RaiseFullName); }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                SetProperty(ref _MiddleName, value, () =>
                {
                    RaiseFullName();
                    RaiseMiddleInitials();
                });
            }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { SetProperty(ref _LastName, value, RaiseFullName); }
        }

        private string _NameExtension;
        public string NameExtension
        {
            get { return _NameExtension; }
            set { SetProperty(ref _NameExtension, value, RaiseFullName); }
        }

        public string MiddleInitials { get; private set; }
        public string FullName { get; private set; }
        public string InformalFullName { get; private set; }

        private DepartmentModel _Department;
        public DepartmentModel Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
        }

        private PositionModel _Position;
        public PositionModel Position
        {
            get { return _Position; }
            set { SetProperty(ref _Position, value); }
        }

        private EmployeeTypeModel _Type;
        public EmployeeTypeModel Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private EmploymentStatusModel _EmploymentStatus;
        public EmploymentStatusModel EmploymentStatus
        {
            get { return _EmploymentStatus; }
            set { SetProperty(ref _EmploymentStatus, value); }
        }

        private WorkTimeScheduleModel _WorkTimeSchedule;
        public WorkTimeScheduleModel WorkTimeSchedule
        {
            get { return _WorkTimeSchedule; }
            set { SetProperty(ref _WorkTimeSchedule, value); }
        }

        private void RaiseMiddleInitials()
        {
            MiddleInitials = MiddleInitialConstructor.Construct(MiddleName);
        }

        private void RaiseFullName()
        {
            FullName = FullNameConstructor.Construct(FirstName, MiddleName, LastName, NameExtension);
            InformalFullName = InformalFullNameConstructor.Construct(FirstName, MiddleInitials, LastName, NameExtension);
            RaisePropertyChanged(nameof(FullName));
            RaisePropertyChanged(nameof(InformalFullName));
        }

        public override IEmployee GetSource()
        {
            Source.Id = Id;
            Source.FirstName = FirstName;
            Source.MiddleName = MiddleName;
            Source.LastName = LastName;
            Source.NameExtension = NameExtension;
            Source.Department = Department?.GetSource();
            Source.EmploymentStatus = EmploymentStatus?.GetSource();
            Source.Position = Position?.GetSource();
            Source.Type = Type?.GetSource();
            Source.WorkTimeSchedule = WorkTimeSchedule?.GetSource();

            return Source;
        }
    }
}
