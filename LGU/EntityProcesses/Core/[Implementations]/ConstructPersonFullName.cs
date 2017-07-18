using LGU.Entities.Core;
using LGU.Processes;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    internal sealed class ConstructPersonFullName : IConstructPersonFullName
    {
        public Person Person { get; set; }

        public IProcessResult<string> Execute()
        {
            string data = null;
            ProcessResultStatus status = ProcessResultStatus.Undefined;
            string message = null;

            if (Validate(Person, ref status, ref message))
            {
                data = Construct(Person, ref status, ref message);
            }

            return new ProcessResult<string>(data, status, message);
        }

        public Task<IProcessResult<string>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<string>> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private static string Construct(Person person, ref ProcessResultStatus status, ref string message)
        {
            var hasLastName = HasValue(person.LastName);
            var hasFirstName = HasValue(person.FirstName);
            var hasMiddleName = HasValue(person.MiddleName);
            var hasNameSuffix = HasValue(person.NameExtension);

            if (hasLastName || hasFirstName || hasMiddleName || hasNameSuffix)
            {
                var builder = new StringBuilder();

                AppendLastName(person, hasLastName, hasFirstName, hasMiddleName, hasNameSuffix, builder);
                AppendNameSuffix(person, hasFirstName, hasMiddleName, hasNameSuffix, builder);
                AppendFirstName(person, hasFirstName, hasMiddleName, builder);
                AppendMiddleName(person, hasMiddleName, builder);

                status = ProcessResultStatus.Success;
                return builder.ToString();
            }
            else
            {
                status = ProcessResultStatus.Failed;
                message = "Full name cannot be constructed.";
                return null;
            }
        }

        private static void AppendMiddleName(Person person, bool hasMiddleName, StringBuilder builder)
        {
            if (hasMiddleName)
            {
                builder.Append(person.MiddleName.Trim());
            }
        }

        private static void AppendFirstName(Person person, bool hasFirstName, bool hasMiddleName, StringBuilder builder)
        {
            if (hasFirstName)
            {
                builder.Append(person.FirstName.Trim());

                if (hasMiddleName)
                {
                    builder.Append(" ");
                }
            }
        }

        private static void AppendNameSuffix(Person person, bool hasFirstName, bool hasMiddleName, bool hasNameSuffix, StringBuilder builder)
        {
            if (hasNameSuffix)
            {
                builder.Append(person.NameExtension.Trim());

                if (hasFirstName || hasMiddleName)
                {
                    builder.Append(", ");
                }
            }
        }

        private static void AppendLastName(Person person, bool hasLastName, bool hasFirstName, bool hasMiddleName, bool hasNameSuffix, StringBuilder builder)
        {
            if (hasLastName)
            {
                builder.Append(person.LastName.Trim());

                if (hasNameSuffix)
                {
                    builder.Append(" ");
                }
                else if (hasFirstName || hasMiddleName)
                {
                    builder.Append(", ");
                }
            }
        }

        private static bool HasValue(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg);
        }

        private static bool Validate(Person person, ref ProcessResultStatus status, ref string message)
        {
            var result = true;

            if (person == null)
            {
                status = ProcessResultStatus.Failed;
                message = $"{nameof(Person)} is null.";
            }

            return result;
        }
    }
}
