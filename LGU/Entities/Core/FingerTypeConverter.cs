using System.Collections.Generic;

namespace LGU.Entities.Core
{
    public static class FingerTypeConverter
    {
        static FingerTypeConverter()
        {
            DisplaySource = new Dictionary<FingerType, string>
            {
                { FingerType.Thumb, "Thumb" },
                { FingerType.IndexFinger, "Index Finger" },
                { FingerType.MiddleFinger, "Middle Finger" },
                { FingerType.RingFinger, "Ring Finger" },
                { FingerType.LittleFinger, "Little Finger" }
            };
        }

        private static Dictionary<FingerType, string> DisplaySource { get; }

        public static string GetDisplay(FingerType value)
        {
            return DisplaySource[value];
        }
    }
}
