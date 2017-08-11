using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class LocatorLeaveTypeModel : ModelBase<LocatorLeaveType>
    {
        public LocatorLeaveTypeModel(LocatorLeaveType source) : base(source)
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

        public override LocatorLeaveType GetSource()
        {
            return new LocatorLeaveType()
            {
                Id = Id,
                Description = Description
            };
        }
    }
}
