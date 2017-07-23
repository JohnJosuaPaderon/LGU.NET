using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class ModuleProcess : CoreProcessBase
    {
        protected readonly IModuleConverter<SqlDataReader> r_Converter;

        public ModuleProcess(IConnectionStringSource connectionStringSource, IModuleConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            r_Converter = converter;
        }
    }
}
