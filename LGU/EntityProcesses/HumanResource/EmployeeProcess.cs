﻿using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeProcess : HumanResourceProcessBase
    {
        protected readonly IEmployeeConverter<SqlDataReader> Converter;

        public EmployeeProcess(IConnectionStringSource connectionStringSource, IEmployeeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}