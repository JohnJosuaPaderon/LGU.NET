using System;

namespace LGU
{
    partial class LGUException
    {
        public static LGUException ArgumentNull(string parameterName, string lguExceptionMessage)
        {
            return new LGUException(lguExceptionMessage, new ArgumentNullException(parameterName), LGUExceptionLevel.High);
        }

        public static LGUException NullReference(string lguExceptionMessage)
        {
            return new LGUException(lguExceptionMessage, new NullReferenceException(), LGUExceptionLevel.Fatal);
        }

        public static LGUException ArgumentNullOrWhiteSpace(string parameterName, string lguExceptionMessage)
        {
            return new LGUException(lguExceptionMessage, new ArgumentException("Value cannot be null or white space."), LGUExceptionLevel.High);
        }
    }
}
