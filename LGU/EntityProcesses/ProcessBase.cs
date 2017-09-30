using LGU.Data.Rdbms;

namespace LGU.EntityProcesses
{
    public abstract class ProcessBase
    {
        protected readonly SqlHelper _SqlHelper;
        protected readonly string r_SchemaName;

        public ProcessBase(IConnectionStringSource connectionStringSource, string schemaName)
        {
            _SqlHelper = new SqlHelper(new SqlConnectionEstablisher(connectionStringSource[schemaName]));
            r_SchemaName = string.IsNullOrWhiteSpace(schemaName) ? "Core" : schemaName;
        }

        protected string GetQualifiedDbObjectName(string dbObjectName)
        {
            return $"{r_SchemaName}.{dbObjectName}";
        }

        protected string GetQualifiedDbObjectName()
        {
            return GetQualifiedDbObjectName(GetType().Name);
        }
    }

    public abstract class ProcessBaseV2
    {
        protected readonly SqlConnectionEstablisher _ConnectionEstablisher;
        protected readonly string _SchemaName;

        public ProcessBaseV2(IConnectionStringSource connectionStringSource, string schemaName)
        {
            _ConnectionEstablisher = new SqlConnectionEstablisher(connectionStringSource[schemaName]);
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
}
