using System;

namespace LGU.Entities.HumanResource
{
    public interface ISalaryGradeBatch : IEntity<int>
    {
        DateTime EffectivityDate { get; set; }
        DateTime? ExpiryDate { get; set; }
        string Description { get; set; }
    }
}
