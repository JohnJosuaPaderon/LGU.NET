using Prism.Events;

namespace LGU.Events
{
    public sealed class BusyAppEvent : PubSubEvent<bool>
    {
        public void Busy()
        {
            Publish(true);
        }

        public void Unbusy()
        {
            Publish(false);
        }
    }
}
