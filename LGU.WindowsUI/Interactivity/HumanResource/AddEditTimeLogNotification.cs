using LGU.Entities.HumanResource;
using LGU.Models.HumanResource;

namespace LGU.Interactivity.HumanResource
{
    public sealed class AddEditTimeLogNotification : CustomNotification, IAddEditTimeLogNotification
    {
        private const string HEADER_TEXT_ADD = "Add new Time-Log";
        private const string HEADER_TEXT_EDIT = "Edit Time-Log";

        public static AddEditTimeLogNotification Add(IEmployee employee)
        {
            return new AddEditTimeLogNotification(AddEditTimeLogMode.Add, new TimeLogModel(new TimeLog(employee)));
        }

        public static AddEditTimeLogNotification Edit(TimeLogModel timeLog)
        {
            return new AddEditTimeLogNotification(AddEditTimeLogMode.Edit, timeLog);
        }

        public AddEditTimeLogNotification(AddEditTimeLogMode mode, TimeLogModel timeLog)
        {
            Mode = mode;
            TimeLog = timeLog;

            UpdateHeaderText();
        }

        public AddEditTimeLogMode Mode { get; }

        private TimeLogModel _TimeLog;
        public TimeLogModel TimeLog
        {
            get { return _TimeLog; }
            set { SetProperty(ref _TimeLog, value); }
        }

        private string _HeaderText;
        public string HeaderText
        {
            get { return _HeaderText; }
            set { SetProperty(ref _HeaderText, value); }
        }

        private void UpdateHeaderText()
        {
            switch (Mode)
            {
                case AddEditTimeLogMode.Add:
                    HeaderText = HEADER_TEXT_ADD;
                    break;
                case AddEditTimeLogMode.Edit:
                    HeaderText = HEADER_TEXT_EDIT;
                    break;
            }
        }
    }
}
