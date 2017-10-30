using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public abstract class PayrollModelBase<T> : ModelBase<T>
        where T : IPayroll
    {
        public PayrollModelBase(T source) : base(source)
        {
            Id = source.Id;
            Type = PayrollTypeModel.TryCreate(source.Type);
            CutOff = PayrollCutOffModel.TryCreate(source.CutOff);
            RangeDate = new ValueRangeModel<DateTime>(source.RangeDate);
            RunDate = source.RunDate;
            HumanResourceHead = EmployeeModel.TryCreate(source.HumanResourceHead);
            Mayor = EmployeeModel.TryCreate(source.Mayor);
            Treasurer = EmployeeModel.TryCreate(source.Treasurer);
            CityAccountant = EmployeeModel.TryCreate(source.CityAccountant);
            CityBudgetOfficer = EmployeeModel.TryCreate(source.CityBudgetOfficer);
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private PayrollTypeModel _Type;
        public PayrollTypeModel Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private PayrollCutOffModel _CutOff;
        public PayrollCutOffModel CutOff
        {
            get { return _CutOff; }
            set { SetProperty(ref _CutOff, value); }
        }

        private ValueRangeModel<DateTime> _RangeDate;
        public ValueRangeModel<DateTime> RangeDate
        {
            get { return _RangeDate; }
            set { SetProperty(ref _RangeDate, value); }
        }

        private DateTime _RunDate;
        public DateTime RunDate
        {
            get { return _RunDate; }
            set { SetProperty(ref _RunDate, value); }
        }

        private EmployeeModel _HumanResourceHead;
        public EmployeeModel HumanResourceHead
        {
            get { return _HumanResourceHead; }
            set { SetProperty(ref _HumanResourceHead, value); }
        }

        private EmployeeModel _Mayor;
        public EmployeeModel Mayor
        {
            get { return _Mayor; }
            set { SetProperty(ref _Mayor, value); }
        }

        private EmployeeModel _Treasurer;
        public EmployeeModel Treasurer
        {
            get { return _Treasurer; }
            set { SetProperty(ref _Treasurer, value); }
        }

        private EmployeeModel _CityAccountant;
        public EmployeeModel CityAccountant
        {
            get { return _CityAccountant; }
            set { SetProperty(ref _CityAccountant, value); }
        }

        private EmployeeModel _CityBudgetOfficer;
        public EmployeeModel CityBudgetOfficer
        {
            get { return _CityBudgetOfficer; }
            set { SetProperty(ref _CityBudgetOfficer, value); }
        }

        public override T GetSource()
        {
            Source.Id = Id;
            Source.CutOff = CutOff.GetSource();
            Source.RangeDate = RangeDate.GetSource();
            Source.RunDate = RunDate;
            Source.HumanResourceHead = HumanResourceHead.GetSource();
            Source.Mayor = Mayor.GetSource();
            Source.Treasurer = Treasurer.GetSource();
            Source.CityAccountant = CityAccountant.GetSource();
            Source.CityBudgetOfficer = CityBudgetOfficer.GetSource();

            return Source;
        }

        public static bool operator ==(PayrollModelBase<T> left, PayrollModelBase<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PayrollModelBase<T> left, PayrollModelBase<T> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is PayrollModelBase<T> value)
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
