using System.Text;

namespace LGU.Utilities
{
    public static class InformalFullNameConstructor
    {
        public static string Construct(string firstName, string middleInitials, string lastName, string nameExtension)
        {
            var hasFirstName = HasValue(firstName);
            var hasMiddleInitials = HasValue(middleInitials);
            var hasLastName = HasValue(lastName);
            var hasNameSuffix = HasValue(nameExtension);

            if (hasLastName || hasFirstName || hasMiddleInitials || hasNameSuffix)
            {
                var builder = new StringBuilder();

                if (hasFirstName)
                {
                    builder.Append(firstName.Trim());

                    if (hasMiddleInitials || hasLastName || hasNameSuffix)
                    {
                        builder.Append(" ");
                    }
                }

                if (hasMiddleInitials)
                {
                    builder.Append(middleInitials.Trim());

                    if (hasLastName || hasNameSuffix)
                    {
                        builder.Append(" ");
                    }
                }

                if (hasLastName)
                {
                    builder.Append(lastName.Trim());

                    if (hasNameSuffix)
                    {
                        builder.Append(" ");
                    }
                }

                if (hasNameSuffix)
                {
                    builder.Append(nameExtension.Trim());
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
