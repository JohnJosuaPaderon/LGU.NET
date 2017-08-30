namespace LGU.Entities.HumanResource
{
    public interface ISalaryGrade : IEntity<long>
    {
        int Number { get; }
        ISalaryGradeBatch Batch { get; }
    }
}
