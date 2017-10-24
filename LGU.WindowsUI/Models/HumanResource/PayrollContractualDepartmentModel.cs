using LGU.Entities.HumanResource;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollContractualDepartmentModel : ModelBase<IPayrollContractualDepartment>
    {
        public PayrollContractualDepartmentModel(IPayrollContractualDepartment source) : base(source)
        {
            Employees = new ObservableCollection<PayrollContractualEmployeeModel>();

            Department = source?.Department != null ? new DepartmentModel(source.Department) : null;
            Payroll = source?.Payroll != null ? new PayrollModel(source.Payroll) : null;
            Head = source?.Head != null ? new EmployeeModel(source.Head) : null;
            Ordinal = source?.Ordinal ?? default(int);

            TryInitializeEmployees();
        }

        public ObservableCollection<PayrollContractualEmployeeModel> Employees { get; }

        private DepartmentModel _Department;
        public DepartmentModel Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
        }

        private PayrollModel _Payroll;
        public PayrollModel Payroll
        {
            get { return _Payroll; }
            set { SetProperty(ref _Payroll, value); }
        }

        private EmployeeModel _Head;
        public EmployeeModel Head
        {
            get { return _Head; }
            set { SetProperty(ref _Head, value); }
        }

        private int _Ordinal;
        public int Ordinal
        {
            get { return _Ordinal; }
            set { SetProperty(ref _Ordinal, value); }
        }

        private void TryInitializeEmployees()
        {
            if (Source?.Employees.Any() ?? false)
            {
                foreach (var employee in Source.Employees)
                {
                    Employees.Add(new PayrollContractualEmployeeModel(employee));
                }
            }
        }

        public override IPayrollContractualDepartment GetSource()
        {
            if (Source != null)
            {
                foreach (var employee in Employees)
                {
                    Source.Employees.Add(employee.GetSource());
                }
            }

            return Source;
        }

        public static bool operator ==(PayrollContractualDepartmentModel left, PayrollContractualDepartmentModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PayrollContractualDepartmentModel left, PayrollContractualDepartmentModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as PayrollContractualDepartmentModel;

            return
                (Department?.Equals(value.Department) ?? default(bool)) &&
                (Payroll?.Equals(value.Payroll) ?? default(bool));

        }

        public override int GetHashCode()
        {
            return
                Department?.GetHashCode() ?? default(int) ^
                Payroll?.GetHashCode() ?? default(int);
        }
    }
}
