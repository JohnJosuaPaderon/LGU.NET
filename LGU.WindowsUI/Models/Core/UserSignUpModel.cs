﻿using LGU.Entities.Core;
using LGU.Utilities;

namespace LGU.Models.Core
{
    public class UserSignUpModel : ModelBase<User>
    {
        public UserSignUpModel(User source) : base(source)
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

        private UserType _Type;
        public UserType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private UserStatus _Status;
        public UserStatus Status
        {
            get { return _Status; }
            set { SetProperty(ref _Status, value); }
        }

        private Person _Owner;
        public Person Owner
        {
            get { return _Owner; }
            set { SetProperty(ref _Owner, value); }
        }

        public override User GetSource()
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
    }
}