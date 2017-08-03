namespace LGU.Configurations
{
    public interface IConfigurationSource
    {
        ApplicationSettingCollection ApplicationSettings { get; }
    }
}
