using LGU.Data.Rdbms;

namespace LGU.EntityProcesses
{
    public abstract class ProcessBase
    {
        protected readonly SqlHelper _SqlHelper;
        protected readonly string _SchemaName;

        public ProcessBase(IConnectionStringSource connectionStringSource, string schemaName)
        {
            _SqlHelper = new SqlHelper(new SqlConnectionEstablisher(connectionStringSource[schemaName]));
            _SchemaName = string.IsNullOrWhiteSpace(schemaName) ? "Core" : schemaName;
        }

        protected string GetQualifiedDbObjectName(string dbObjectName)
        {
            return $"{_SchemaName}.{dbObjectName}";
        }

        protected string GetQualifiedDbObjectName()
        {
            return GetQualifiedDbObjectName(GetType().Name);
        }
    }

    public abstract class ProcessBaseV2 : ProcessBase
    {
        protected readonly SqlConnectionEstablisher _ConnectionEstablisher;

        public ProcessBaseV2(IConnectionStringSource connectionStringSource, string schemaName) : base(connectionStringSource, schemaName)
        {
            _ConnectionEstablisher = new SqlConnectionEstablisher(connectionStringSource[schemaName]);
        }
    }
}
