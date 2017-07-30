using DPFP.ID;
using LGU.Entities.Core;

namespace LGU.Utilities
{
    public static class FingerPositionConverter
    {
        public static FingerPosition FromFingerPrint(FingerPrint fingerPrint)
        {
            switch (fingerPrint.HandType)
            {
                case HandType.Left:
                    switch (fingerPrint.FingerType)
                    {
                        case FingerType.Thumb: return FingerPosition.LeftThumb;
                        case FingerType.IndexFinger: return FingerPosition.LeftIndex;
                        case FingerType.MiddleFinger: return FingerPosition.LeftMiddle;
                        case FingerType.RingFinger: return FingerPosition.LeftRing;
                        case FingerType.LittleFinger: return FingerPosition.LeftLittle;
                    }
                    break;
                case HandType.Right:
                    switch (fingerPrint.FingerType)
                    {
                        case FingerType.Thumb: return FingerPosition.RightThumb;
                        case FingerType.IndexFinger: return FingerPosition.RightIndex;
                        case FingerType.MiddleFinger: return FingerPosition.RightMiddle;
                        case FingerType.RingFinger: return FingerPosition.RightRing;
                        case FingerType.LittleFinger: return FingerPosition.RightLittle;
                    }
                    break;
            }

            return FingerPosition.LeftThumb;
        }
    }
}