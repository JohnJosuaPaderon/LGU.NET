using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class PositionModel : ModelBase<IPosition>
    {
        public PositionModel(IPosition source) : base(source ?? new Position())
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
            Source.Id = Id;
            Source.Abbreviation = Abbreviation;
            Source.Description = Description;

            return Source;
        }
    }
}
