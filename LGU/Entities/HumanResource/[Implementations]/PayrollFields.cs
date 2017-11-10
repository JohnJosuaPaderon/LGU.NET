namespace LGU.Entities.HumanResource
{
    public class PayrollFields : IPayrollFields
    {
        public PayrollFields()
        {
            Id = "Id";
            TypeId = "TypeId";
            CutOffId = "CutOffId";
            RangeDateBegin = "RangeDateBegin";
            RangeDateEnd = "RangeDateEnd";
            RunDate = "RunDate";
            HumanResourceHeadId = "HumanResourceHeadId";
            MayorId = "MayorId";
            TreasurerId = "TreasurerId";
            CityAccountantId = "CityAccountantId";
            CityBudgetOfficerId = "CityBudgetOfficerId";
        }

        public string Id { get; }
        public string TypeId { get; }
        public string CutOffId { get; }
        public string RangeDateBegin { get; }
        public string RangeDateEnd { get; }
        public string RunDate { get; }
        public string HumanResourceHeadId { get; }
        public string MayorId { get; }
        public string TreasurerId { get; }
        public string CityAccountantId { get; }
        public string CityBudgetOfficerId { get; }
    }
}
