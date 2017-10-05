using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class DepartmentModel : ModelBase<IDepartment>
    {
        public DepartmentModel(IDepartment source) : base(source ?? new Department())
        {
            Id = source?.Id ?? default(int);
            Description = source?.Description;
            Abbreviation = source?.Abbreviation;
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

        public override IDepartment GetSource()
        {
            Source.Id = Id;
            Source.Abbreviation = Abbreviation;
            Source.Description = Description;

            return Source;
        }
    }
}
