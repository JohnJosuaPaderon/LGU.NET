using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class TimeLogModel : ModelBase<ITimeLog>
    {
        public TimeLogModel(ITimeLog source) : base(source)
        {
            Id = source?.Id ?? default(long);
            Employee = source?.Employee;
            LoginDate = source?.LoginDate;
            LogoutDate = source?.LogoutDate;
            Type = source?.Type;
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private IEmployee _Employee;
        public IEmployee Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }

        private DateTime? _LoginDate;
        public DateTime? LoginDate
        {
            get { return _LoginDate; }
            set { SetProperty(ref _LoginDate, value); }
        }

        private DateTime? _LogoutDate;
        public DateTime? LogoutDate
        {
            get { return _LogoutDate; }
            set { SetProperty(ref _LogoutDate, value); }
        }

        private ITimeLogType _Type;
        public ITimeLogType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        public override ITimeLog GetSource()
        {
            if (Source != null)
            {
                Source.Id = Id;
                Source.LoginDate = LoginDate;
                Source.LogoutDate = LogoutDate;
                Source.Type = Type;

                return Source;
            }
            else
            {
                return null;
            }
        }
    }
}
