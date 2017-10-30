using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class SalaryGradeBatchModel : ModelBase<ISalaryGradeBatch>
    {
        public SalaryGradeBatchModel(ISalaryGradeBatch source) : base(source)
        {
            Id = source.Id;
            EffectivityDate = source.EffectivityDate;
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
            Source.Id = Id;
            Source.EffectivityDate = EffectivityDate ?? DateTime.Now;
            Source.ExpiryDate = ExpiryDate;
            Source.Description = Description;

            return Source;
        }


        public static bool operator ==(SalaryGradeBatchModel left, SalaryGradeBatchModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SalaryGradeBatchModel left, SalaryGradeBatchModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is SalaryGradeBatchModel value)
            {
                return (Id == 0 || value.Id == 0) ? false : Id == value.Id;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
