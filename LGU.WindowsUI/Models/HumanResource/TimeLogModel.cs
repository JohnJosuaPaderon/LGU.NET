using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class TimeLogModel : ModelBase<TimeLog>
    {
        public TimeLogModel(TimeLog source) : base(source)
        {
            if (source != null)
            {
                Id = source.Id;
                Employee = source.Employee;
                LoginDate = source.LoginDate;
                LogoutDate = source.LogoutDate;
                Type = source.Type;
            }
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private Employee _Employee;
        public Employee Employee
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

        private TimeLogType _Type;
        public TimeLogType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        public override TimeLog GetSource()
        {
            if (Employee != null)
            {
                return new TimeLog(Employee)
                {
                    Id = Id,
                    LoginDate = LoginDate,
                    LogoutDate = LogoutDate,
                    Type = Type
                };
            }
            else
            {
                return null;
            }
        }
    }
}
