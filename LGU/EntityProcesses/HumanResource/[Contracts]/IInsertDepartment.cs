﻿using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertDepartment : IProcess<IDepartment>
    {
        IDepartment Department { get; set; }
    }
}
