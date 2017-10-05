using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PayrollTypeModel : ModelBase<IPayrollType>
    {
        public PayrollTypeModel(IPayrollType source) : base(source ?? new PayrollType())
        {
            Id = source?.Id ?? default(short);
            Description = source?.Description;
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
    }
}
