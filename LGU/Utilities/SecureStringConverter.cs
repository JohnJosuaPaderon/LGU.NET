using System;
using System.Runtime.InteropServices;
using System.Security;

namespace LGU.Utilities
{
    public static class SecureStringConverter
    {
        public static string Convert(SecureString value)
        {
            if (value != null)
            {
                IntPtr unmanagedString = IntPtr.Zero;
                try
                {
                    unmanagedString = SecureStringMarshal.SecureStringToGlobalAllocUnicode(value);
                    return Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }
            else
            {
                return null;
            }
        }

        public static SecureString Convert(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                unsafe
                {
                    fixed (char* passwordChars = value)
                    {
                        var securePassword = new SecureString(passwordChars, value.Length);
                        securePassword.MakeReadOnly();
                        return securePassword;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
