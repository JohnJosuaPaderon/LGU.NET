using DPFP;
using DPFP.Capture;
using DPFP.ID;
using DPFP.Processing;
using LGU.Entities.HumanResource;
using LGU.EntityManagers;
using LGU.EntityManagers.HumanResource;
using LGU.Events;
using LGU.Extensions;
using LGU.Models.HumanResource;
using LGU.Processes;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace LGU.ViewModels.HumanResource
{
    public class TimeKeepingViewModel : ViewModelBase, DPFP.Capture.EventHandler, DPFP.ID.EventHandler
    {
        private readonly IEmployeeFingerPrintSetManager r_EmployeeFingerPrintSetManager;
        private readonly ITimeLogManager r_TimeLogManager;
        private readonly ISystemManager r_SystemManager;
        private readonly Capture r_Capture;
        private readonly IConnectionStringSource r_ConnectionStringSource;

        public TimeKeepingViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_EmployeeFingerPrintSetManager = SystemRuntime.GetService<IEmployeeFingerPrintSetManager>();
            r_TimeLogManager = SystemRuntime.GetService<ITimeLogManager>();
            r_SystemManager = SystemRuntime.GetService<ISystemManager>();
            r_ConnectionStringSource = SystemRuntime.GetService<IConnectionStringSource>();
            r_Capture = new Capture();
            Users = new UserCollection(1000000);
            Identification = new Identification(ref Users)
            {
                EventHandler = this
            };
            Timer = new Timer(1000);
            TimerRefresher = new Timer(60000);
            ResultDisplayTimer = new Timer(5000);
            DataUpdateTimer = new Timer(10000);
            Timer.Elapsed += Timer_Elapsed;
            TimerRefresher.Elapsed += TimerRefresher_Elapsed;
            ResultDisplayTimer.Elapsed += ResultDisplayTimer_Elapsed;
            DataUpdateTimer.Elapsed += DataUpdateTimer_Elapsed;
            LogResults.Add(NotYetReadyResult);
            LogResults.Add(EmployeeNotFoundResult);
            LogResults.Add(ScanYourFingerNowResult);
            LogResults.Add(DatabaseUnavailableResult);
        }

        private void DataUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(async () => await GetUpdatedFingerPrintSetListAsync());
        }

        private void TimerRefresher_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(async () => await GetSystemDateAsync());
        }

        private string _ScannerLog;
        public string ScannerLog
        {
            get { return _ScannerLog; }
            set { SetProperty(ref _ScannerLog, value); }
        }
        
        private DateTime LastDataUpdate { get; set; }
        private Timer Timer { get; }
        private Timer ResultDisplayTimer { get; }
        private Timer TimerRefresher { get; }
        private Timer DataUpdateTimer { get; }
        private FeatureExtraction FeatureExtraction = new FeatureExtraction();
        private Identification Identification;
        private UserCollection Users;

        public ObservableCollection<char> Hour1Source { get; } = new ObservableCollection<char>() { 'h', '0', '1' };
        public ObservableCollection<char> Hour2Source { get; } = new ObservableCollection<char>() { 'h', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public ObservableCollection<char> Minute1Source { get; } = new ObservableCollection<char>() { 'm', '0', '1', '2', '3', '4', '5' };
        public ObservableCollection<char> Minute2Source { get; } = new ObservableCollection<char>() { 'm', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public ObservableCollection<char> Second1Source { get; } = new ObservableCollection<char>() { 's', '0', '1', '2', '3', '4', '5' };
        public ObservableCollection<char> Second2Source { get; } = new ObservableCollection<char>() { 's', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public ObservableCollection<string> AmPmSource { get; } = new ObservableCollection<string>() { "tt", "AM", "PM" };
        public ObservableCollection<TimeKeepingResult> LogResults { get; } = new ObservableCollection<TimeKeepingResult>();

        private TimeKeepingResult NotYetReadyResult { get; } = new TimeKeepingResult()
        {
            Key = nameof(NotYetReadyResult),
            Employee = null,
            Message = "Time-Keeping is not yet ready",
            Type = TimeKeepingResultType.MessageOnly
        };

        private TimeKeepingResult EmployeeNotFoundResult { get; } = new TimeKeepingResult()
        {
            Key = nameof(EmployeeNotFoundResult),
            Employee = null,
            Message = "Employee Not Found",
            Type = TimeKeepingResultType.MessageOnly
        };

        private TimeKeepingResult ScanYourFingerNowResult { get; } = new TimeKeepingResult()
        {
            Key = nameof(ScanYourFingerNowResult),
            Employee = null,
            Message = "Scan Your Finger Now",
            Type = TimeKeepingResultType.MessageOnly
        };

        private TimeKeepingResult DatabaseUnavailableResult { get; } = new TimeKeepingResult()
        {
            Key = nameof(DatabaseUnavailableResult),
            Employee = null,
            Message = "Unable to establish database connection\nPlease report this error immediately.",
            Type = TimeKeepingResultType.MessageOnly
        };

        private DateTime? _CurrentTimeStamp;
        public DateTime? CurrentTimeStamp
        {
            get { return _CurrentTimeStamp; }
            set
            {
                SetProperty(ref _CurrentTimeStamp, value, () =>
                {
                    var currentTimeStamp = value ?? DateTime.Now;
                    var hours = currentTimeStamp.ToString("hh");
                    var minutes = currentTimeStamp.ToString("mm");
                    var seconds = currentTimeStamp.ToString("ss");

                    SelectedAmPm = currentTimeStamp.ToString("tt");
                    SelectedHour1 = hours[0];
                    SelectedHour2 = hours[1];
                    SelectedMinute1 = minutes[0];
                    SelectedMinute2 = minutes[1];
                    SelectedSecond1 = seconds[0];
                    SelectedSecond2 = seconds[1];
                });
            }
        }

        private char _SelectedHour1 = 'h';
        public char SelectedHour1
        {
            get { return _SelectedHour1; }
            set { SetProperty(ref _SelectedHour1, value); }
        }

        private char _SelectedHour2 = 'h';
        public char SelectedHour2
        {
            get { return _SelectedHour2; }
            set { SetProperty(ref _SelectedHour2, value); }
        }

        private char _SelectedMinute1 = 'm';
        public char SelectedMinute1
        {
            get { return _SelectedMinute1; }
            set { SetProperty(ref _SelectedMinute1, value); }
        }

        private char _SelectedMinute2 = 'm';
        public char SelectedMinute2
        {
            get { return _SelectedMinute2; }
            set { SetProperty(ref _SelectedMinute2, value); }
        }

        private char _SelectedSecond1 = 's';
        public char SelectedSecond1
        {
            get { return _SelectedSecond1; }
            set { SetProperty(ref _SelectedSecond1, value); }
        }

        private char _SelectedSecond2 = 's';
        public char SelectedSecond2
        {
            get { return _SelectedSecond2; }
            set { SetProperty(ref _SelectedSecond2, value); }
        }

        private string _SelectedAmPm = "tt";
        public string SelectedAmPm
        {
            get { return _SelectedAmPm; }
            set { SetProperty(ref _SelectedAmPm, value); }
        }

        private TimeKeepingResult _SelectedLogResult;
        public TimeKeepingResult SelectedLogResult
        {
            get { return _SelectedLogResult; }
            set { SetProperty(ref _SelectedLogResult, value); }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(() => { CurrentTimeStamp = CurrentTimeStamp?.AddSeconds(1) ?? DateTime.Now; });
        }

        private void ResultDisplayTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ResultDisplayTimer.Stop();
            Invoke(() =>
            {
                SelectedLogResult = ScanYourFingerNowResult;
            });
        }

        private async Task GetFingerPrintSetListAsync()
        {
            var result = await r_EmployeeFingerPrintSetManager.GetListAsync();
            LastDataUpdate = DateTime.Now;
            if (result.Status == ProcessResultStatus.Success)
            {
                var list = new List<TimeKeepingResult>();

                if (result.DataList != null)
                {
                    foreach (var item in result.DataList)
                    {
                        AddUpdateFingerPrintUser(item);
                    }
                }

                LogResults.AddRange(list);
            }
            else
            {
                SelectedLogResult = DatabaseUnavailableResult;
            }
        }

        private void AddUpdateFingerPrintUser(EmployeeFingerPrintSet fingerPrintSet)
        {
            var employeeId = fingerPrintSet.Employee.Id.ToString();
            var userId = new UserID(employeeId);

            if (!Users.UserExists(userId))
            {
                var user = new User(userId);
                user.AddFingerPrint(fingerPrintSet.LeftThumb);
                user.AddFingerPrint(fingerPrintSet.LeftIndexFinger);
                user.AddFingerPrint(fingerPrintSet.LeftMiddleFinger);
                user.AddFingerPrint(fingerPrintSet.LeftRingFinger);
                user.AddFingerPrint(fingerPrintSet.LeftLittleFinger);
                user.AddFingerPrint(fingerPrintSet.RightThumb);
                user.AddFingerPrint(fingerPrintSet.RightIndexFinger);
                user.AddFingerPrint(fingerPrintSet.RightMiddleFinger);
                user.AddFingerPrint(fingerPrintSet.RightRingFinger);
                user.AddFingerPrint(fingerPrintSet.RightLittleFinger);
                Users.AddUser(ref user);

                LogResults.Add(new TimeKeepingResult()
                {
                    Key = employeeId,
                    Employee = new EmployeeModel(fingerPrintSet?.Employee),
                    Message = "logged",
                    Type = TimeKeepingResultType.Logged
                });
            }
            else
            {
                var user = Users[userId];
                user.ClearTemplates();
                user.AddFingerPrint(fingerPrintSet.LeftThumb);
                user.AddFingerPrint(fingerPrintSet.LeftIndexFinger);
                user.AddFingerPrint(fingerPrintSet.LeftMiddleFinger);
                user.AddFingerPrint(fingerPrintSet.LeftRingFinger);
                user.AddFingerPrint(fingerPrintSet.LeftLittleFinger);
                user.AddFingerPrint(fingerPrintSet.RightThumb);
                user.AddFingerPrint(fingerPrintSet.RightIndexFinger);
                user.AddFingerPrint(fingerPrintSet.RightMiddleFinger);
                user.AddFingerPrint(fingerPrintSet.RightRingFinger);
                user.AddFingerPrint(fingerPrintSet.RightLittleFinger);
            }
        }

        private async Task GetUpdatedFingerPrintSetListAsync()
        {
            var result = await r_EmployeeFingerPrintSetManager.GetUpdatedListAsync(LastDataUpdate);

            if (result.Status == ProcessResultStatus.Success)
            {
                LastDataUpdate = CurrentTimeStamp ?? DateTime.Now;

                if (result.DataList != null && result.DataList.Any())
                {
                    foreach (var item in result.DataList)
                    {
                        AddUpdateFingerPrintUser(item);
                    }
                }
            }
        }

        public async override void Initialize()
        {
            r_EventAggregator.GetEvent<TitleEvent>().Publish("Time-Keeping");
            r_Capture.EventHandler = this;
            SelectedLogResult = NotYetReadyResult;

            await GetSystemDateAsync();
            Timer.Start();
            TimerRefresher.Start();

            if (SelectedLogResult != DatabaseUnavailableResult)
            {
                await GetFingerPrintSetListAsync();
                SelectedLogResult = ScanYourFingerNowResult;
                DataUpdateTimer.Start();

                StartScanner();
            }
        }

        private async Task GetSystemDateAsync()
        {
            var result = await r_SystemManager.GetSystemDateAsync();

            if (result.Status == ProcessResultStatus.Success)
            {
                CurrentTimeStamp = result.Data;

                if (SelectedLogResult == DatabaseUnavailableResult)
                {
                    SelectedLogResult = ScanYourFingerNowResult;
                }
            }
            else
            {
                CurrentTimeStamp = DateTime.Now;
                SelectedLogResult = DatabaseUnavailableResult;
            }
        }

        private void StartScanner()
        {
            StopScanner();
            
            if (r_Capture != null)
            {
                r_Capture.StartCapture();
                Invoke(() => ScannerLog = "Using the fingerprint reader, scan your fingerprint.");
            }
            else
            {
                Invoke(() => ScannerLog = "Can't initiate capture.");
            }
        }

        private void StopScanner()
        {
            if (r_Capture != null)
            {
                try
                {
                    r_Capture.StopCapture();
                }
                catch (Exception)
                {
                    Invoke(() => ScannerLog = "Can't terminate capture.");
                }
            }
        }

        private void Invoke(Action expression)
        {
            System.Windows.Application.Current?.Dispatcher.Invoke(expression);
        }

        public void IdentifyFeatureSet(ref FeatureSet FeatureSet)
        {
            try
            {
                CandidateIDList CandidateIDs = Identification.Identify(FeatureSet);
                
                if (CandidateIDs.Count == 0)
                {
                    SelectedLogResult = EmployeeNotFoundResult;
                    ResultDisplayTimer.Start();
                }
            }
            catch (Exception)
            {
            }
        }

        #region Finger Print Events
        public void OnComplete(object capture, string readerSerialNumber, Sample sample)
        {
            FeatureSet CapturedFeatureSet = new FeatureSet();

            CaptureFeedback CaptureSampleQuality = new CaptureFeedback();
            try
            {
                ResultDisplayTimer.Stop();
                FeatureExtraction.CreateFeatureSet(sample, DataPurpose.Verification, ref CaptureSampleQuality, ref CapturedFeatureSet);
                
                if (CaptureSampleQuality == CaptureFeedback.Good)
                {
                    IdentifyFeatureSet(ref CapturedFeatureSet);
                }
            }
            catch (Exception)
            {
            }
            
            Invoke(() => ScannerLog = "The finger print sample was captured.");
        }

        public void OnFingerGone(object capture, string readerSerialNumber)
        {
            Invoke(() => ScannerLog = "The finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object capture, string readerSerialNumber)
        {
            Invoke(() => ScannerLog = "The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object capture, string readerSerialNumber)
        {
            Invoke(() => ScannerLog = "Device connected.");
        }

        public void OnReaderDisconnect(object capture, string readerSerialNumber)
        {
            Invoke(() => ScannerLog = "Device disconnected.");
        }

        public void OnSampleQuality(object capture, string readerSerialNumber, CaptureFeedback feedback)
        {
            if (feedback == CaptureFeedback.Good)
                Invoke(() => ScannerLog = "The quality of the fingerprint sample is good.");
            else
                Invoke(() => ScannerLog = "The quality of the fingerprint sample is poor.");
        }

        public void OnStatus(object Identification, uint CandidatesFound, ref bool AbortIdentification)
        {
            ResultDisplayTimer.Start();
        }

        public void OnIdentify(object Identification, Candidate Candidate, ref bool AbortIdentification)
        {
            try
            {
                var result = LogResults.FirstOrDefault(r => r.Key == Candidate.ID.ToString());
                var logResult = r_TimeLogManager.Log(result.Employee.GetSource());

                if (logResult.Data != null)
                {
                    if (logResult.Data.State ?? false)
                    {
                        result.LogDate = logResult.Data.LoginDate ?? DateTime.Now;
                        result.LogType = LogType.IN;
                    }
                    else
                    {
                        result.LogDate = logResult.Data.LogoutDate ?? DateTime.Now;
                        result.LogType = LogType.OUT;
                    }

                    Invoke(() => SelectedLogResult = result);
                }

            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}
