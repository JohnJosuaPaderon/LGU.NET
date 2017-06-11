using LGU.Core.Entities;
using System.Text;

namespace LGU.Core.EntityProcesses
{
    public sealed class ConstructPersonMiddleInitials : IConstructPersonMiddleInitials
    {
        public ConstructPersonMiddleInitials(Person person, PersonOptions options)
        {
            Person = person ?? throw LGUException.ArgumentNullException(nameof(person), "Invalid person.");
            Options = options ?? throw LGUException.ArgumentNullException(nameof(options), "Invalid options.");
        }

        public Person Person { get; private set; }
        private PersonOptions Options;
        private StringBuilder MiddleInitialsBuilder;
        private bool HasMiddleName;

        public void Dispose()
        {
            Person = null;
            Options = null;

            if (MiddleInitialsBuilder != null)
            {
                MiddleInitialsBuilder = null;
            }
        }

        public string Execute()
        {
            SetCheckers();

            if (HasMiddleName)
            {
                MiddleInitialsBuilder = new StringBuilder();

                var splittedMiddleName = SplitMiddleName();

                foreach (var middleNameChunk in splittedMiddleName)
                {
                    if (middleNameChunk.Length > 0)
                    {
                        AppendFirstChar(middleNameChunk[0]);
                    }
                }

                return MiddleInitialsBuilder.ToString();
            }
            else
            {
                return null;
            }
        }

        private string[] SplitMiddleName()
        {
            return Person.MiddleName.Trim().Split(Options.MiddleNameSeparator);
        }

        private void SetCheckers()
        {
            HasMiddleName = !string.IsNullOrWhiteSpace(Person.MiddleName);
        }

        private void AppendFirstChar(char value)
        {
            if (char.IsLetter(value))
            {
                MiddleInitialsBuilder.Append(value);
            }
        }
    }
}
