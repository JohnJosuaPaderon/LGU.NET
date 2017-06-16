using LGU.HumanResource.ViewModels;
using System.Windows.Controls;

namespace LGU.HumanResource.Views
{
    /// <summary>
    /// Interaction logic for HumanResourceLauncherView
    /// </summary>
    public partial class HumanResourceLauncherView : UserControl
    {
        public HumanResourceLauncherView()
        {
            InitializeComponent();
            Loaded += (s, e) => ViewModel.Initialize();
        }

        public HumanResourceLauncherViewModel ViewModel => DataContext as HumanResourceLauncherViewModel;
    }
}
