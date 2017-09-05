using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeSalaryGradeStepProcess : HumanResourceProcessBase
    {
        public EmployeeSalaryGradeStepProcess(IConnectionStringSource connectionStringSource, IEmployeeSalaryGradeStepConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }

        protected readonly IEmployeeSalaryGradeStepConverter<SqlDataReader> r_Converter;
    }
}
