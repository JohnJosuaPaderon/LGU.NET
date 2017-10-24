using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertDepartmentHead<TConnection, TTransaction> : IProcess<IDepartmentHead>, IProcess<IDepartmentHead, TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        IDepartmentHead DepartmentHead { get; set; }
    }
}
