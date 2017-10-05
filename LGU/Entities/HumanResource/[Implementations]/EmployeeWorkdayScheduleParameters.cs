namespace LGU.Entities.HumanResource
{
    public sealed class EmployeeWorkdayScheduleParameters : IEmployeeWorkdayScheduleParameters
    {
        public EmployeeWorkdayScheduleParameters()
        {
            Id = "@_Id";
            EmployeeId = "@_EmployeeId";
            Sunday = "@_Sunday";
            Monday = "@_Monday";
            Tuesday = "@_Tuesday";
            Wednesday = "@_Wednesday";
            Thursday = "@_Thursday";
            Friday = "@_Friday";
            Saturday = "@_Saturday";
        }

        public string Id { get; }
        public string EmployeeId { get; }
        public string Sunday { get; }
        public string Monday { get; }
        public string Tuesday { get; }
        public string Wednesday { get; }
        public string Thursday { get; }
        public string Friday { get; }
        public string Saturday { get; }
    }
}
