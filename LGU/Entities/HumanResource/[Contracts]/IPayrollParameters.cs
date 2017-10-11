namespace LGU.Entities.HumanResource
{
    public interface IPayrollParameters
    {
        string Id { get; }
        string TypeId { get; }
        string CutOffId { get; }
        string RangeDateBegin { get; }
        string RangeDateEnd { get; }
        string RunDate { get; }
        string HumanResourceHeadId { get; }
        string MayorId { get; }
        string TreasurerId { get; }
        string CityAccountantId { get; }
        string CityBudgetOfficerId { get; }
    }
}
