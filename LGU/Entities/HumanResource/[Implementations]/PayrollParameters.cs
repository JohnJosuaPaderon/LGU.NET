namespace LGU.Entities.HumanResource
{
    public sealed class PayrollParameters : IPayrollParameters
    {
        public PayrollParameters()
        {
            Id = "@_Id";
            TypeId = "@_TypeId";
            CutOffId = "@_CutOffId";
            RangeDateBegin = "@_RangeDateBegin";
            RangeDateEnd = "@_RangeDateEnd";
            RunDate = "@_RunDate";
            HumanResourceHeadId = "@_HumanResourceHeadId";
            MayorId = "@_MayorId";
            TreasurerId = "@_TreasurerId";
            CityAccountantId = "@_CityAccountantId";
            CityBudgetOfficerId = "@_CityBudgetOfficerId";
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
