﻿using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollTypeModel : ModelBase<IPayrollType>
    {
        public static PayrollTypeModel TryCreate(IPayrollType payrollType)
        {
            return payrollType != null ? new PayrollTypeModel(payrollType) : null;
        }

        public PayrollTypeModel(IPayrollType source) : base(source)
        {
            Id = source.Id;
            Description = source.Description;
        }

        private short _Id;
        public short Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        public override IPayrollType GetSource()
        {
            Source.Id = Id;
            Source.Description = Description;

            return Source;
        }

        public static bool operator ==(PayrollTypeModel left, PayrollTypeModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PayrollTypeModel left, PayrollTypeModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is PayrollTypeModel value)
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
