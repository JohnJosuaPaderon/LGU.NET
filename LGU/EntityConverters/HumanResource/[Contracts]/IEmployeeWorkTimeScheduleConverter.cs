﻿using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeWorkTimeScheduleConverter<TDataReader> : IDataConverter<EmployeeWorkTimeSchedule, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
