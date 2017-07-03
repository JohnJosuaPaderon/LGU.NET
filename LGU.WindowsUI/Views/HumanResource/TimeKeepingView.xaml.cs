using LGU.ViewModels.HumanResource;
using System.Windows.Controls;

namespace LGU.Views.HumanResource
{
    /// <summary>
    /// Interaction logic for TimeKeepingView
    /// </summary>
    public partial class TimeKeepingView : UserControl
    {
        public TimeKeepingView()
        {
            InitializeComponent();
            Loaded += (s, e) => ViewModel.Load();
        }

        public TimeKeepingViewModel ViewModel => DataContext as TimeKeepingViewModel;
    }
}
