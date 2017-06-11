using LGU.Core.EntityManagers;
using LGU.Entities;
using System;

namespace LGU.Core.Entities
{
    /// <summary>
    /// Represents an entity that has a name, gender and birth date
    /// </summary>
    public class Person : Entity<ulong>
    {
        private static IPersonNameManager _NameManager;

        public static IPersonNameManager NameManager
        {
            get
            {
                if (_NameManager == null)
                {
                    throw LGUException.NullReference($"{nameof(NameManager)} is not initialized.");
                }

                return _NameManager;
            }
            set
            {
                _NameManager = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="FirstName"/>
        /// </summary>
        private string _FirstName;

        /// <summary>
        /// Backing field for <see cref="MiddleName"/>
        /// </summary>
        private string _MiddleName;

        /// <summary>
        /// Backing field for <see cref="LastName"/>
        /// </summary>
        private string _LastName;

        /// <summary>
        /// Backing field for <see cref="NameSuffix"/>
        /// </summary>
        private string _NameSuffix;
        
        /// <summary>
        /// Backing field for <see cref="FullName"/>
        /// </summary>
        private string _FullName;

        /// <summary>
        /// Backing field for <see cref="InformalFullName"/>
        /// </summary>
        private string _InformalFullName;

        /// <summary>
        /// Backing field for <see cref="MiddleInitials"/>
        /// </summary>
        private string _MiddleInitials;

        /// <summary>
        /// Backing field for <see cref="Gender"/>
        /// </summary>
        private Gender _Gender;

        private DateTime? _BirthDate;

        /// <summary>
        /// Determines whether the <see cref="FullName"/> should be reconstructed
        /// </summary>
        private bool FullNameRefreshRequired;

        /// <summary>
        /// Determines whether the <see cref="InformalFullName"/> should be reconstructed
        /// </summary>
        private bool InformalFullNameRefreshRequired;

        /// <summary>
        /// Determines whether the <see cref="MiddleInitials"/> should be reconstructed
        /// </summary>
        private bool MiddleInitialsRefreshRequired;

        /// <summary>
        /// Gets or sets the first name of person
        /// </summary>
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                    _FirstName = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the middle name of person
        /// </summary>
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (_MiddleName != value)
                {
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                    MiddleInitialsRefreshRequired = true;
                    _MiddleName = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the last name of person
        /// </summary>
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                    _LastName = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the name suffix or name extension of person
        /// </summary>
        public string NameSuffix
        {
            get { return _NameSuffix; }
            set
            {
                if (_NameSuffix != value)
                {
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                    _NameSuffix = value;
                }
            }
        }

        /// <summary>
        /// Gets the full name of the person
        /// </summary>
        public string FullName
        {
            get
            {
                if (FullNameRefreshRequired)
                {
                    _FullName = NameManager.ConstructFullName(this);
                    FullNameRefreshRequired = false;
                }

                return _FullName;
            }
        }

        /// <summary>
        /// Gets the informal version of person's full name
        /// </summary>
        public string InformalFullName
        {
            get
            {
                if (InformalFullNameRefreshRequired)
                {
                    _InformalFullName = NameManager.ConstructInformalFullName(this);
                    InformalFullNameRefreshRequired = false;
                }

                return _InformalFullName;
            }
        }

        /// <summary>
        /// Gets the middle name initials of the person
        /// </summary>
        public string MiddleInitials
        {
            get
            {
                if (MiddleInitialsRefreshRequired)
                {
                    _MiddleInitials = NameManager.ConstructMiddleIntials(this);
                    MiddleInitialsRefreshRequired = false;
                }

                return _MiddleInitials;
            }
        }

        public Gender Gender
        {
            get { return _Gender; }
            set
            {
                if (_Gender != value)
                {
                    _Gender = value;
                }
            }
        }

        public DateTime? BirthDate
        {
            get { return _BirthDate; }
            set
            {
                if (_BirthDate != value)
                {
                    _BirthDate = value;
                }
            }
        }

        /// <summary>
        /// Returns a string that represents the current object; This returns <see cref="InformalFullName"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return InformalFullName.ToString();
        }
    }
}
