using LGU.Core.Entities;
using System;
using System.Text;

namespace LGU.Core.EntityProcesses
{
    public sealed class ConstructPersonFullName : IProcess<string>
    {
        public ConstructPersonFullName(Person person)
        {
            Person = person ?? throw new ArgumentNullException(nameof(person));
        }

        private Person Person;
        private StringBuilder FullNameBuilder;
        private bool HasLastName;
        private bool HasNameSuffix;
        private bool HasFirstName;
        private bool HasMiddleName;

        public void Dispose()
        {
            Person = null;
            
            if (FullNameBuilder != null)
            {
                FullNameBuilder = null;
            }
        }

        public string Execute()
        {
            SetCheckers();

            if (HasLastName || HasFirstName || HasMiddleName || HasNameSuffix)
            {
                FullNameBuilder = new StringBuilder();

                AppendLastName();
                AppendNameSuffix();
                AppendFirstName();
                AppendMiddleName();

                return FullNameBuilder.ToString();
            }
            else
            {
                return null;
            }
        }

        private void SetCheckers()
        {
            HasLastName = !string.IsNullOrWhiteSpace(Person.LastName);
            HasNameSuffix = !string.IsNullOrWhiteSpace(Person.NameSuffix);
            HasFirstName = !string.IsNullOrWhiteSpace(Person.FirstName);
            HasMiddleName = !string.IsNullOrWhiteSpace(Person.MiddleName);
        }

        private void AppendMiddleName()
        {
            if (HasMiddleName)
            {
                FullNameBuilder.Append(Person.MiddleName);
            }
        }

        private void AppendFirstName()
        {
            if (HasFirstName)
            {
                FullNameBuilder.Append(Person.FirstName.Trim());

                if (HasMiddleName)
                {
                    FullNameBuilder.Append(" ");
                }
            }
        }

        private void AppendNameSuffix()
        {
            if (HasNameSuffix)
            {
                FullNameBuilder.Append(Person.NameSuffix.Trim());

                if (HasFirstName || HasMiddleName)
                {
                    FullNameBuilder.Append(", ");
                }
            }
        }

        private void AppendLastName()
        {
            if (HasLastName)
            {
                FullNameBuilder.Append(Person.LastName.Trim());

                if (HasNameSuffix)
                {
                    FullNameBuilder.Append(" ");
                }
                else if (HasFirstName || HasMiddleName)
                {
                    FullNameBuilder.Append(", ");
                }
            }
        }
    }
}
