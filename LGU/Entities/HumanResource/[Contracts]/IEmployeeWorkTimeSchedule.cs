namespace LGU.Entities.HumanResource
{
    public interface IEmployeeWorkTimeSchedule
    {
        IEmployee Employee { get; set; }
        IWorkTimeSchedule WorkTimeSchedule { get; set; }
    }
}
