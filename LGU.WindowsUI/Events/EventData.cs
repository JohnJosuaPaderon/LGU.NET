namespace LGU.Events
{
    public class EventData<TPayload>
    {
        public TPayload Payload { get; set; }
        public string TargetViewModel { get; set; }
    }
}
