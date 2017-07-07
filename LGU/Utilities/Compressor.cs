using System.IO;
using System.IO.Compression;

namespace LGU.Utilities
{
    public static class Compressor
    {
        public static byte[] Compress(byte[] data)
        {
            var output = new MemoryStream();

            using (var deflateStream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                deflateStream.Write(data, 0, data.Length);
            }

            return output.ToArray();
        }

        public static byte[] Decompress(byte[] data)
        {
            var input = new MemoryStream(data);
            var output = new MemoryStream();

            using (var deflateStream = new DeflateStream(input, CompressionMode.Decompress))
            {
                deflateStream.CopyTo(output);
            }

            return output.ToArray();
        }
    }
}
