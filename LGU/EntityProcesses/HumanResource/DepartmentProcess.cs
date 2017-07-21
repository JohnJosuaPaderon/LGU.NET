using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class DepartmentProcess : HumanResourceProcessBase
    {
        protected readonly IDepartmentConverter<SqlDataReader> Converter;

        public DepartmentProcess(IConnectionStringSource connectionStringSource, IDepartmentConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
