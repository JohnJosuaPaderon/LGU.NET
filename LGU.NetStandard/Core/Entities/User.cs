using LGU.Entities;
using System;

namespace LGU.Core.Entities
{
    public class User : Entity<ulong>
    {
        public User()
        {
        }

        public User(Person person)
        {
            Person = person ?? throw new LGUException("Invalid Person.", new ArgumentNullException(nameof(person)));
        }

        private string _DisplayName;

        public Person Person { get; }
        public bool Active { get; set; }
        public UserStatus Status { get; set; }

        public string DisplayName
        {
            get { return Person?.InformalFullName ?? _DisplayName; }
            set
            {
                if (_DisplayName != value)
                {
                    _DisplayName = value;
                }
            }
        }
    }
}
