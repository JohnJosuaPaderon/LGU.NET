using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class DepartmentHeadProcess : HumanResourceProcessBase
    {
        protected readonly IDepartmentHeadConverter<SqlDataReader> r_Converter;

        public DepartmentHeadProcess(IConnectionStringSource connectionStringSource, IDepartmentHeadConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
