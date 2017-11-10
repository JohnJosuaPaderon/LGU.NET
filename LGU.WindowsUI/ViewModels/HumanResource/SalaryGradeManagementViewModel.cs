using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public class SalaryGradeManagementViewModel : ViewModelBase, INavigationAware
    {
        public SalaryGradeManagementViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_SalaryGradeBatchManager = ApplicationDomain.GetService<ISalaryGradeBatchManager>();
            r_SalaryGradeManager = ApplicationDomain.GetService<ISalaryGradeManager>();
            r_SalaryGradeStepManager = ApplicationDomain.GetService<ISalaryGradeStepManager>();

            ChangePageCommand = new DelegateCommand<object>(ChangePage);
            NavigateCommand = new DelegateCommand<string>(Navigate);
            GetCurrentCommand = new DelegateCommand(GetCurrent);
            SalaryGrades = new ObservableCollection<SalaryGradeModel>();

            _HeaderEvent.Publish("Salary Grades");
        }

        private readonly ISalaryGradeBatchManager r_SalaryGradeBatchManager;
        private readonly ISalaryGradeManager r_SalaryGradeManager;
        private readonly ISalaryGradeStepManager r_SalaryGradeStepManager;

        public DelegateCommand<object> ChangePageCommand { get; }
        public DelegateCommand GetCurrentCommand { get; }
        public DelegateCommand<string> NavigateCommand { get; }

        public ObservableCollection<SalaryGradeModel> SalaryGrades { get; }

        private SalaryGradeBatchModel _Batch;
        public SalaryGradeBatchModel Batch
        {
            get { return _Batch; }
            set { SetProperty(ref _Batch, value); }
        }

        private int _SelectedCreatePage;
        public int SelectedCreatePage
        {
            get { return _SelectedCreatePage; }
            set { SetProperty(ref _SelectedCreatePage, value); }
        }

        private void ChangePage(object pageIndex)
        {
            SelectedCreatePage = Convert.ToInt32(pageIndex);
        }

        protected override void Initialize()
        {
            ChangePage(0);
            GetCurrent();
        }

        private async void GetCurrent()
        {
            SalaryGrades.Clear();

            var batchResult = await r_SalaryGradeBatchManager.GetCurrentAsync();

            if (batchResult.Status == ProcessResultStatus.Success)
            {
                Batch = new SalaryGradeBatchModel(batchResult.Data);
                var salaryGradeResult = await r_SalaryGradeManager.GetListByBatchAsync(batchResult.Data);

                if (salaryGradeResult.Status == ProcessResultStatus.Success)
                {
                    if (salaryGradeResult.DataList != null && salaryGradeResult.DataList.Any())
                    {
                        foreach (ISalaryGrade salaryGrade in salaryGradeResult.DataList)
                        {
                            var salaryGradeModel = SalaryGradeModel.TryCreate(salaryGrade);
                            var steps = new List<SalaryGradeStepModel>();
                            var stepResult = await r_SalaryGradeStepManager.GetListBySalaryGradeAsync(salaryGrade);

                            if (stepResult.Status == ProcessResultStatus.Success)
                            {
                                if (stepResult.DataList != null && stepResult.DataList.Any())
                                {
                                    foreach (ISalaryGradeStep step in stepResult.DataList)
                                    {
                                        salaryGradeModel.Steps.Add(SalaryGradeStepModel.TryCreate(step, null));
                                    }
                                }
                            }
                            else
                            {
                                EnqueueMessage(stepResult.Message);
                                return;
                            }

                            SalaryGrades.Add(salaryGradeModel);
                        }
                    }
                }
                else
                {
                    EnqueueMessage(salaryGradeResult.Message);
                    return;
                }
            }
            else
            {
                EnqueueMessage(batchResult.Message);
            }
        }

        private void Navigate(string view)
        {
            _RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, view);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _HeaderEvent.Publish("Salary Grades");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
