namespace LGU.Entities.HumanResource
{
    public interface ISalaryGradeStep : IEntity<long>
    {
        ISalaryGrade SalaryGrade { get; }
        int Step { get; }
        decimal Amount { get; set; }
    }
}
