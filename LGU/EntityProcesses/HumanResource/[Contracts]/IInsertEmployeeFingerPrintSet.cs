﻿using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertEmployeeFingerPrintSet : IDataProcess<EmployeeFingerPrintSet>
    {
        EmployeeFingerPrintSet FingerPrintSet { get; set; }
    }
}
