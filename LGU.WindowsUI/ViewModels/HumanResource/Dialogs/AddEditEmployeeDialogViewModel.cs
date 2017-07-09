using LGU.EntityManagers.HumanResource;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class AddEditEmployeeDialogViewModel : DialogViewModelBase
    {
        private readonly IEmployeeManager EmployeeManager;

        public AddEditEmployeeDialogViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            EmployeeManager = SystemRuntime.ServiceProvider.GetService<IEmployeeManager>();
        }
    }
}
