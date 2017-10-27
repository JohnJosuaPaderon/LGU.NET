using LGU.Configurations;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class PayrollConfigurationProvider : IPayrollConfigurationProvider
    {
        private const string KEY_HEADER = "LGU.HumanResource.Payroll";
        private const string KEY_MAYOR_ID = "Mayor.Id";
        private const string KEY_HUMAN_RESOURCE_HEAD_ID = "HumanResourceHead.Id";
        private const string KEY_TREASURER_ID = "Treasurer.Id";
        private const string KEY_CITY_ACCOUNTANT_ID = "CityAccountant.Id";
        private const string KEY_CITY_BUDGET_OFFICER_ID = "CityBudgetOfficer.Id";

        public PayrollConfigurationProvider()
        {
            MayorId = KEY_MAYOR_ID;
            HumanResourceHeadId = KEY_HUMAN_RESOURCE_HEAD_ID;
            TreasurerId = KEY_TREASURER_ID;
            CityAccountantId = KEY_CITY_ACCOUNTANT_ID;
            CityBudgetOfficerId = KEY_CITY_BUDGET_OFFICER_ID;

            Header = new JConfigurationHeader(KEY_HEADER);
        }

        public IJConfigurationHeader Header { get; } 
        public string MayorId { get; }
        public string HumanResourceHeadId { get; }
        public string TreasurerId { get; }
        public string CityAccountantId { get; }
        public string CityBudgetOfficerId { get; }
    }
}
