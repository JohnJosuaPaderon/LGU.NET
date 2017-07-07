﻿using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class PreviewDepartmentViewModel : ViewModelBase
	{
        public PreviewDepartmentViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {

        }

        public override void Load()
        {
            base.Load();
            EventAggregator.GetEvent<DepartmentEvent>().Subscribe(d => Department = d);
        }

        private DepartmentModel _Department;
        public DepartmentModel Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
        }
    }
}
