namespace LGU.Processes
{
    public interface IDataConverterProperty<T>
    {
        bool UseProvidedValue { get; set; }
        T Value { get; set; }
        T TryGetValue(T alternativeValue);
    }
}
