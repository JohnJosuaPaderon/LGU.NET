using LGU.Models.HumanResource;
using Prism.Mvvm;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class EmployeeSearchDialogContent : BindableBase
    {
        private const string DEFAULT_SEARCH_HINT = "Search...";

        public EmployeeSearchDialogContent()
        {
            SearchHint = DEFAULT_SEARCH_HINT;
        }

        public EmployeeSearchDialogContent(string searchHint)
        {
            SearchHint = searchHint;
        }

        private string _SearchHint;
        public string SearchHint
        {
            get { return _SearchHint; }
            set { SetProperty(ref _SearchHint, value); }
        }

        private string _InitialSearchKey;
        public string InitialSearchKey
        {
            get { return _InitialSearchKey; }
            set { SetProperty(ref _InitialSearchKey, value); }
        }

        private EmployeeModel _SelectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set { SetProperty(ref _SelectedEmployee, value); }
        }
    }
}
