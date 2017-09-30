using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollModel : ModelBase<IPayroll>
    {
        public PayrollModel(IPayroll source) : base(source)
        {
            if (source != null)
            {
                Id = source.Id;
                Type = source.Type;
                CutOff = source.CutOff;
                RangeDate = new ValueRangeModel<DateTime>(source.RangeDate);
                RunDate = source.RunDate;
                HumanResourceHead = source.HumanResourceHead;
                Mayor = source.Mayor;
                Treasurer = source.Treasurer;
                CityAccountant = source.CityAccountant;
                CityBudgetOfficer = source.CityBudgetOfficer;
            }
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private IPayrollType _Type;
        public IPayrollType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private IPayrollCutOff _CutOff;
        public IPayrollCutOff CutOff
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

        private IEmployee _HumanResourceHead;
        public IEmployee HumanResourceHead
        {
            get { return _HumanResourceHead; }
            set { SetProperty(ref _HumanResourceHead, value); }
        }

        private IEmployee _Mayor;
        public IEmployee Mayor
        {
            get { return _Mayor; }
            set { SetProperty(ref _Mayor, value); }
        }

        private IEmployee _Treasurer;
        public IEmployee Treasurer
        {
            get { return _Treasurer; }
            set { SetProperty(ref _Treasurer, value); }
        }

        private IEmployee _CityAccountant;
        public IEmployee CityAccountant
        {
            get { return _CityAccountant; }
            set { SetProperty(ref _CityAccountant, value); }
        }

        private IEmployee _CityBudgetOfficer;
        public IEmployee CityBudgetOfficer
        {
            get { return _CityBudgetOfficer; }
            set { SetProperty(ref _CityBudgetOfficer, value); }
        }

        public override IPayroll GetSource()
        {
            return new Payroll()
            {
                Id = Id,
                Type = Type,
                RangeDate = RangeDate.GetSource(),
                CityAccountant = CityAccountant,
                CityBudgetOfficer = CityBudgetOfficer,
                CutOff = CutOff,
                HumanResourceHead = HumanResourceHead,
                Mayor = Mayor,
                RunDate = RunDate,
                Treasurer = Treasurer
            };
        }
    }
}
