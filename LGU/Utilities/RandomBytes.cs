using System.Security.Cryptography;

namespace LGU.Utilities
{
    public static class RandomBytes
    {
        public static byte[] Get()
        {
            byte[] bytes = new byte[SaltLength];
            RandomNumberGenerator.Create().GetBytes(bytes);
            return bytes;
        }

        public static int SaltLength
        {
            get { return 8; }
        }
    }
}
