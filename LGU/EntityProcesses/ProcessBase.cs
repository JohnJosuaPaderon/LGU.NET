using LGU.Data.Rdbms;

namespace LGU.EntityProcesses
{
    public abstract class ProcessBase
    {
        protected readonly SqlHelper SqlHelper;
        protected readonly string SchemaName;

        public ProcessBase(IConnectionStringSource connectionStringSource, string schemaName)
        {
            SqlHelper = new SqlHelper(new SqlConnectionEstablisher(connectionStringSource[schemaName]));
            SchemaName = string.IsNullOrWhiteSpace(schemaName) ? "Core" : schemaName;
        }

        protected string GetQualifiedDbObjectName(string dbObjectName)
        {
            return $"{SchemaName}.{dbObjectName}";
        }

        protected string GetQualifiedDbObjectName()
        {
            return GetQualifiedDbObjectName(GetType().Name);
        }
    }
}
