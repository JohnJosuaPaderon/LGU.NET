using System.Collections.Generic;

namespace LGU.Processes
{
    public class EnumerableConverterProperty<T> : IEnumerableConverterProperty<T>
    {
        private IEnumerable<T> _Values;

        public bool UseProvidedValues { get; set; }

        public IEnumerable<T> Values
        {
            get { return _Values; }
            set
            {
                UseProvidedValues = true;
                _Values = value;
            }
        }

        public IEnumerable<T> TryGetValues(IEnumerable<T> alternativeValues)
        {
            return UseProvidedValues ? Values : alternativeValues;
        }
    }
}
