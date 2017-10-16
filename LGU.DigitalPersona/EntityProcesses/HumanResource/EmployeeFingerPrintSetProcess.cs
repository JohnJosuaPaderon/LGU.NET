using LGU.EntityConverters.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public abstract class EmployeeFingerPrintSetProcess : HumanResourceProcessBase
    {
        protected readonly IEmployeeFingerPrintSetConverter _Converter;

        public EmployeeFingerPrintSetProcess(IConnectionStringSource connectionStringSource, IEmployeeFingerPrintSetConverter converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }
    }
}
