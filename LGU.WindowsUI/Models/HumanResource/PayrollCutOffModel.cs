using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollCutOffModel : ModelBase<IPayrollCutOff>
    {
        public static PayrollCutOffModel TryCreate(IPayrollCutOff payrollCutOff)
        {
            return payrollCutOff != null ? new PayrollCutOffModel(payrollCutOff) : null;
        }

        public PayrollCutOffModel(IPayrollCutOff source) : base(source)
        {
            Id = source.Id;
            Count = source.Count;
            Description = source.Description;
        }

        private short _Id;
        public short Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private int _Count;
        public int Count
        {
            get { return _Count; }
            set { SetProperty(ref _Count, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        public override IPayrollCutOff GetSource()
        {
            Source.Id = Id;
            Source.Count = Count;
            Source.Description = Description;

            return Source;
        }

        public static bool operator ==(PayrollCutOffModel left, PayrollCutOffModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PayrollCutOffModel left, PayrollCutOffModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is PayrollCutOffModel value)
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
