﻿using LGU.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Diagnostics;
using System.Windows;

namespace LGU.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        protected readonly IRegionManager r_RegionManager;
        protected readonly IEventAggregator r_EventAggregator;
        protected readonly NewMessageEvent r_NewMessageEvent;

        public ViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            r_RegionManager = regionManager;
            r_EventAggregator = eventAggregator;
            r_NewMessageEvent = r_EventAggregator.GetEvent<NewMessageEvent>();
        }

        public virtual void Initialize()
        {
            Debug.WriteLine("ViewModel has been Loaded.");
        }

        protected void ShowInfoMessage(string message, string header)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected virtual void ShowInfoMessage(string message)
        {
            ShowInfoMessage(message, "LGU.NET");
        }

        protected void ShowWarningMessage(string message, string header)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        protected virtual void ShowWarningMessage(string message)
        {
            ShowWarningMessage(message, "LGU.NET");
        }

        protected void ShowErrorMessage(string message, string header)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected virtual void ShowErrorMessage(string message)
        {
            ShowErrorMessage(message, "LGU.NET");
        }
    }
}
