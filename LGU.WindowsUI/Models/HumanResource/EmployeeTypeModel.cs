using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class EmployeeTypeModel : ModelBase<IEmployeeType>
    {
        public EmployeeTypeModel(IEmployeeType source) : base(source ?? new EmployeeType())
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

        public override IEmployeeType GetSource()
        {
            Source.Id = Id;
            Source.Description = Description;

            return Source;
        }
    }
}
