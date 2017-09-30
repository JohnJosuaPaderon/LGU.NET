using LGU.Data.Rdbms;

namespace LGU.EntityManagers
{
    public abstract class SqlManagerBase
    {
        public SqlManagerBase(IConnectionStringSource connectionStringSource, string connectionStringKey)
        {
            _ConnectionEstablisher = new SqlConnectionEstablisher(connectionStringSource[string.IsNullOrWhiteSpace(connectionStringKey) ? "Core" : connectionStringKey]);
        }

        protected readonly SqlConnectionEstablisher _ConnectionEstablisher;
    }
}
