using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class TimeLogModel : ModelBase<ITimeLog>
    {
        public static TimeLogModel TryCreate(ITimeLog timeLog)
        {
            return timeLog != null ? new TimeLogModel(timeLog) : null;
        }

        public TimeLogModel(ITimeLog source) : base(source)
        {
            Id = source.Id;
            Employee = EmployeeModel.TryCreate(source.Employee);
            LoginDate = source.LoginDate;
            LogoutDate = source.LogoutDate;
            Type = TimeLogTypeModel.TryCreate(source.Type);
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private EmployeeModel _Employee;
        public EmployeeModel Employee
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

        private TimeLogTypeModel _Type;
        public TimeLogTypeModel Type
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
                Source.Type = Type.GetSource();

                return Source;
            }
            else
            {
                return null;
            }
        }

        public static bool operator ==(TimeLogModel left, TimeLogModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TimeLogModel left, TimeLogModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is TimeLogModel value)
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
