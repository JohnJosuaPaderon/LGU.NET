using LGU.Entities.HumanResource;
using LGU.Models.Core;

namespace LGU.Models.HumanResource
{
    public sealed class DepartmentHeadModel : PersonModelBase<IDepartmentHead>
    {
        public DepartmentHeadModel(IDepartmentHead source) : base(source)
        {

        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        public override IDepartmentHead GetSource()
        {
            if (Source != null)
            {
                Source.Title = Title;
            }

            return base.GetSource();
        }
    }
}
