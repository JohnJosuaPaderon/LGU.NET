using System;

namespace LGU.Entities.HumanResource
{
    public class TimeLogType : Entity<short>
    {
        public string Description { get; set; }
        public TimeSpan WorkTimeLength { get; set; }
        public TimeSpan? BreakTimeLength { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
