using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class ResolveTimeLogList : IResolveTimeLogList
    {
        public IEnumerable<ITimeLog> TimeLogs { get; set; }

        public IEnumerableProcessResult<ITimeLog> Execute()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<ITimeLog>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<ITimeLog>> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
