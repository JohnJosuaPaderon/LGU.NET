using LGU.Core.Entities;
using System;
using System.Text;

namespace LGU.Core.EntityProcesses
{
    public sealed class ConstructPersonInformalFullName : IProcess<string>
    {
        public ConstructPersonInformalFullName(Person person)
        {
            Person = person ?? throw new ArgumentNullException(nameof(person));
        }

        private Person Person;
        private StringBuilder InformalFullNameBuilder;
        private bool HasFirstName;
        private bool HasMiddleInitials;
        private bool HasLastName;
        private bool HasNameSuffix;

        public void Dispose()
        {
            Person = null;

            if (InformalFullNameBuilder != null)
            {
                InformalFullNameBuilder = null;
            }
        }

        public string Execute()
        {
            SetCheckers();

            if (HasLastName || HasFirstName || HasMiddleInitials || HasNameSuffix)
            {
                InformalFullNameBuilder = new StringBuilder();

                AppendFirstName();
                AppendMiddleInitials();
                AppendLastName();
                AppendNameSuffix();

                return InformalFullNameBuilder.ToString();
            }
            else
            {
                return null;
            }
        }

        private void SetCheckers()
        {
            HasFirstName = !string.IsNullOrWhiteSpace(Person.FirstName);
            HasMiddleInitials = !string.IsNullOrWhiteSpace(Person.MiddleInitials);
            HasLastName = !string.IsNullOrWhiteSpace(Person.LastName);
            HasNameSuffix = !string.IsNullOrWhiteSpace(Person.NameSuffix);
        }

        private void AppendFirstName()
        {
            if (HasFirstName)
            {
                InformalFullNameBuilder.Append(Person.FirstName.Trim());

                if (HasMiddleInitials || HasLastName || HasNameSuffix)
                {
                    InformalFullNameBuilder.Append(" ");
                }
            }
        }

        private void AppendMiddleInitials()
        {
            if (HasMiddleInitials)
            {
                InformalFullNameBuilder.Append(Person.MiddleInitials);

                if (HasLastName || HasNameSuffix)
                {
                    InformalFullNameBuilder.Append(" ");
                }
            }
        }

        private void AppendLastName()
        {
            if (HasLastName)
            {
                InformalFullNameBuilder.Append(Person.LastName.Trim());

                if (HasNameSuffix)
                {
                    InformalFullNameBuilder.Append(" ");
                }
            }
        }

        private void AppendNameSuffix()
        {
            if (HasNameSuffix)
            {
                InformalFullNameBuilder.Append(Person.NameSuffix.Trim());
            }
        }
    }
}
