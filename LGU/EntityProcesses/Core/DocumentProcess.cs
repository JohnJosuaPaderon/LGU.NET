using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class DocumentProcess : CoreProcessBase
    {
        protected readonly IDocumentConverter<SqlDataReader> r_Converter;

        public DocumentProcess(IConnectionStringSource connectionStringSource, IDocumentConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
