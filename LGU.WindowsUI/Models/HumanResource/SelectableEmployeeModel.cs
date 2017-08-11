using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class SelectableEmployeeModel : EmployeeModel
    {
        public SelectableEmployeeModel(Employee source) : base(source)
        {
        }

        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetProperty(ref _IsSelected, value); }
        }
    }
}
