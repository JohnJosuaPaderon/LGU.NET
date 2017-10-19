using LGU.Entities.HumanResource;
using LGU.Utilities;

namespace LGU.Models.HumanResource
{
    public class EmployeeModel : ModelBase<IEmployee>
    {
        public EmployeeModel(IEmployee source) : base(source)
        {
            Id = source?.Id ?? default(long);
            FirstName = source?.FirstName;
            MiddleName = source?.MiddleName;
            LastName = source?.LastName;
            NameExtension = source?.NameExtension;
            Department = source?.Department != null ? new DepartmentModel(source?.Department) : null;
            Position = source?.Position != null ? new PositionModel(source?.Position) : null;
            Type = source?.Type != null ? new EmployeeTypeModel(source?.Type) : null;
            EmploymentStatus = source?.EmploymentStatus != null ? new EmploymentStatusModel(source?.EmploymentStatus) : null;
            WorkTimeSchedule = source?.WorkTimeSchedule != null ? new WorkTimeScheduleModel(source?.WorkTimeSchedule) : null;
            MonthlySalary = source?.MonthlySalary ?? default(decimal);
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

        private decimal _MonthlySalary;
        public decimal MonthlySalary
        {
            get { return _MonthlySalary; }
            set { SetProperty(ref _MonthlySalary, value); }
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
            if (Source != null)
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
                Source.MonthlySalary = MonthlySalary;
            }

            return Source;
        }

        public static bool operator ==(EmployeeModel left, EmployeeModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EmployeeModel left, EmployeeModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is EmployeeModel value)
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
