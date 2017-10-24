using LGU.Entities.Core;
using LGU.Utilities;

namespace LGU.Models.Core
{
    public abstract class PersonModelBase<T> : ModelBase<T>
        where T : IPerson
    {
        public PersonModelBase(T source) : base(source)
        {
            Id = source?.Id ?? default(long);
            FirstName = source?.FirstName;
            MiddleName = source?.MiddleName;
            LastName = source?.LastName;
            NameExtension = source?.NameExtension;
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { SetProperty(ref _FirstName, value, RaiseFullName); }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                SetProperty(ref _MiddleName, value, () =>
                {
                    RaiseFullName();
                    RaiseMiddleInitials();
                });
            }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { SetProperty(ref _LastName, value, RaiseFullName); }
        }

        private string _NameExtension;
        public string NameExtension
        {
            get { return _NameExtension; }
            set { SetProperty(ref _NameExtension, value, RaiseFullName); }
        }

        public string MiddleInitials { get; private set; }
        public string FullName { get; private set; }
        public string InformalFullName { get; private set; }

        private void RaiseMiddleInitials()
        {
            MiddleInitials = MiddleInitialConstructor.Construct(MiddleName);
        }

        private void RaiseFullName()
        {
            FullName = FullNameConstructor.Construct(FirstName, MiddleName, LastName, NameExtension);
            InformalFullName = InformalFullNameConstructor.Construct(FirstName, MiddleInitials, LastName, NameExtension);
            RaisePropertyChanged(nameof(FullName));
            RaisePropertyChanged(nameof(InformalFullName));
        }

        public override T GetSource()
        {
            if (Source != null)
            {
                Source.Id = Id;
                Source.FirstName = FirstName;
                Source.MiddleName = MiddleName;
                Source.LastName = LastName;
                Source.NameExtension = NameExtension;
            }

            return Source;
        }

        public static bool operator ==(PersonModelBase<T> left, PersonModelBase<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PersonModelBase<T> left, PersonModelBase<T> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is PersonModelBase<T> value)
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

        public override string ToString()
        {
            return FullName;
        }
    }
}
