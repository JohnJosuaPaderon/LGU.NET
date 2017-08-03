using Newtonsoft.Json.Linq;

namespace LGU.Configurations
{
    public interface IConfigurationSourceManager
    {
        IConfigurationSource LoadFromFile(string sourceFile);
        void SaveToFile(IConfigurationSource configurationSource, string sourceFile);
        IConfigurationSource LoadFromJson(JObject jConfiguration);
    }
}
