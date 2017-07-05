using LGU.ViewModels.HumanResource;
using System.Windows.Controls;

namespace LGU.Views.HumanResource
{
    /// <summary>
    /// Interaction logic for EmployeeFingerPrintEnrollmentView
    /// </summary>
    public partial class EmployeeFingerPrintEnrollmentView : UserControl
    {
        public EmployeeFingerPrintEnrollmentView()
        {
            InitializeComponent();
            Loaded += (s, e) => ViewModel.Load();
        }

        public EmployeeFingerPrintEnrollmentViewModel ViewModel => DataContext as EmployeeFingerPrintEnrollmentViewModel;
    }
}
