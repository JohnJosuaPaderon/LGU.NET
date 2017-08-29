using LGU.Entities.Core;
using LGU.Utilities;

namespace LGU.Extensions
{
    public static class UserExtension
    {
        public static void AddFingerPrint(this DPFP.ID.User instance, IFingerPrint fingerPrint)
        {
            if (fingerPrint.Data != null)
            {
                instance.AddTemplate(fingerPrint.Data, FingerPositionConverter.FromFingerPrint(fingerPrint));
            }
        }
    }
}
