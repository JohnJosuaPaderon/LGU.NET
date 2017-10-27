using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollContractualModel : ModelBase<IPayrollContractual>
    {
        public PayrollContractualModel(IPayrollContractual source) : base(source ?? new PayrollContractual())
        {
            Id = source?.Id ?? default(long);
            Type = new PayrollTypeModel(source?.Type);
            CutOff = new PayrollCutOffModel(source?.CutOff);
            RangeDate = new ValueRangeModel<DateTime>(source?.RangeDate ?? new ValueRange<DateTime>());
            RunDate = source?.RunDate ?? default(DateTime);
            HumanResourceHead = new EmployeeModel(source?.HumanResourceHead);
            Mayor = new EmployeeModel(source?.Mayor);
            Treasurer = new EmployeeModel(source?.Treasurer);
            CityAccountant = new EmployeeModel(source?.CityAccountant);
            CityBudgetOfficer = new EmployeeModel(source?.CityBudgetOfficer);
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

        public override IPayrollContractual GetSource()
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
    }
}
