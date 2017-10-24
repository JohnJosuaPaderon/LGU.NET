using Prism.Interactivity.InteractionRequest;

namespace LGU.Interactivity
{
    public class CustomNotification : Notification, ICustomNotification
    {
        public CustomNotification()
        {
            Title = string.Empty;
        }
    }
}
