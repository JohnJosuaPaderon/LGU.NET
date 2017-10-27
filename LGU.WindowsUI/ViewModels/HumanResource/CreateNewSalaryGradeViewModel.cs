using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public sealed class CreateNewSalaryGradeViewModel : ViewModelBase, INavigationAware
    {
        public CreateNewSalaryGradeViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_SalaryGradeBatchManager = ApplicationDomain.GetService<ISalaryGradeBatchManager>();
            r_SalaryGradeManager = ApplicationDomain.GetService<ISalaryGradeManager>();
            r_SalaryGradeStepManager = ApplicationDomain.GetService<ISalaryGradeStepManager>();

            NavigateCommand = new DelegateCommand<string>(Navigate);
            SaveCommand = new DelegateCommand(Save);
            AddNewSalaryGradeCommand = new DelegateCommand(AddNewSalaryGrade);
            SalaryGrades = new ObservableCollection<SalaryGradeModel>();
        }

        private readonly ISalaryGradeBatchManager r_SalaryGradeBatchManager;
        private readonly ISalaryGradeManager r_SalaryGradeManager;
        private readonly ISalaryGradeStepManager r_SalaryGradeStepManager;

        public DelegateCommand<string> NavigateCommand { get; }
        public DelegateCommand AddNewSalaryGradeCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public ObservableCollection<SalaryGradeModel> SalaryGrades { get; }

        private SalaryGradeBatchModel _Batch;
        public SalaryGradeBatchModel Batch
        {
            get { return _Batch; }
            set { SetProperty(ref _Batch, value); }
        }

        protected override void Initialize()
        {
            Batch = new SalaryGradeBatchModel(new SalaryGradeBatch()
            {
                EffectivityDate = DateTime.Now
            });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _ChangeHeaderEvent.Publish("Create New Salary Grades");
        }

        private void Navigate(string view)
        {
            _RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, view);
        }

        private void AddNewSalaryGrade()
        {
            if (SalaryGrades.Any())
            {
                if (SalaryGrades.Count < SalaryGrade.MaxGrade)
                {
                    SalaryGrades.Add(new SalaryGradeModel(new SalaryGrade(Batch.GetSource(), SalaryGrades.Last().Number + 1)));
                }
                else
                {
                    EnqueueMessage("Salary grades reached its maximum count.");
                }
            }
            else
            {
                SalaryGrades.Add(new SalaryGradeModel(new SalaryGrade(Batch.GetSource(), 1)));
            }
        }

        private async void Save()
        {
            var batchResult = await r_SalaryGradeBatchManager.InsertAsync(Batch.GetSource());
            var failureMessage = "Failed to create salary grades. ";
            var faulted = false;

            if (batchResult.Status == ProcessResultStatus.Success)
            {
                foreach (var salaryGrade in SalaryGrades)
                {
                    if (faulted)
                    {
                        return;
                    }

                    salaryGrade.Batch = batchResult.Data;
                    var salaryGradeResult = await r_SalaryGradeManager.InsertAsync(salaryGrade.GetSource());

                    if (salaryGradeResult.Status == ProcessResultStatus.Success)
                    {
                        foreach (var step in salaryGrade.Steps)
                        {
                            if (faulted)
                            {
                                return;
                            }

                            step.SalaryGrade = salaryGradeResult.Data;
                            var stepResult = await r_SalaryGradeStepManager.InsertAsync(step.GetSource());

                            if (stepResult.Status == ProcessResultStatus.Failed)
                            {
                                EnqueueMessage($"{failureMessage}{stepResult.Message}");
                                faulted = true;
                            }
                        }
                    }
                    else
                    {
                        EnqueueMessage($"{failureMessage}{salaryGradeResult.Message}");
                        faulted = true;
                    }
                }

                Navigate(nameof(SalaryGradeManagementView));
                EnqueueMessage("Salary grades successfully created.");
                SalaryGrades.Clear();
                Batch = new SalaryGradeBatchModel(new SalaryGradeBatch() { EffectivityDate = DateTime.Now });
            }
            else
            {
                EnqueueMessage($"{failureMessage}{batchResult.Message}");
            }
        }
    }
}
