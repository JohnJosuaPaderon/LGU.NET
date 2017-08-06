using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class ResolveTimeLogList : IResolveTimeLogList
    {
        public IEnumerable<TimeLog> TimeLogs { get; set; }

        public IEnumerableProcessResult<TimeLog> Execute()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<TimeLog>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<TimeLog>> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
