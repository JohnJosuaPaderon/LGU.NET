using LGU.Extensions;
using Newtonsoft.Json.Linq;
using System;

namespace LGU.Configurations
{
    public class JConfigurationHeader : IJConfigurationHeader
    {
        private const string KEY = "key";

        public JConfigurationHeader(string key)
        {
            Key = key;

            _Source = new JObject();
            _Source.Add(KEY, Key);
        }

        public JConfigurationHeader(JObject source)
        {
            _Source = source ?? throw new ArgumentNullException(nameof(source));
            Initialize();
        }

        private readonly JObject _Source;

        public string Key { get; private set; }

        private void Initialize()
        {
            Key = _Source.GetString(KEY);
        }

        public JObject ToJson()
        {
            _Source[KEY] = Key;

            return _Source;
        }
    }
}
