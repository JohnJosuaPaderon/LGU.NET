using LGU.Entities.HumanResource;
using LGU.Utilities;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class WorkTimeScheduleModel : ModelBase<IWorkTimeSchedule>
    {
        public static WorkTimeScheduleModel TryCreate(IWorkTimeSchedule workTimeSchedule)
        {
            return workTimeSchedule != null ? new WorkTimeScheduleModel(workTimeSchedule) : null;
        }

        public WorkTimeScheduleModel(IWorkTimeSchedule source) : base(source)
        {
            Id = source.Id;
            Description = source.Description;
            WorkTimeStart = source.WorkTimeStart;
            WorkTimeEnd = source.WorkTimeEnd;
            BreakTime = source.BreakTime;
            WorkingMonthDays = source.WorkingMonthDays;
        }

        private int _Id;
        public int Id
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

        private DateTime _WorkTimeStart;
        public DateTime WorkTimeStart
        {
            get { return _WorkTimeStart; }
            set { SetProperty(ref _WorkTimeStart, value, () => RaisePropertyChanged(nameof(WorkingMinutes))); }
        }

        private DateTime _WorkTimeEnd;
        public DateTime WorkTimeEnd
        {
            get { return _WorkTimeEnd; }
            set { SetProperty(ref _WorkTimeEnd, value, () => RaisePropertyChanged(nameof(WorkingMinutes))); }
        }

        private TimeSpan? _BreakTime;
        public TimeSpan? BreakTime
        {
            get { return _BreakTime; }
            set { SetProperty(ref _BreakTime, value); }
        }

        private int _WorkingMonthDays;
        public int WorkingMonthDays
        {
            get { return _WorkingMonthDays; }
            set { SetProperty(ref _WorkingMonthDays, value); }
        }

        public int WorkingMinutes
        {
            get
            {
                return (int)DateTimeUtilities.GetTotalDayMinuteDiff(WorkTimeEnd, WorkTimeStart);
            }
        }

        public override IWorkTimeSchedule GetSource()
        {
            Source.Id = Id;
            Source.Description = Description;
            Source.WorkTimeStart = WorkTimeStart;
            Source.WorkTimeEnd = WorkTimeEnd;
            Source.BreakTime = BreakTime;
            Source.WorkingMonthDays = WorkingMonthDays;

            return Source;
        }

        public static bool operator ==(WorkTimeScheduleModel left, WorkTimeScheduleModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WorkTimeScheduleModel left, WorkTimeScheduleModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is WorkTimeScheduleModel value)
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
