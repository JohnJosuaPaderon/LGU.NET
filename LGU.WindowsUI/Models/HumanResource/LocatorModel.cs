using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class LocatorModel : ModelBase<ILocator>
    {
        public static LocatorModel TryCreate(ILocator locator)
        {
            return locator != null ? new LocatorModel(locator) : null;
        }

        public LocatorModel(ILocator source) : base(source)
        {
            Id = source.Id;
            Requestor = EmployeeModel.TryCreate(source.Requestor);
            Date = source.Date;
            OfficeOutTime = source.OfficeOutTime;
            ExpectedReturnTime = source.ExpectedReturnTime;
            LeaveType = LocatorLeaveTypeModel.TryCreate(source.LeaveType);
            Purpose = source.Purpose;
            DepartmentHead = source.DepartmentHead;
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private EmployeeModel _Requestor;
        public EmployeeModel Requestor
        {
            get { return _Requestor; }
            set { SetProperty(ref _Requestor, value); }
        }

        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { SetProperty(ref _Date, value); }
        }

        private DateTime _OfficeOutTime;
        public DateTime OfficeOutTime
        {
            get { return _OfficeOutTime; }
            set { SetProperty(ref _OfficeOutTime, value); }
        }

        private DateTime? _ExpectedReturnTime;
        public DateTime? ExpectedReturnTime
        {
            get { return _ExpectedReturnTime; }
            set { SetProperty(ref _ExpectedReturnTime, value); }
        }

        private LocatorLeaveTypeModel _LeaveType;
        public LocatorLeaveTypeModel LeaveType
        {
            get { return _LeaveType; }
            set { SetProperty(ref _LeaveType, value); }
        }

        private string _Purpose;
        public string Purpose
        {
            get { return _Purpose; }
            set { SetProperty(ref _Purpose, value); }
        }

        private string _DepartmentHead;
        public string DepartmentHead
        {
            get { return _DepartmentHead; }
            set { SetProperty(ref _DepartmentHead, value); }
        }

        public override ILocator GetSource()
        {
            Source.Id = Id;
            Source.Date = Date;
            Source.OfficeOutTime = OfficeOutTime;
            Source.ExpectedReturnTime = ExpectedReturnTime;
            Source.LeaveType = LeaveType.GetSource();
            Source.Purpose = Purpose;
            Source.DepartmentHead = DepartmentHead;

            return Source;
        }

        public static bool operator ==(LocatorModel left, LocatorModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LocatorModel left, LocatorModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is LocatorModel value)
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
