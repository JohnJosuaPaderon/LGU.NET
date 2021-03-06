﻿using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertSalaryGradeBatch : IProcess<ISalaryGradeBatch>
    {
        ISalaryGradeBatch SalaryGradeBatch { get; set; }
    }
}
