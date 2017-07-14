using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class EmployeeModel : ModelBase<Employee>
    {
        public EmployeeModel(Employee source) : base(source)
        {
            Id = source.Id;
            FirstName = source.FirstName;
            MiddleName = source.MiddleName;
            LastName = source.LastName;
            NameExtension = source.NameExtension;
            Department = source.Department;
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
            set { SetProperty(ref _MiddleName, value, RaiseFullName); }
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

        public string FullName
        {
            get
            {
                return GetSource().FullName;
            }
        }

        private Department _Department;
        public Department Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
        }

        private void RaiseFullName()
        {
            RaisePropertyChanged(nameof(FullName));
        }

        public override Employee GetSource()
        {
            return new Employee()
            {
                Id = Id,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                NameExtension = NameExtension,
                Department = Department
            };
        }
    }
}
