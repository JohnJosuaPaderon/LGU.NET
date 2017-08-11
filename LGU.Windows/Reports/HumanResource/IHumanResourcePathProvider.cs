namespace LGU.Reports.HumanResource
{
    public interface IHumanResourcePathProvider
    {
        string LocatorTemplate { get; }
        string LocatorSaveDirectory { get; }
    }
}
