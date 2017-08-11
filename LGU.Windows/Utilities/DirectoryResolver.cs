using System.IO;

namespace LGU.Utilities
{
    public static class DirectoryResolver
    {
        public static void Resolve(string directory)
        {
            if (!string.IsNullOrWhiteSpace(directory))
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
        }
    }
}
