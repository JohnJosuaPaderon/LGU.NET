namespace LGU.Entities.HumanResource
{
    public interface IEmployeeWorkdayScheduleParameters
    {
        string Id { get; }
        string EmployeeId { get; }
        string Sunday { get; }
        string Monday { get; }
        string Tuesday { get; }
        string Wednesday { get; }
        string Thursday { get; }
        string Friday { get; }
        string Saturday { get; }
    }
}
