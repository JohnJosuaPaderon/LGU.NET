using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ApplicationDocumentProcess : HumanResourceProcessBase
    {
        protected readonly IApplicationDocumentConverter<SqlDataReader> Converter;

        public ApplicationDocumentProcess(IConnectionStringSource connectionStringSource, IApplicationDocumentConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }
    }
}
