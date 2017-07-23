using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class PositionProcess : HumanResourceProcessBase
    {
        protected readonly IPositionConverter<SqlDataReader> r_Converter;

        public PositionProcess(IConnectionStringSource connectionStringSource, IPositionConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
