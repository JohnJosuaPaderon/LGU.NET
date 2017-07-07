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

        private ulong _Id;
        public ulong Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { SetProperty(ref _FirstName, value); }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set { SetProperty(ref _MiddleName, value); }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { SetProperty(ref _LastName, value); }
        }

        private string _NameExtension;
        public string NameExtension
        {
            get { return _NameExtension; }
            set { SetProperty(ref _NameExtension, value); }
        }

        private Department _Department;
        public Department Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
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
