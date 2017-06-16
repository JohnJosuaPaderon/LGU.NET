using LGU.Utilities;
using Newtonsoft.Json.Linq;

namespace LGU
{
    public static class DevelopmentOptions
    {
        private static JObject Source { get; set; }

        public static void Initialize(JObject source)
        {
            source = new JObject
            {
                { nameof(ByPassUserAuthentication), true }
            };

            Source = source ?? throw LGUException.ArgumentNull(nameof(source), "Source of Development Options is null.");
        }

        private static bool? _ByPassUserAuthentication;

        public static bool ByPassUserAuthentication
        {
            get
            {
                if (_ByPassUserAuthentication is null)
                {
                    _ByPassUserAuthentication = ValueConverter.ToNullableBoolean(Source[nameof(ByPassUserAuthentication)]);
                }

                return _ByPassUserAuthentication ?? false;
            }
        }
    }
}
