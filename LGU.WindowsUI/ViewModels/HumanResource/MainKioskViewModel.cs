using DPFP;
using DPFP.Capture;
using DPFP.ID;
using DPFP.Processing;
using LGU.Entities.HumanResource;
using LGU.EntityManagers;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Extensions;
using LGU.Models.HumanResource;
using LGU.Processes;
using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace LGU.ViewModels.HumanResource
{
    public class MainKioskViewModel : ViewModelBase, DPFP.Capture.EventHandler, DPFP.ID.EventHandler
    {
        public static string KioskContentRegion => nameof(KioskContentRegion);
        public static EmployeeModel SelectedKioskEmployee { get; private set; }

        public MainKioskViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_FeatureExtraction = new FeatureExtraction();
            r_Users = new UserCollection(10_000);
            r_Identification = new Identification(ref r_Users);
            r_Capture = new Capture();
            r_EmployeeFingerPrintSetManager = ApplicationDomain.GetService<IEmployeeFingerPrintSetManager>();
            r_SystemManager = ApplicationDomain.GetService<ISystemManager>();
            r_EmployeeDictionary = new Dictionary<string, EmployeeModel>();
            r_DataUpdateTimer = new Timer(60_000);
            r_CurrentDateTimer = new Timer(1_000);
            r_KioskEmployeeChangedEvent = r_EventAggregator.GetEvent<KioskEmployeeChangedEvent>();

            r_Capture.EventHandler = this;
            r_Identification.EventHandler = this;

            r_ShowCloseButtonEvent.Publish(false);
            r_ShowMaxRestorButtonEvent.Publish(false);
            r_ShowMinButtonEvent.Publish(false);
            r_ShowTitleBarEvent.Publish(false);
            r_AccountDisplayEvent.Publish(false);

            EndSessionCommand = new DelegateCommand(EndSession);
            NavigateCommand = new DelegateCommand<string>(Navigate);

            r_DataUpdateTimer.Elapsed += DataUpdateTimer_Elapsed;
            r_CurrentDateTimer.Elapsed += CurrentDateTimer_Elapsed;
        }

        private readonly FeatureExtraction r_FeatureExtraction;
        private readonly Identification r_Identification;
        private readonly UserCollection r_Users;
        private readonly Capture r_Capture;
        private readonly IEmployeeFingerPrintSetManager r_EmployeeFingerPrintSetManager;
        private readonly ISystemManager r_SystemManager;
        private readonly Dictionary<string, EmployeeModel> r_EmployeeDictionary;
        private readonly Timer r_DataUpdateTimer;
        private readonly Timer r_CurrentDateTimer;
        private readonly KioskEmployeeChangedEvent r_KioskEmployeeChangedEvent;

        private DateTime LastDataUpdate { get; set; }
        private DateTime CurrentDate { get; set; }
        public DelegateCommand EndSessionCommand { get; }
        public DelegateCommand<string> NavigateCommand { get; }

        private int _SelectedPage;
        public int SelectedPage
        {
            get { return _SelectedPage; }
            set { SetProperty(ref _SelectedPage, value, OnSelectedPageChanged); }
        }

        private EmployeeModel _Employee;
        public EmployeeModel Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value, OnEmployeeChanged); }
        }

        protected async override void Initialize()
        {
            Navigate(nameof(KioskServiceSelectionView));
            SelectedPage = 0;
            await GetSystemDateAsync();
            await GetFingerPrintSetListAsync();
        }

        private void Navigate(string viewName)
        {
            r_RegionManager.RequestNavigate(KioskContentRegion, viewName);
        }

        private async Task GetSystemDateAsync()
        {
            var result = await r_SystemManager.GetSystemDateAsync();

            CurrentDate = result.Status == ProcessResultStatus.Success ? result.Data : DateTime.Now;
        }

        private async Task GetFingerPrintSetListAsync()
        {
            var result = await r_EmployeeFingerPrintSetManager.GetListAsync();
            LastDataUpdate = CurrentDate;

            // Uncomment this for testing without FingerPrint Scanner.
            //EmployeeModel testEmployee = null;

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    // Uncomment this for testing without FingerPrint Scanner.
                    //testEmployee = new EmployeeModel(result.DataList.First().Employee);

                    Parallel.ForEach(result.DataList, item => AddUpdateFingerPrintUser(item));

                    //foreach (var item in result.DataList)
                    //{
                    //    AddUpdateFingerPrintUser(item);
                    //}

                    SelectedPage = 1;
                }

                r_DataUpdateTimer.Start();
                r_CurrentDateTimer.Start();

                // Uncomment this for testing without FingerPrint Scanner.
                //Employee = testEmployee;
            }
            else
            {
                r_NewMessageEvent.Publish(result.Message);
            }
        }

        private void OnSelectedPageChanged()
        {
            if (SelectedPage == 1)
            {
                StartScanner();
            }
            else
            {
                StopScanner();
            }
        }

        private void OnEmployeeChanged()
        {
            r_KioskEmployeeChangedEvent.Publish(Employee);

            if (Employee != null)
            {
                SelectedPage = 2;
            }
            else
            {
                SelectedPage = 1;
                Navigate(nameof(KioskServiceSelectionView));
            }

            SelectedKioskEmployee = Employee;
        }

        private async void DataUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await GetSystemDateAsync();

            var result = await r_EmployeeFingerPrintSetManager.GetUpdatedListAsync(LastDataUpdate);
            LastDataUpdate = CurrentDate;

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    foreach (var item in result.DataList)
                    {
                        AddUpdateFingerPrintUser(item);
                    }
                }
            }
            else
            {
                r_NewMessageEvent.Publish(result.Message);
            }
        }

        private void CurrentDateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentDate = CurrentDate.AddSeconds(1);

            if (SelectedPage != 2)
            {
                if (CurrentDate.Hour < 6 || (CurrentDate.Hour > 17 && CurrentDate.Minute < 59))
                {
                    SelectedPage = 3;
                }
                else
                {
                    SelectedPage = 1;
                }
            }
        }

        private void AddUpdateFingerPrintUser(IEmployeeFingerPrintSet fingerPrintSet)
        {
            var employeeId = fingerPrintSet.Employee.Id.ToString();
            var userId = new UserID(employeeId);

            if (!r_Users.UserExists(userId))
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
                r_Users.AddUser(ref user);
                r_EmployeeDictionary.Add(employeeId, new EmployeeModel(fingerPrintSet.Employee));
            }
            else
            {
                var user = r_Users[userId];
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
                r_EmployeeDictionary[employeeId] = new EmployeeModel(fingerPrintSet.Employee);
            }
        }

        private void EndSession()
        {
            Employee = null;
            r_NewMessageEvent.Publish($"Session has been ended @ {DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt")}");
        }

        private void IdentifyFeatureSet(ref FeatureSet FeatureSet)
        {
            try
            {
                CandidateIDList CandidateIDs = r_Identification.Identify(FeatureSet);

                if (CandidateIDs.Count == 0)
                {
                    Employee = null;
                    r_NewMessageEvent.Publish("No employee found.");
                }
            }
            catch (Exception)
            {
            }
        }

        private void StartScanner()
        {
            StopScanner();

            if (r_Capture != null)
            {
                r_Capture.StartCapture();
            }
            else
            {
                r_NewMessageEvent.Publish("Failed to initialize finger print scanner.");
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
                }
            }
        }

        #region FingerPrint Events
        public void OnStatus(object Identification, uint CandidatesFound, ref bool AbortIdentification)
        {
        }

        public void OnIdentify(object Identification, Candidate Candidate, ref bool AbortIdentification)
        {
            Employee = r_EmployeeDictionary[Candidate.ID.ToString()];
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, Sample sample)
        {
            FeatureSet featureSet = new FeatureSet();
            CaptureFeedback feedBack = new CaptureFeedback();

            try
            {
                r_FeatureExtraction.CreateFeatureSet(sample, DataPurpose.Verification, ref feedBack, ref featureSet);

                if (feedBack == CaptureFeedback.Good)
                {
                    IdentifyFeatureSet(ref featureSet);
                }
            }
            catch (Exception)
            {
            }
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
        } 
        #endregion
    }
}
