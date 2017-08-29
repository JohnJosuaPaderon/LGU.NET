using DPFP;

namespace LGU.Entities.Core
{
    public interface IFingerPrint
    {
        FingerType FingerType { get; }
        HandType HandType { get; }
        byte[] RawData { get; set; }
        Template Data { get; set; }
    }
}
