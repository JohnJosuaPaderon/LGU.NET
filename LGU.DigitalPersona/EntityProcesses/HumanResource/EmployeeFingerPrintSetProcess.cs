using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeFingerPrintSetProcess : HumanResourceProcessBase
    {
        protected readonly IEmployeeFingerPrintSetConverter<SqlDataReader> Converter;

        public EmployeeFingerPrintSetProcess(IConnectionStringSource connectionStringSource, IEmployeeFingerPrintSetConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
