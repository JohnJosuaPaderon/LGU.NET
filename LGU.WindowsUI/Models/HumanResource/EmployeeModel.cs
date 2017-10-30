using LGU.Entities.HumanResource;
using LGU.Models.Core;

namespace LGU.Models.HumanResource
{
    public class EmployeeModel : PersonModelBase<IEmployee>
    {
        public static EmployeeModel TryCreate(IEmployee employee)
        {
            return employee != null ? new EmployeeModel(employee) : null;
        }

        public EmployeeModel(IEmployee source) : base(source)
        {
            Department = DepartmentModel.TryCreate(source.Department);
            Position = PositionModel.TryCreate(source.Position);
            Type = EmployeeTypeModel.TryCreate(source.Type);
            EmploymentStatus = EmploymentStatusModel.TryCreate(source.EmploymentStatus);
            WorkTimeSchedule = WorkTimeScheduleModel.TryCreate(source.WorkTimeSchedule);
            MonthlySalary = source.MonthlySalary;
        }
        
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

        public override IEmployee GetSource()
        {
            Source.Department = Department?.GetSource();
            Source.EmploymentStatus = EmploymentStatus?.GetSource();
            Source.Position = Position?.GetSource();
            Source.Type = Type?.GetSource();
            Source.WorkTimeSchedule = WorkTimeSchedule?.GetSource();
            Source.MonthlySalary = MonthlySalary;

            return Source;
        }
    }
}
