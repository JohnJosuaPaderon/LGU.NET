using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;

namespace LGU.Utilities
{
    public class TimeLogResolver
    {
        public TimeLogResolver(IEnumerable<TimeLog> timeLogs)
        {
            TimeLogs = timeLogs ?? throw new ArgumentNullException(nameof(timeLogs));
        }

        public IEnumerable<TimeLog> TimeLogs { get; }

        public IEnumerable<TimeLog> Resolve()
        {
            var timeLogs = new List<TimeLog>();

            foreach (var rawTimeLog in TimeLogs)
            {
                
            }

            return timeLogs;
        }
    }
}
