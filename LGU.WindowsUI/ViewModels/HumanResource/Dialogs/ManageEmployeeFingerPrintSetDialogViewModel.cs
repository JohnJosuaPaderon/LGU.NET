using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Diagnostics;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class ManageEmployeeFingerPrintSetDialogViewModel : DialogViewModelBase, DPFP.Capture.EventHandler
    {
        private readonly IEmployeeFingerPrintSetManager r_EmployeeFingerPrintSetManager;
        private readonly ManageEmployeeFingerPrintSetEvent r_ManageEmployeeFingerPrintSetEvent;
        private readonly Capture Capture;
        private Enrollment r_Enrollment;

        public ManageEmployeeFingerPrintSetDialogViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_EmployeeFingerPrintSetManager = ApplicationDomain.GetService<IEmployeeFingerPrintSetManager>();

            r_ManageEmployeeFingerPrintSetEvent = r_EventAggregator.GetEvent<ManageEmployeeFingerPrintSetEvent>();
            Capture = new Capture();
            ChangeCurrentFingerPrintCommand = new DelegateCommand<FingerPrintModel>(ChangeCurrentFingerPrint);
            SaveCommand = new DelegateCommand(Save);
            Initialize();
        }

        public DelegateCommand<FingerPrintModel> ChangeCurrentFingerPrintCommand { get; }
        public DelegateCommand SaveCommand { get; }

        private FingerPrintModel _CurrentFingerPrint;
        public FingerPrintModel CurrentFingerPrint
        {
            get { return _CurrentFingerPrint; }
            set { SetProperty(ref _CurrentFingerPrint, value); }
        }

        private EmployeeFingerPrintSetModel _FingerPrintSet;
        public EmployeeFingerPrintSetModel FingerPrintSet
        {
            get { return _FingerPrintSet; }
            set { SetProperty(ref _FingerPrintSet, value); }
        }

        private string _ScannerLog;
        public string ScannerLog
        {
            get { return _ScannerLog; }
            set { SetProperty(ref _ScannerLog, value); }
        }

        private uint _RemainingScans;
        public uint RemainingScans
        {
            get { return _RemainingScans; }
            set { SetProperty(ref _RemainingScans, value); }
        }

        private void ChangeCurrentFingerPrint(FingerPrintModel fingerPrint)
        {
            if (fingerPrint != null)
            {
                CurrentFingerPrint = fingerPrint;
                CurrentFingerPrint.Data = null;
                StartScanner();
            }
        }

        private async void Save()
        {
            var result = await r_EmployeeFingerPrintSetManager.InsertAsync(FingerPrintSet.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                DialogHelper.CloseDialog();
                ShowInfoMessage("Employee successfully enrolled.");
            }
            else
            {
                ShowErrorMessage("Failed to enroll employee.");
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            r_ManageEmployeeFingerPrintSetEvent.Subscribe((efps) => FingerPrintSet = efps);
            Capture.EventHandler = this;
        }

        public void Destruct()
        {
            StopScanner();
        }

        private void StartScanner()
        {
            r_Enrollment = new Enrollment();
            StopScanner();

            Invoke(() => RemainingScans = r_Enrollment.FeaturesNeeded);

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
                    r_Enrollment.Clear();
                    Capture.StopCapture();
                }
                catch (Exception)
                {
                    Invoke(() => ScannerLog = "Can't terminate capture.");
                }
            }
        }

        private void ProcessFingerPrint(Sample sample)
        {
            var features = FingerPrintScannerHelper.ExtractFeatures(sample, DataPurpose.Enrollment);

            if (features != null)
            {
                try
                {
                    r_Enrollment.AddFeatures(features);
                    Invoke(() => ScannerLog = "The fingerprint feature set was created.");
                    Invoke(() => RemainingScans = r_Enrollment.FeaturesNeeded);
                }
                catch(Exception)
                {
                    Invoke(() => ScannerLog = "Failed to enroll.");
                }
                finally
                {
                    switch (r_Enrollment.TemplateStatus)
                    {
                        case Enrollment.Status.Failed:
                            r_Enrollment.Clear();
                            StopScanner();
                            Invoke(() => RemainingScans = r_Enrollment.FeaturesNeeded);
                            Invoke(() => CurrentFingerPrint.Data = null);
                            StartScanner();
                            break;
                        case Enrollment.Status.Ready:
                            Debug.WriteLine("Enrollment Start : Hand Type = {0}; Finger Type = {1}", CurrentFingerPrint.HandType, CurrentFingerPrint.FingerType);
                            Invoke(() => CurrentFingerPrint.Data = r_Enrollment.Template);
                            Debug.WriteLine("Enrollment End : Hand Type = {0}; Finger Type = {1}", CurrentFingerPrint.HandType, CurrentFingerPrint.FingerType);
                            Invoke(() => ScannerLog = "Fingerprint successfully set.");
                            StopScanner();
                            break;
                    }
                }
            }
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
