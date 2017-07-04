using LGU.Data.RDBMS;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class ProcessBase
    {
        protected readonly SqlHelper SqlHelper;

        public ProcessBase(IConnectionStringSource connectionStringSource)
        {
            SqlHelper = new SqlHelper(new SqlConnectionEstablisher(connectionStringSource.HumanResource));
        }
    }
}
