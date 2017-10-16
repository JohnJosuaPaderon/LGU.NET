using LGU.EntityConverters.Core;

namespace LGU.EntityProcesses.Core
{
    public abstract class DocumentPathTypeProcess : CoreProcessBase
    {
        protected readonly IDocumentPathTypeConverter _Converter;

        public DocumentPathTypeProcess(IConnectionStringSource connectionStringSource, IDocumentPathTypeConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
