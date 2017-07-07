using LGU.EntityManagers.HumanResource;
using LGU.Models.HumanResource;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows;

namespace LGU.ViewModels.HumanResource
{
    public sealed class DepartmentManagementViewModel : ViewModelBase
    {
        private readonly IDepartmentManager DepartmentManager;

        public DepartmentManagementViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            RequestSearchCommand = new DelegateCommand(RequestSearch);
            DepartmentManager = ServiceProvider.Current.GetService<IDepartmentManager>();
        }

        public ObservableCollection<DepartmentModel> Departments { get; } = new ObservableCollection<DepartmentModel>();
        public DelegateCommand RequestSearchCommand { get; }

        private string _SearchKey;
        public string SearchKey
        {
            get { return _SearchKey; }
            set { SetProperty(ref _SearchKey, value); }
        }

        private async void RequestSearch()
        {
            var result = await DepartmentManager.SearchAsync(SearchKey);

            if (result.Status == ProcessResultStatus.Success && result.DataList != null)
            {
                Departments.Clear();

                foreach (var item in result.DataList)
                {
                    Departments.Add(new DepartmentModel(item));
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
    }
}
