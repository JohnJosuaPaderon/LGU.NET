using System;

namespace LGU
{
    partial class LGUException
    {
        public static LGUException ArgumentNullException(string parameterName, string lguExceptionMessage)
        {
            return new LGUException(lguExceptionMessage, new ArgumentNullException(parameterName));
        }
    }
}
