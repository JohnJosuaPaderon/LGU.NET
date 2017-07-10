using LGU.Entities.Core;
using System.Text;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    internal sealed class ConstructPersonMiddleInitials : IConstructPersonMiddleInitials
    {
        public Person Person { get; set; }

        public IDataProcessResult<string> Execute()
        {
            string data = null;
            ProcessResultStatus status = ProcessResultStatus.Undefined;
            string message = null;

            if (Validate(Person, ref status, ref message))
            {
                data = Construct(Person, ref status, ref message);
            }

            Person = null;
            return new DataProcessResult<string>(data, status, message);
        }

        public Task<IDataProcessResult<string>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<string>> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private static bool Validate(Person person, ref ProcessResultStatus status, ref string message)
        {
            var returnValue = true;

            if (person == null)
            {
                status = ProcessResultStatus.Failed;
                message = $"{nameof(Person)} is null.";
                returnValue = false;
            }

            return returnValue;
        }

        private static string Construct(Person person, ref ProcessResultStatus status, ref string message)
        {
            var hasMiddleName = HasValue(person.MiddleName);

            if (hasMiddleName)
            {
                var builder = new StringBuilder();

                var splittedMiddleName = person.MiddleName.Split(' ');

                foreach (var item in splittedMiddleName)
                {
                    AppendChar(builder, item);
                }

                status = ProcessResultStatus.Success;
                return builder.ToString();
            }
            else
            {
                status = ProcessResultStatus.Failed;
                message = "Middle initials cannot be constructed.";
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
                var c = char.IsLetter(item[0]);
                builder.Append(c);
            }
        }
    }
}
