using LGU.Models.HumanResource;
using Prism.Mvvm;
using System;

namespace LGU.ViewModels.HumanResource
{
    public class TimeKeepingResult : BindableBase
    {
        private string _Key;
        public string Key
        {
            get { return _Key; }
            set { SetProperty(ref _Key, value); }
        }

        private EmployeeModel _Employee;
        public EmployeeModel Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }

        private TimeKeepingResultType _Type;
        public TimeKeepingResultType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value); }
        }

        private LogType _LogType;
        public LogType LogType
        {
            get { return _LogType; }
            set { SetProperty(ref _LogType, value); }
        }

        private DateTime _LogDate;
        public DateTime LogDate
        {
            get { return _LogDate; }
            set { SetProperty(ref _LogDate, value); }
        }

        public static bool operator ==(TimeKeepingResult left, TimeKeepingResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TimeKeepingResult left, TimeKeepingResult right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as TimeKeepingResult;
            return Key.Equals(value.Key);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
