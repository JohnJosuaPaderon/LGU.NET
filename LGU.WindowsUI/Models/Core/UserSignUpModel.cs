using LGU.Entities.Core;
using LGU.Utilities;

namespace LGU.Models.Core
{
    public class UserSignUpModel : ModelBase<IUser>
    {
        public UserSignUpModel(IUser source) : base(source)
        {
            Id = source.Id;
            DisplayName = source.DisplayName;
            Username = null;
            Password = null;
            ConfirmPassword = null;
            Type = source.Type;
            Status = source.Status;
            Owner = source.Owner;
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { SetProperty(ref _DisplayName, value); }
        }

        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { SetProperty(ref _Username, value); }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { SetProperty(ref _ConfirmPassword, value); }
        }

        private IUserType _Type;
        public IUserType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private IUserStatus _Status;
        public IUserStatus Status
        {
            get { return _Status; }
            set { SetProperty(ref _Status, value); }
        }

        private IPerson _Owner;
        public IPerson Owner
        {
            get { return _Owner; }
            set { SetProperty(ref _Owner, value); }
        }

        public override IUser GetSource()
        {
            if (Owner != null)
            {
                return new User(Owner)
                {
                    Id = Id,
                    DisplayName = DisplayName,
                    SecureUsername = SecureStringConverter.Convert(Username),
                    SecurePassword = Password == ConfirmPassword ? SecureStringConverter.Convert(Password) : null,
                    Status = Status,
                    Type = Type
                };
            }
            else
            {
                return new User()
                {
                    Id = Id,
                    DisplayName = DisplayName,
                    SecureUsername = SecureStringConverter.Convert(Username),
                    SecurePassword = Password == ConfirmPassword ? SecureStringConverter.Convert(Password) : null,
                    Status = Status,
                    Type = Type
                };
            }
        }

        public static bool operator ==(UserSignUpModel left, UserSignUpModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserSignUpModel left, UserSignUpModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is UserSignUpModel value)
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
