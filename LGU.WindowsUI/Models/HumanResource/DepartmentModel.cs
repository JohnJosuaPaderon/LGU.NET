using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class DepartmentModel : ModelBase<Department>
    {
        public DepartmentModel(Department source) : base(source)
        {
            Id = source.Id;
            Description = source.Description;
            Abbreviation = source.Abbreviation;
        }

        private int _Id;
        public int Id
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

        private string _Abbreviation;
        public string Abbreviation
        {
            get { return _Abbreviation; }
            set { SetProperty(ref _Abbreviation, value); }
        }

        public override Department GetSource()
        {
            return new Department()
            {
                Id = Id,
                Description = Description,
                Abbreviation = Abbreviation
            };
        }
    }
}
