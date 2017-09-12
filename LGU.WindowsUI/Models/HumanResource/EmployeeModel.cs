using LGU.Entities.HumanResource;
using LGU.Utilities;

namespace LGU.Models.HumanResource
{
    public class EmployeeModel : ModelBase<IEmployee>
    {
        public EmployeeModel(IEmployee source) : base(source)
        {
            Id = source.Id;
            FirstName = source.FirstName;
            MiddleName = source.MiddleName;
            LastName = source.LastName;
            NameExtension = source.NameExtension;
            Department = source.Department;
            Position = source.Position;
            Type = source.Type;
            EmploymentStatus = source.EmploymentStatus;
            WorkTimeSchedule = source.WorkTimeSchedule;
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

        private IDepartment _Department;
        public IDepartment Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
        }

        private IPosition _Position;
        public IPosition Position
        {
            get { return _Position; }
            set { SetProperty(ref _Position, value); }
        }

        private IEmployeeType _Type;
        public IEmployeeType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private IEmploymentStatus _EmploymentStatus;
        public IEmploymentStatus EmploymentStatus
        {
            get { return _EmploymentStatus; }
            set { SetProperty(ref _EmploymentStatus, value); }
        }

        private IWorkTimeSchedule _WorkTimeSchedule;
        public IWorkTimeSchedule WorkTimeSchedule
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
            return new Employee()
            {
                Id = Id,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                NameExtension = NameExtension,
                Department = Department,
                EmploymentStatus = EmploymentStatus,
                Position = Position,
                Type = Type,
                WorkTimeSchedule = WorkTimeSchedule
            };
        }
    }
}
