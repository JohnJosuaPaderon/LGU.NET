using Prism.Events;
using System;

namespace LGU.Events
{
    public sealed class NewMessageEvent : PubSubEvent<string>
    {
        public void EnqueueMessage(string message)
        {
            Publish(message);
        }

        public void EnqueueErrorMessage(string message)
        {
            Publish($"Error: {message}");
        }

        public void EnqueueException(Exception exception)
        {
            Publish(ApplicationDomain.DebugMode ? $"Exception: {exception.Message}" : "An exception has been thrown.");
        }
    }
}
