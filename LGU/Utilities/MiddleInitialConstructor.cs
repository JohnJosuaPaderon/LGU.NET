using System.Text;

namespace LGU.Utilities
{
    public static class MiddleInitialConstructor
    {
        public static string Construct(string middleName)
        {
            var hasMiddleName = HasValue(middleName);

            if (hasMiddleName)
            {
                var builder = new StringBuilder();

                var splittedMiddleName = middleName.Split(' ');

                foreach (var item in splittedMiddleName)
                {
                    AppendChar(builder, item);
                }

                if (builder.Length > 0)
                {
                    builder.Append('.');
                }
                
                return builder.ToString();
            }
            else
            {
                return null;
            }
        }

        private static bool HasValue(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg);
        }

        private static void AppendChar(StringBuilder builder, string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                var c = item[0];
                if (char.IsLetter(c))
                {
                    builder.Append(c);
                }
            }
        }
    }
}
