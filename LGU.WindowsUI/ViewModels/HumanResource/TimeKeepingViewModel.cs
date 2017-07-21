﻿using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using DPFP.Verification;
using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events;
using LGU.Models.HumanResource;
using LGU.Processes;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace LGU.ViewModels.HumanResource
{
    public class TimeKeepingViewModel : ViewModelBase, DPFP.Capture.EventHandler
    {
        private readonly IEmployeeFingerPrintSetManager EmployeeFingerPrintSetManager;
        private readonly ITimeLogManager TimeLogManager;
        private readonly Capture Capture;
        private readonly Verification Verification;
        //private readonly FingerprintCore FingerPrint;
        //private FingerprintRawImage RawImage { get; set; }
        //private FingerprintTemplate Template { get; set; }

        public TimeKeepingViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            // GRAIULE
            //FingerPrint = new FingerprintCore();
            //FingerPrint.onFinger += FingerPrint_onFinger;
            //FingerPrint.onImage += FingerPrint_onImage;
            //FingerPrint.onStatus += FingerPrint_onStatus;

            EmployeeFingerPrintSetManager = SystemRuntime.Services.GetService<IEmployeeFingerPrintSetManager>();
            TimeLogManager = SystemRuntime.Services.GetService<ITimeLogManager>();
            Capture = new Capture();
            Verification = new Verification();
            Timer = new Timer(1000);
            ResultDisplayTimer = new Timer(3000);
            Timer.Elapsed += Timer_Elapsed;
            ResultDisplayTimer.Elapsed += ResultDisplayTimer_Elapsed;
            TestCommand = new DelegateCommand(Test);
            NotFoundCommand = new DelegateCommand(NotFound);
            LogResults.Add(NotYetReadyResult);
            LogResults.Add(EmployeeNotFoundResult);
            LogResults.Add(ScanYourFingerNowResult);
        }

        //private void FingerPrint_onStatus(object source, StatusEventArgs se)
        //{
        //    if (se.StatusEventType == StatusEventType.SENSOR_PLUG)
        //    {
        //        FingerPrint.StartCapture(source.ToString());
        //    }
        //    else
        //    {
        //        FingerPrint.StopCapture(source.ToString());
        //    }
        //}

        //private void FingerPrint_onImage(object source, ImageEventArgs ie)
        //{
        //    RawImage = ie.RawImage;
        //    ExtractTemplate();
        //    Identify();
        //    //SetFingerStatus();
        //}

        //private void ExtractTemplate()
        //{
        //    if (RawImage != null)
        //    {
        //        try
        //        {
        //            FingerprintTemplate template = null;
        //            FingerPrint.Extract(RawImage, ref template);
        //            Template = template;
        //        }
        //        catch (Exception ex)
        //        {
        //            ShowErrorMessage(ex.Message);
        //        }
        //    }
        //}

        //private void Identify()
        //{
        //    try
        //    {
        //        if (Template != null && Template.Size > 0)
        //        {
        //            FingerPrint.IdentifyPrepare(Template);
        //            foreach (var item in FingerPrintSetCollection)
        //            {
        //                foreach (var fingerPrintSet in item)
        //                {
        //                    if (Compare(fingerPrintSet, out int score))
        //                    {
        //                        ShowInfoMessage(fingerPrintSet.Employee?.ToString());
        //                        return;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowErrorMessage(ex.Message);
        //    }
        //}

        //private bool Compare(FingerPrintSet set, out int score)
        //{
        //    return
        //        Compare(set.LeftThumb, out score) ||
        //        Compare(set.LeftIndexFinger, out score) ||
        //        Compare(set.LeftMiddleFinger, out score) ||
        //        Compare(set.LeftRingFinger, out score) ||
        //        Compare(set.LeftLittleFinger, out score) ||
        //        Compare(set.RightThumb, out score) ||
        //        Compare(set.RightIndexFinger, out score) ||
        //        Compare(set.RightMiddleFinger, out score) ||
        //        Compare(set.RightRingFinger, out score) ||
        //        Compare(set.RightLittleFinger, out score);
        //}

        //private bool Compare(FingerPrint fingerPrint, out int score)
        //{
        //    if (fingerPrint.RawData == null)
        //    {
        //        score = -1;
        //        return false;
        //    }

        //    return FingerPrint.Identify(fingerPrint.GraiuleTempate, out score) == 1;
        //}

        //private void FingerPrint_onFinger(object source, FingerEventArgs fe)
        //{
        //    //ShowInfoMessage("On Finger");
        //}

        private void SetFingerStatus()
        {

        }

        private List<List<EmployeeFingerPrintSet>> FingerPrintSetCollection { get; set; }

        private IEnumerable<EmployeeFingerPrintSet> FingerPrintSetList { get; set; }

        public DelegateCommand TestCommand { get; }
        public DelegateCommand NotFoundCommand { get; }

        private string _ScannerLog;
        public string ScannerLog
        {
            get { return _ScannerLog; }
            set { SetProperty(ref _ScannerLog, value); }
        }

        private Timer Timer { get; }
        private Timer ResultDisplayTimer { get; }

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
            Invoke(() => { CurrentTimeStamp = DateTime.Now; });
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
            var result = await EmployeeFingerPrintSetManager.GetListAsync();

            if (result.Status == ProcessResultStatus.Success)
            {
                var list = new List<TimeKeepingResult>();
                FingerPrintSetCollection = new List<List<EmployeeFingerPrintSet>>();
                await Task.Run(() =>
                {
                    var parentIndex = 0;
                    FingerPrintSetCollection.Add(new List<EmployeeFingerPrintSet>());

                    foreach (var item in result.DataList)
                    {
                        if (FingerPrintSetCollection[parentIndex].Count > (result.DataList.Count() / 3))
                        {
                            FingerPrintSetCollection.Add(new List<EmployeeFingerPrintSet>());
                            parentIndex = FingerPrintSetCollection.Count - 1;
                        }

                        FingerPrintSetCollection[parentIndex].Add(item);

                        list.Add(new TimeKeepingResult()
                        {
                            Key = item.Employee.Id.ToString(),
                            Employee = new EmployeeModel(item.Employee),
                            Message = "logged",
                            Type = TimeKeepingResultType.Logged
                        });
                    }
                });

                LogResults.AddRange(list);

            }
            else
            {
                ShowErrorMessage(result.Message);
            }
        }

        public async override void Initialize()
        {
            EventAggregator.GetEvent<TitleEvent>().Publish("Time-Keeping");
            Capture.EventHandler = this;
            SelectedLogResult = NotYetReadyResult;
            await GetFingerPrintSetListAsync();

            Timer.Start();
            SelectedLogResult = ScanYourFingerNowResult;

            //FingerPrint.Initialize();
            //FingerPrint.CaptureInitialize();
            StartScanner();
        }

        private void Test()
        {
            if (FingerPrintSetList != null)
            {
                var rand = new Random();
                
                ResultDisplayTimer.Stop();
                var employee = new EmployeeModel(FingerPrintSetList.ElementAt(rand.Next(0, FingerPrintSetList.Count())).Employee);
                var key = employee.Id.ToString();
                var result = LogResults.FirstOrDefault(tkr => tkr.Key == key);

                //if (result == null)
                //{
                //    result = new TimeKeepingResult()
                //    {
                //        Key = key,
                //        Employee = employee,
                //        Message = "Logged",
                //        Type = TimeKeepingResultType.Logged
                //    };
                //    LogResults.Add(result);
                //}
                result.LogDate = CurrentTimeStamp ?? DateTime.Now;
                result.LogType = result.LogType == LogType.IN ? LogType.OUT : LogType.IN;
                SelectedLogResult = result;

                ResultDisplayTimer.Start();
            }
        }

        private void NotFound()
        {
            ResultDisplayTimer.Stop();
            SelectedLogResult = EmployeeNotFoundResult;
            ResultDisplayTimer.Start();
        }

        public void Destruct()
        {
            StopScanner();
        }

        private void StartScanner()
        {
            StopScanner();
            
            if (Capture != null)
            {
                Capture.StartCapture();
                Invoke(() => ScannerLog = "Using the fingerprint reader, scan your fingerprint.");
            }
            else
            {
                Invoke(() => ScannerLog = "Can't initiate capture.");
            }
        }

        private void StopScanner()
        {
            if (Capture != null)
            {
                try
                {

                    Capture.StopCapture();
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

        private bool EmployeeFound;

        private void ProcessFingerPrintAsync(Sample sample)
        {
            var features = FingerPrintScannerHelper.ExtractFeatures(sample, DataPurpose.Verification);

            if (features != null)
            {
                ResultDisplayTimer.Stop();
                EmployeeFound = false;
                var tasks = new List<Task>();

                Debug.WriteLine("Start-Loading-Tasks: {0}", DateTime.Now.ToString("hh:mm:ss fff"));
                //Parallel.ForEach(FingerPrintSetCollection, f => SearchFingerPrint(f, features));
                
                Parallel.ForEach(FingerPrintSetCollection, async (f) => await SearchFingerPrintAsync(f, features));
                
                
                //foreach (var item in FingerPrintSetCollection)
                //{
                //    tasks.Add(SearchFingerPrintAsync(item, features));
                //}
                Debug.WriteLine("End-Loading-Tasks: {0}", DateTime.Now.ToString("hh:mm:ss fff"));

                //Debug.WriteLine("Start-Tasks: {0}", DateTime.Now.ToString("hh:mm:ss fff"));
                //await Task.WhenAll(tasks);
                //Debug.WriteLine("End-Tasks: {0}", DateTime.Now.ToString("hh:mm:ss fff"));

                if (!EmployeeFound)
                {
                    SelectedLogResult = EmployeeNotFoundResult;
                }

                //bool employeeFound = false;
                //foreach (var fingerPrintSet in FingerPrintSetList)
                //{
                //    if (Compare(features, fingerPrintSet))
                //    {
                //        var result = LogResults.FirstOrDefault(r => r.Key == fingerPrintSet.Employee.Id.ToString());
                //        result.LogDate = CurrentTimeStamp ?? DateTime.Now;
                //        result.LogType = result.LogType == LogType.IN ? LogType.OUT : LogType.IN;
                //        SelectedLogResult = result;
                //        employeeFound = true;
                //        break;
                //    }
                //}
                
                //if (!employeeFound)
                //{
                //    SelectedLogResult = EmployeeNotFoundResult;
                //}
                ResultDisplayTimer.Start();
            }
        }

        private async Task SearchFingerPrintAsync(IEnumerable<EmployeeFingerPrintSet> fingerPrintSetList, FeatureSet features)
        {
            foreach (var fingerPrintSet in fingerPrintSetList)
            {
                if (EmployeeFound)
                {
                    break;
                }

                if (Compare(features, fingerPrintSet))
                {
                    var timeLogResult = await TimeLogManager.LogAsync(fingerPrintSet.Employee);
                    if (timeLogResult.Status == ProcessResultStatus.Success)
                    {
                        //Debug.WriteLine("Start: {0}", DateTime.Now.ToString("hh:mm:ss fff"));
                        var timeLog = timeLogResult.Data;
                        var result = LogResults.FirstOrDefault(r => r.Key == timeLog.Employee.Id.ToString());
                        result.LogDate = (timeLog.LogoutDate ?? timeLog.LoginDate) ?? DateTime.Now;
                        result.LogType = (timeLog.LogoutDate == null) ? LogType.IN : LogType.OUT;
                        Invoke(() => SelectedLogResult = result);
                        EmployeeFound = true;
                        //Debug.WriteLine("End: {0}", DateTime.Now.ToString("hh:mm:ss fff"));
                        break;
                    }
                }
            }
        }

        private void SearchFingerPrint(IEnumerable<EmployeeFingerPrintSet> fingerPrintSetList, FeatureSet features)
        {
            Parallel.ForEach(fingerPrintSetList, async fingerPrintSet =>
            {
                if (!EmployeeFound)
                {
                    if (Compare(features, fingerPrintSet))
                    {
                        var timeLogResult = await TimeLogManager.LogAsync(fingerPrintSet.Employee);
                        if (timeLogResult.Status == ProcessResultStatus.Success)
                        {
                            Debug.WriteLine("Start: {0}", DateTime.Now.ToString("hh:mm:ss fff"));
                            var timeLog = timeLogResult.Data;
                            var result = LogResults.FirstOrDefault(r => r.Key == timeLog.Employee.Id.ToString());
                            result.LogDate = (timeLog.LogoutDate ?? timeLog.LoginDate) ?? DateTime.Now;
                            result.LogType = (timeLog.LogoutDate == null) ? LogType.IN : LogType.OUT;
                            Invoke(() => SelectedLogResult = result);
                            EmployeeFound = true;
                            Debug.WriteLine("End: {0}", DateTime.Now.ToString("hh:mm:ss fff"));
                        }
                    }
                }
            });
        }

        private bool Compare(FeatureSet features, EmployeeFingerPrintSet fingerPrintSet)
        {
            if (features != null && fingerPrintSet != null)
            {
                var verified = false;

                if (SafeVerify(features, fingerPrintSet.LeftThumb))
                {
                    return true;
                }

                if (SafeVerify(features, fingerPrintSet.LeftIndexFinger))
                {
                    return true;
                }
                if (SafeVerify(features, fingerPrintSet.LeftMiddleFinger))
                {
                    return true;
                }
                if (SafeVerify(features, fingerPrintSet.LeftRingFinger))
                {
                    return true;
                }
                if (SafeVerify(features, fingerPrintSet.LeftLittleFinger))
                {
                    return true;
                }
                if (SafeVerify(features, fingerPrintSet.RightThumb))
                {
                    return true;
                }
                if (SafeVerify(features, fingerPrintSet.RightIndexFinger))
                {
                    return true;
                }
                if (SafeVerify(features, fingerPrintSet.RightMiddleFinger))
                {
                    return true;
                }
                if (SafeVerify(features, fingerPrintSet.RightRingFinger))
                {
                    return true;
                }
                if (SafeVerify(features, fingerPrintSet.RightLittleFinger))
                {
                    return true;
                }

                //return
                //    SafeVerify(features, fingerPrintSet.LeftThumb) ||
                //    SafeVerify(features, fingerPrintSet.LeftIndexFinger) ||
                //    SafeVerify(features, fingerPrintSet.LeftMiddleFinger) ||
                //    SafeVerify(features, fingerPrintSet.LeftRingFinger) ||
                //    SafeVerify(features, fingerPrintSet.LeftLittleFinger) ||
                //    SafeVerify(features, fingerPrintSet.RightThumb) ||
                //    SafeVerify(features, fingerPrintSet.RightIndexFinger)||
                //    SafeVerify(features, fingerPrintSet.RightMiddleFinger) ||
                //    SafeVerify(features, fingerPrintSet.RightRingFinger) ||
                //    SafeVerify(features, fingerPrintSet.RightLittleFinger);
                return verified;
            }
            else
            {
                return false;
            }
        }

        private bool SafeVerify(FeatureSet features, FingerPrint fingerPrint)
        {
            Verification.Result result = new Verification.Result();
            
            if (features != null && fingerPrint.Data != null)
            {
                Verification.Verify(features, fingerPrint.Data, ref result);
            }

            return result.Verified;
        }

        #region Finger Print Events
        public void OnComplete(object capture, string readerSerialNumber, Sample sample)
        {
            Invoke(() => ScannerLog = "The finger print sample was captured.");
            ProcessFingerPrintAsync(sample);
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
        #endregion
    }
}
