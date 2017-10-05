namespace LGU.Entities.HumanResource
{
    public interface IEmployeeWorkdaySchedule : IEntity<long>
    {
        IEmployee Employee { get; set; }
        bool Sunday { get; set; }
        bool Monday { get; set; }
        bool Tuesday { get; set; }
        bool Wednesday { get; set; }
        bool Thursday { get; set; }
        bool Friday { get; set; }
        bool Saturday { get; set; }
    }
}
