using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class DocumentPathTypeProcess : CoreProcessBase
    {
        protected readonly IDocumentPathTypeConverter<SqlDataReader> r_Converter;

        public DocumentPathTypeProcess(IConnectionStringSource connectionStringSource, IDocumentPathTypeConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
