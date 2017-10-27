using Newtonsoft.Json.Linq;

namespace LGU.Configurations
{
    public interface IJConfigurationHeader
    {
        string Key { get; }
        JObject ToJson();
    }
}
