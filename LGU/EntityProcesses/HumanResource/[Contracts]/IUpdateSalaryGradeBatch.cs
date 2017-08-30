﻿using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IUpdateSalaryGradeBatch : IProcess<ISalaryGradeBatch>
    {
        ISalaryGradeBatch SalaryGradeBatch { get; set; }
    }
}
