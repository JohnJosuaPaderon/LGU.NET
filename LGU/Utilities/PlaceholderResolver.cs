using System;
using System.Text;

namespace LGU.Utilities
{
    public abstract class PlaceholderResolver
    {
        public PlaceholderResolver(string entityName)
        {
            if (string.IsNullOrWhiteSpace(entityName))
            {
                throw new ArgumentException("Entity name cannot be null or white space.", nameof(entityName));
            }

            EntityName = entityName;
        }

        protected string EntityName { get; }
        protected const string START_CHAR = "{";
        protected const string END_CHAR = "}";
        protected const string INDEXER_START_CHAR = "[";
        protected const string INDEXER_END_CHAR = "]";

        protected string GetPropertyName(string placeholder)
        {
            if (placeholder.StartsWith(START_CHAR) && placeholder.EndsWith(END_CHAR))
            {
                var builder = new StringBuilder(placeholder);

                builder.Replace(START_CHAR, string.Empty);
                builder.Replace(END_CHAR, string.Empty);
                builder.Replace(EntityName, string.Empty);
                builder.Replace(INDEXER_START_CHAR, string.Empty);
                builder.Replace(INDEXER_END_CHAR, string.Empty);

                return builder.ToString();
            }
            else
            {
                throw new FormatException($"The placeholder's format is invalid: {placeholder}");
            }
        }

    }
}
