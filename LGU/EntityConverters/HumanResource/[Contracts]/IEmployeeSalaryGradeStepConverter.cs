﻿using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IEmployeeSalaryGradeStepConverter<TDataReader> : IDataConverter<IEmployeeSalaryGradeStep, TDataReader>
        where TDataReader : DbDataReader
    {
    }
}
