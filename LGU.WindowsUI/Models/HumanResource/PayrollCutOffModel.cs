using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollCutOffModel : ModelBase<IPayrollCutOff>
    {
        public PayrollCutOffModel(IPayrollCutOff source) : base(source ?? new PayrollCutOff())
        {
            Id = source?.Id ?? default(short);
            Count = source?.Count ?? default(int);
            Description = source?.Description;
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
    }
}
