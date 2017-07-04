using System;

namespace LGU.Entities.Core
{
    [Flags]
    public enum FingerType
    {
        Thumb = 0,
        IndexFinger = 1,
        MiddleFinger = 2,
        RingFinger = 4,
        LittleFinger = 8
    }
}
