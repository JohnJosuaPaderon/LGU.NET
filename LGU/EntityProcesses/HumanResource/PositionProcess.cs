using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class PositionProcess : HumanResourceProcessBase
    {
        protected readonly IPositionConverter<SqlDataReader> Converter;

        public PositionProcess(IConnectionStringSource connectionStringSource, IPositionConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
