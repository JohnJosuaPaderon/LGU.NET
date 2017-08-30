using System;

namespace LGU.Entities.HumanResource
{
    public class SalaryGradeBatch : Entity<int>, ISalaryGradeBatch
    {
        public DateTime EffectivityDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
