using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class SalaryGradeBatchModel : ModelBase<ISalaryGradeBatch>
    {
        public SalaryGradeBatchModel(ISalaryGradeBatch source) : base(source)
        {
            Id = source.Id;
            EffectivityDate = source.EffectivityDate == default(DateTime) ? null : new DateTime?(source.EffectivityDate);
            ExpiryDate = source.ExpiryDate;
            Description = source.Description;
        }

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private DateTime? _EffectivityDate;
        public DateTime? EffectivityDate
        {
            get { return _EffectivityDate; }
            set { SetProperty(ref _EffectivityDate, value); }
        }

        private DateTime? _ExpiryDate;
        public DateTime? ExpiryDate
        {
            get { return _ExpiryDate; }
            set { SetProperty(ref _ExpiryDate, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        public override ISalaryGradeBatch GetSource()
        {
            return new SalaryGradeBatch()
            {
               Id = Id,
               EffectivityDate = EffectivityDate ?? DateTime.Now,
               ExpiryDate = ExpiryDate,
               Description = Description
            };
        }
    }
}
