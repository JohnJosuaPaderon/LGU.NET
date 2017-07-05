using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public class EmployeeModel : ModelBase<Employee>
    {
        public EmployeeModel(Employee source) : base(source)
        {
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
    }
}
