using System;
using System.Collections.Generic;

namespace LGU.Utilities
{
    public static class HexConverter
    {
        static HexConverter()
        {
            Source = new Dictionary<string, byte>();
            LoadSourceContent();
        }

        private static void LoadSourceContent()
        {
            for (byte i = 0; i < byte.MaxValue; i++)
            {
                Source.Add(BitConverter.ToString(new byte[] { i }), i);
            }
            Source.Add(BitConverter.ToString(new byte[] { 255 }), 255);
        }

        private static Dictionary<string, byte> Source { get; }

        public static byte FromString(string hexString)
        {
            if (string.IsNullOrWhiteSpace(hexString) || hexString.Length != 2)
            {
                return 0;
            }

            var upperHexString = hexString.ToUpper();

            if (Source.ContainsKey(upperHexString))
            {
                return Source[upperHexString];
            }
            else
            {
                return 0;
            }
        }
    }
}
