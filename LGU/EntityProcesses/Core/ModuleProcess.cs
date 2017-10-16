using LGU.EntityConverters.Core;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.Core
{
    public abstract class ModuleProcess : CoreProcessBase
    {
        protected readonly IModuleConverter _Converter;

        public ModuleProcess(IConnectionStringSource connectionStringSource, IModuleConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
