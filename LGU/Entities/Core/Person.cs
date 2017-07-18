using LGU.EntityManagers.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System;

namespace LGU.Entities.Core
{
    public class Person : Entity<long>
    {
        static Person()
        {
            NameManager = new PersonNameManager(
                new ConstructPersonFullName(),
                new ConstructPersonInformalFullName(),
                new ConstructPersonMiddleInitials());
        }

        public static IPersonNameManager NameManager { get; set; }

        private string _FirstName;
        private string _MiddleName;
        private string _MiddleInitials;
        private string _LastName;
        private string _NameExtension;
        private string _FullName;
        private string _InformalFullName;

        private bool MiddleInitialsRefreshRequired;
        private bool FullNameRefreshRequired;
        private bool InformalFullNameRefreshRequired;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                }
            }
        }

        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                    MiddleInitialsRefreshRequired = true;
                }
            }
        }

        public string MiddleInitials
        {
            get
            {
                if (MiddleInitialsRefreshRequired)
                {
                    var process = NameManager.ConstructMiddleInitials(this);

                    if (process.Status == ProcessResultStatus.Success)
                    {
                        _MiddleInitials = process.Data;
                        MiddleInitialsRefreshRequired = false;
                    }
                }

                return _MiddleInitials;
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                }
            }
        }

        public string NameExtension
        {
            get { return _NameExtension; }
            set
            {
                if (_NameExtension != value)
                {
                    _NameExtension = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                }
            }
        }

        public string FullName
        {
            get
            {
                if (FullNameRefreshRequired)
                {
                    var process = NameManager.ConstructFullName(this);

                    if (process.Status == ProcessResultStatus.Success)
                    {
                        _FullName = process.Data;
                        FullNameRefreshRequired = false;
                    }
                }

                return _FullName;
            }
        }

        public string InformalFullName
        {
            get
            {
                if (InformalFullNameRefreshRequired)
                {
                    var process = NameManager.ConstructInformalFullName(this);

                    if (process.Status == ProcessResultStatus.Success)
                    {
                        _InformalFullName = process.Data;
                        InformalFullNameRefreshRequired = false;
                    }
                }

                return _InformalFullName;
            }
        }

        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool Deceased { get; set; }

        public override string ToString()
        {
            return InformalFullName;
        }
    }
}
