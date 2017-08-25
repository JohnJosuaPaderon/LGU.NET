using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class LocatorModel : ModelBase<Locator>
    {
        public LocatorModel(Locator source) : base(source)
        {
            Id = source.Id;
            Requestor = source.Requestor;
            Date = source.Date;
            OfficeOutTime = source.OfficeOutTime;
            ExpectedReturnTime = source.ExpectedReturnTime;
            LeaveType = source.LeaveType;
            Purpose = source.Purpose;
            DepartmentHead = source.DepartmentHead;
        }

        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private Employee _Requestor;
        public Employee Requestor
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

        private LocatorLeaveType _LeaveType;
        public LocatorLeaveType LeaveType
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

        public override Locator GetSource()
        {
            if (Requestor != null)
            {
                return new Locator(Requestor)
                {
                     Id = Id,
                     Date = Date,
                     OfficeOutTime = OfficeOutTime,
                     ExpectedReturnTime = ExpectedReturnTime,
                     LeaveType = LeaveType,
                     Purpose = Purpose,
                     DepartmentHead = DepartmentHead
                };
            }
            else
            {
                return null;
            }
        }
    }
}
