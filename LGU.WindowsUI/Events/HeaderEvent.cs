using Prism.Events;

namespace LGU.Events
{
    public sealed class HeaderEvent : PubSubEvent<string>
    {
        public void Change(string header)
        {
            if (!string.IsNullOrWhiteSpace(header))
            {
                Publish(header);
            }
        }
    }
}
