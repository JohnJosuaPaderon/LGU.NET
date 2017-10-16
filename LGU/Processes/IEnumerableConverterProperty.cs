using System.Collections.Generic;

namespace LGU.Processes
{
    public interface IEnumerableConverterProperty<T>
    {
        bool UseProvidedValues { get; set; }
        IEnumerable<T> Values { get; set; }
        IEnumerable<T> TryGetValues(IEnumerable<T> alternativeValues);
    }
}
