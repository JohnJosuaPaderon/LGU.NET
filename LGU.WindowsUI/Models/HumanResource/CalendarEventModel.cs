using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class CalendarEventModel : ModelBase<ICalendarEvent>
    {
        public CalendarEventModel(ICalendarEvent source) : base(source)
        {
        }

        private long _Id;
        public long Id
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

        private DateTime _DateOccur;
        public DateTime DateOccur
        {
            get { return _DateOccur; }
            set { SetProperty(ref _DateOccur, value); }
        }

        private DateTime? _DateOccurEnd;
        public DateTime? DateOccurEnd
        {
            get { return _DateOccurEnd; }
            set { SetProperty(ref _DateOccurEnd, value); }
        }

        private bool _IsHoliday;
        public bool IsHoliday
        {
            get { return _IsHoliday; }
            set { SetProperty(ref _IsHoliday, value); }
        }

        private bool _IsNonWorking;
        public bool IsNonWorking
        {
            get { return _IsNonWorking; }
            set { SetProperty(ref _IsNonWorking, value); }
        }

        private bool _IsAnnual;
        public bool IsAnnual
        {
            get { return _IsAnnual; }
            set { SetProperty(ref _IsAnnual, value); }
        }

        public override ICalendarEvent GetSource()
        {
            if (Source != null)
            {
                Source.Id = Id;
                Source.Description = Description;
                Source.DateOccur = DateOccur;
                Source.DateOccurEnd = DateOccurEnd;
                Source.IsHoliday = IsHoliday;
                Source.IsNonWorking = IsNonWorking;
                Source.IsAnnual = IsAnnual;
            }

            return Source;
        }

        public static bool operator ==(CalendarEventModel left, CalendarEventModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CalendarEventModel left, CalendarEventModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is CalendarEventModel value)
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
