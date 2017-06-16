using System;

namespace LGU
{
    partial class LGUException
    {
        public static LGUException ArgumentNull(string parameterName, string lguExceptionMessage, LGUExceptionLevel level = LGUExceptionLevel.High)
        {
            return new LGUException(lguExceptionMessage, new ArgumentNullException(parameterName), level);
        }

        public static LGUException NullReference(string lguExceptionMessage, LGUExceptionLevel level = LGUExceptionLevel.Fatal)
        {
            return new LGUException(lguExceptionMessage, new NullReferenceException(), level);
        }

        public static LGUException ArgumentNullOrWhiteSpace(string parameterName, string lguExceptionMessage, LGUExceptionLevel level = LGUExceptionLevel.High)
        {
            return new LGUException(lguExceptionMessage, new ArgumentException("Value cannot be null or white space."), level);
        }
    }
}
