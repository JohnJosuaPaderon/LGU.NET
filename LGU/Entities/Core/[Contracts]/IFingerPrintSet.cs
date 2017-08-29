namespace LGU.Entities.Core
{
    public interface IFingerPrintSet
    {
        IFingerPrint LeftThumb { get; }
        IFingerPrint LeftIndexFinger { get; }
        IFingerPrint LeftMiddleFinger { get; }
        IFingerPrint LeftRingFinger { get; }
        IFingerPrint LeftLittleFinger { get; }
        IFingerPrint RightThumb { get; }
        IFingerPrint RightIndexFinger { get; }
        IFingerPrint RightMiddleFinger { get; }
        IFingerPrint RightRingFinger { get; }
        IFingerPrint RightLittleFinger { get; }
    }
}
