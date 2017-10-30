using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class DepartmentModel : ModelBase<IDepartment>
    {
        public static DepartmentModel TryCreate(IDepartment department)
        {
            return department != null ? new DepartmentModel(department) : null;
        }

        public DepartmentModel(IDepartment source) : base(source)
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

        public override IDepartment GetSource()
        {
            Source.Id = Id;
            Source.Abbreviation = Abbreviation;
            Source.Description = Description;

            return Source;
        }

        public static bool operator ==(DepartmentModel left, DepartmentModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DepartmentModel left, DepartmentModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is DepartmentModel value)
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
