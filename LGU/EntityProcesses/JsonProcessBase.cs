using LGU.Configurations;
using Newtonsoft.Json.Linq;

namespace LGU.EntityProcesses
{
    public abstract class JsonProcessBase
    {
        public JsonProcessBase(IJConfigurationHeader header)
        {
            Header = header;
        }

        protected const string KEY_HEADER = "header";
        protected const string KEY_BODY = "body";

        protected IJConfigurationHeader Header { get; private set; }
        protected JObject Body { get; private set; }
        protected JObject Source { get; private set; }

        protected void Load(string json)
        {
            Source = JObject.Parse(json);
            GetContents();
        }

        protected string Construct(JObject body)
        {
            var jObject = new JObject
            {
                { KEY_HEADER, Header.ToJson() },
                { KEY_BODY, body }
            };

            return jObject.ToString();
        }

        private void GetContents()
        {
            if (Source != null)
            {
                GetHeader();
                GetBody();
            }
        }

        private void GetHeader()
        {
            Header = new JConfigurationHeader(Source[KEY_HEADER] as JObject);
        }

        private void GetBody()
        {
            Body = Source[KEY_BODY] as JObject;
        }
    }
}
