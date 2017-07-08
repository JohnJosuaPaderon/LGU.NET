﻿using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IDeleteEmployee : IDataProcess<Employee>, IAsyncDataProcess<Employee>, ICancellableAsyncDataProcess<Employee>
    {
        Employee Employee { get; set; }
    }
}
