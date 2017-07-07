using Prism.Mvvm;

namespace LGU.Models
{
    public abstract class ModelBase<T> : BindableBase
    {
        public ModelBase(T source)
        {
            Source = source;
        }

        protected T Source { get; }

        public virtual T GetSource()
        {
            return Source;
        }
    }
}
