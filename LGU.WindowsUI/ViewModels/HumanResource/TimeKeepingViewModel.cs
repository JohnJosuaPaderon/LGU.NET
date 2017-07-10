using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using DPFP.Verification;
using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;

namespace LGU.ViewModels.HumanResource
{
    public class TimeKeepingViewModel : ViewModelBase, DPFP.Capture.EventHandler
    {
        private readonly IEmployeeFingerPrintSetManager EmployeeFingerPrintSetManager;
        private readonly Capture Capture;
        private readonly Verification Verification;

        public TimeKeepingViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            EmployeeFingerPrintSetManager = SystemRuntime.Services.GetService<IEmployeeFingerPrintSetManager>();
            Capture = new Capture();
            Verification = new Verification();
        }

        private IEnumerable<EmployeeFingerPrintSet> FingerPrintSetList { get; set; }

        private string _ScannerLog;
        public string ScannerLog
        {
            get { return _ScannerLog; }
            set { SetProperty(ref _ScannerLog, value); }
        }

        public async override void Initialize()
        {
            EventAggregator.GetEvent<TitleEvent>().Publish("Time-Keeping");
            Capture.EventHandler = this;

            var result = await EmployeeFingerPrintSetManager.GetListAsync();

            if (result.Status == ProcessResultStatus.Success)
            {
                FingerPrintSetList = result.DataList;
            }

            StartScanner();
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
            System.Windows.Application.Current.Dispatcher.Invoke(expression);
        }

        private void ProcessFingerPrint(Sample sample)
        {
            var features = FingerPrintScannerHelper.ExtractFeatures(sample, DataPurpose.Verification);

            if (features != null)
            {
                foreach (var fingerPrintSet in FingerPrintSetList)
                {
                    if (Compare(features, fingerPrintSet))
                    {
                        ShowInfoMessage(fingerPrintSet.Employee.FullName);
                    }
                }
            }
        }

        private bool Compare(FeatureSet features, EmployeeFingerPrintSet fingerPrintSet)
        {
            if (features != null && fingerPrintSet != null)
            {
                return
                    SafeVerify(features, fingerPrintSet.LeftThumb) ||
                    SafeVerify(features, fingerPrintSet.LeftIndexFinger) ||
                    SafeVerify(features, fingerPrintSet.LeftMiddleFinger) ||
                    SafeVerify(features, fingerPrintSet.LeftRingFinger) ||
                    SafeVerify(features, fingerPrintSet.LeftLittleFinger) ||
                    SafeVerify(features, fingerPrintSet.RightThumb) ||
                    SafeVerify(features, fingerPrintSet.RightIndexFinger) ||
                    SafeVerify(features, fingerPrintSet.RightMiddleFinger) ||
                    SafeVerify(features, fingerPrintSet.RightRingFinger) ||
                    SafeVerify(features, fingerPrintSet.RightLittleFinger);
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
            ProcessFingerPrint(sample);
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
