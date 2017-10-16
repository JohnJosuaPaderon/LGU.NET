using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PositionModel : ModelBase<IPosition>
    {
        public PositionModel(IPosition source) : base(source)
        {
            Id = source?.Id ?? default(int);
            Abbreviation = source?.Abbreviation;
            Description = source?.Description;
        }

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private string _Abbreviation;
        public string Abbreviation
        {
            get { return _Abbreviation; }
            set { SetProperty(ref _Abbreviation, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        public override IPosition GetSource()
        {
            if (Source != null)
            {
                Source.Id = Id;
                Source.Abbreviation = Abbreviation;
                Source.Description = Description;
            }

            return Source;
        }

        public static bool operator ==(PositionModel left, PositionModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PositionModel left, PositionModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is PositionModel value)
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
