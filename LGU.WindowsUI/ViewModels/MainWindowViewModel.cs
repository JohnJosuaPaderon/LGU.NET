﻿using LGU.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace LGU.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public static string MainContentRegionName { get; } = "MainContentRegion";
        public static string MainDialogName { get; } = "MainDialog";
        public static string InitialMainContentRegionSource { get; set; }
        private readonly IRegionManager RegionManager;
        private readonly IEventAggregator EventAggregator;

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            EventAggregator = eventAggregator;
        }

        private string _Title = "Welcome to LGU.NET";
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private WindowState _WindowState = WindowState.Maximized;
        public WindowState WindowState
        {
            get { return _WindowState; }
            set { SetProperty(ref _WindowState, value); }
        }

        public void Load()
        {
            EventAggregator.GetEvent<TitleEvent>().Subscribe(t => Title = t);
            EventAggregator.GetEvent<WindowStateEvent>().Subscribe(ws => WindowState = ws);

            if (!string.IsNullOrWhiteSpace(InitialMainContentRegionSource))
            {
                RegionManager.RequestNavigate(MainContentRegionName, InitialMainContentRegionSource);
            }
        }
    }
}