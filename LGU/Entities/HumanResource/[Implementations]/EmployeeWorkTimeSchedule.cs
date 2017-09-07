namespace LGU.Entities.HumanResource
{
    public class EmployeeWorkTimeSchedule : IEmployeeWorkTimeSchedule
    {
        public IEmployee Employee { get; set; }
        public IWorkTimeSchedule WorkTimeSchedule { get; set; }

        public static bool operator ==(EmployeeWorkTimeSchedule left, EmployeeWorkTimeSchedule right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EmployeeWorkTimeSchedule left, EmployeeWorkTimeSchedule right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as EmployeeWorkTimeSchedule;

            return
                Employee.Equals(value.Employee) &&
                WorkTimeSchedule.Equals(value.WorkTimeSchedule);
        }

        public override int GetHashCode()
        {
            return
                Employee.GetHashCode() ^
                WorkTimeSchedule.GetHashCode();
        }
    }
}
