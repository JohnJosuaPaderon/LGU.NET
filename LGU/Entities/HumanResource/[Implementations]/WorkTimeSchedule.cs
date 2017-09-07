using System;

namespace LGU.Entities.HumanResource
{
    public sealed class WorkTimeSchedule : Entity<int>, IWorkTimeSchedule
    {
        public string Description { get; set; }
        public DateTime WorkTimeStart { get; set; }
        public DateTime WorkTImeEnd { get; set; }
        
        public override string ToString()
        {
            return Description;
        }
    }
}
