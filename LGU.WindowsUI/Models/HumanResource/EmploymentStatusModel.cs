using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class EmploymentStatusModel : ModelBase<IEmploymentStatus>
    {
        public EmploymentStatusModel(IEmploymentStatus source) : base(source ?? new EmploymentStatus())
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

        public override IEmploymentStatus GetSource()
        {
            Source.Id = Id;
            Source.Description = Description;

            return Source;
        }
    }
}
