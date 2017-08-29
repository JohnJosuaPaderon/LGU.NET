using System;

namespace LGU.Entities.HumanResource
{
    public interface ITimeLog : IEntity<long>
    {
        IEmployee Employee { get; }
        DateTime? LoginDate { get; set; }
        DateTime? LogoutDate { get; set; }
        ITimeLogType Type { get; set; }
        bool? State { get; set; }
    }
}
