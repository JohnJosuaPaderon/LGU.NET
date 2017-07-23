using LGU.Data.Rdbms;

namespace LGU.EntityProcesses
{
    public abstract class ProcessBase
    {
        protected readonly SqlHelper r_SqlHelper;
        protected readonly string r_SchemaName;

        public ProcessBase(IConnectionStringSource connectionStringSource, string schemaName)
        {
            r_SqlHelper = new SqlHelper(new SqlConnectionEstablisher(connectionStringSource[schemaName]));
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
}
