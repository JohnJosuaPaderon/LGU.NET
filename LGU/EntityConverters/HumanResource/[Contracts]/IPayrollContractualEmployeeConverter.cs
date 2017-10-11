﻿using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public interface IPayrollContractualEmployeeConverter<TDataReader> : IDataConverter<IPayrollContractualEmployee, TDataReader>
        where TDataReader : DbDataReader
    {
        IDataConverterProperty<IEmployee> PEmployee { get; }
        IDataConverterProperty<IPayroll> PPayroll { get; }
        IDataConverterProperty<decimal> PMonthlyRate { get; }
        IDataConverterProperty<decimal?> PWithholdingTax { get; }
        IDataConverterProperty<decimal?> PHdmfPremiumPs { get; }
        IDataConverterProperty<decimal> PTimeLogDeduction { get; }
    }
}
