using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class PayrollContractualConverter : PayrollConverterBase<IPayrollContractual>
    {
        public PayrollContractualConverter(IDbDataReaderToProcessResultConverter toProcessResultConverter, IDbDataReaderToEnumerableProcessResultConverter toEnumerableProcessResultConverter, IPayrollFields payrollFields) : base(toProcessResultConverter, toEnumerableProcessResultConverter, payrollFields)
        {
        }

        protected override IPayrollContractual Get(IPayrollType type, IPayrollCutOff cutOff, IEmployee mayor, IEmployee humanResourceHead, IEmployee treasurer, IEmployee cityAccountant, IEmployee cityBudgetOfficer, DbDataReader reader)
        {
            return new PayrollContractual()
            {
                Id = PId.TryGetValue(reader.GetInt64, _PayrollFields.Id),
                Mayor = mayor,
                HumanResourceHead = humanResourceHead,
                Treasurer = treasurer,
                CityAccountant = cityAccountant,
                CityBudgetOfficer = cityBudgetOfficer
            };
        }
    }
}
