﻿using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEmployeeFingerPrintSet : IProcess<IEmployeeFingerPrintSet>
    {
        IEmployeeFingerPrintSet FingerPrintSet { get; set; }
    }
}
