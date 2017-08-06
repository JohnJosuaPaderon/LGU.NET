using System.Text;

namespace LGU.Utilities
{
    public static class FullNameConstructor
    {
        public static string Construct(string firstName, string middleName, string lastName, string nameExtension)
        {
            var hasLastName = HasValue(lastName);
            var hasFirstName = HasValue(firstName);
            var hasMiddleName = HasValue(middleName);
            var hasNameSuffix = HasValue(nameExtension);

            if (hasLastName || hasFirstName || hasMiddleName || hasNameSuffix)
            {
                var builder = new StringBuilder();

                if (hasLastName)
                {
                    builder.Append(lastName.Trim());

                    if (hasNameSuffix)
                    {
                        builder.Append(" ");
                    }
                    else if (hasFirstName || hasMiddleName)
                    {
                        builder.Append(", ");
                    }
                }

                if (hasNameSuffix)
                {
                    builder.Append(nameExtension.Trim());

                    if (hasFirstName || hasMiddleName)
                    {
                        builder.Append(", ");
                    }
                }

                if (hasFirstName)
                {
                    builder.Append(firstName.Trim());

                    if (hasMiddleName)
                    {
                        builder.Append(" ");
                    }
                }

                if (hasMiddleName)
                {
                    builder.Append(middleName.Trim());
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
    }
}
