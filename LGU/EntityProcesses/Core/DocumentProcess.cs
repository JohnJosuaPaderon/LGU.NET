using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class DocumentProcess : CoreProcessBase
    {
        protected readonly IDocumentConverter _Converter;

        public DocumentProcess(IConnectionStringSource connectionStringSource, IDocumentConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
