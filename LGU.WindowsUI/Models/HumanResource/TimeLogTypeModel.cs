using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class TimeLogTypeModel : ModelBase<ITimeLogType>
    {
        public static TimeLogTypeModel TryCreate(ITimeLogType timeLogType)
        {
            return timeLogType != null ? new TimeLogTypeModel(timeLogType) : null;
        }

        public TimeLogTypeModel(ITimeLogType source) : base(source)
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

        public override ITimeLogType GetSource()
        {
            Source.Id = Id;
            Source.Description = Description;

            return Source;
        }

        public static bool operator ==(TimeLogTypeModel left, TimeLogTypeModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TimeLogTypeModel left, TimeLogTypeModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is TimeLogTypeModel value)
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
