using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using System;

namespace LGU.Models.HumanResource
{
    public sealed class PersonalDataSheetModel : ModelBase<IPersonalDataSheet>
    {
        public PersonalDataSheetModel(IPersonalDataSheet source) : base(source)
        {
        }

        private Employee _Employee;
        public Employee Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { SetProperty(ref _FirstName, value); }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set { SetProperty(ref _MiddleName, value); }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { SetProperty(ref _LastName, value); }
        }

        private string _NameExtension;
        public string NameExtension
        {
            get { return _NameExtension; }
            set { SetProperty(ref _NameExtension, value); }
        }

        private DateTime _BirthDate;
        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set { SetProperty(ref _BirthDate, value); }
        }

        private string _BirthPlace;
        public string BirthPlace
        {
            get { return _BirthPlace; }
            set { SetProperty(ref _BirthPlace, value); }
        }

        private ICitizenship _Citizenship;
        public ICitizenship Citizenship
        {
            get { return _Citizenship; }
            set { SetProperty(ref _Citizenship, value); }
        }

        private IGender _Gender;
        public IGender Gender
        {
            get { return _Gender; }
            set { SetProperty(ref _Gender, value); }
        }

        private ICountry _DualCitizenshipCountry;
        public ICountry DualCitizenshipCountry
        {
            get { return _DualCitizenshipCountry; }
            set { SetProperty(ref _DualCitizenshipCountry, value); }
        }

        private ICivilStatus _CivilStatus;
        public ICivilStatus CivilStatus
        {
            get { return _CivilStatus; }
            set { SetProperty(ref _CivilStatus, value); }
        }

        private float _Height;
        public float Height
        {
            get { return _Height; }
            set { SetProperty(ref _Height, value); }
        }

        private float _Weight;
        public float Weight
        {
            get { return _Weight; }
            set { SetProperty(ref _Weight, value); }
        }

        private BloodType _BloodType;
        public BloodType BloodType
        {
            get { return _BloodType; }
            set { SetProperty(ref _BloodType, value); }
        }

        private string _GsisIdNumber;
        public string GsisIdNumber
        {
            get { return _GsisIdNumber; }
            set { SetProperty(ref _GsisIdNumber, value); }
        }

        private string _PagIbigIdNumber;
        public string PagIbigIdNumber
        {
            get { return _PagIbigIdNumber; }
            set { SetProperty(ref _PagIbigIdNumber, value); }
        }

        private string _PhilHealthNumber;
        public string PhilHealthNumber
        {
            get { return _PhilHealthNumber; }
            set { SetProperty(ref _PhilHealthNumber, value); }
        }

        private string _SssNumber;
        public string SssNumber
        {
            get { return _SssNumber; }
            set { SetProperty(ref _SssNumber, value); }
        }

        private string _TIN;
        public string TIN
        {
            get { return _TIN; }
            set { SetProperty(ref _TIN, value); }
        }

        private string _TelephoneNumber;
        public string TelephoneNumber
        {
            get { return _TelephoneNumber; }
            set { SetProperty(ref _TelephoneNumber, value); }
        }

        private string _MobileNumber;
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { SetProperty(ref _MobileNumber, value); }
        }

        private string _AgencyEmployeeNumber;
        public string AgencyEmployeeNumber
        {
            get { return _AgencyEmployeeNumber; }
            set { SetProperty(ref _AgencyEmployeeNumber, value); }
        }

        private string _EmailAddress;
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { SetProperty(ref _EmailAddress, value); }
        }

        private PdsAddressModel _ResidentialAddress;
        public PdsAddressModel ResidentialAddress
        {
            get { return _ResidentialAddress; }
            set { SetProperty(ref _ResidentialAddress, value); }
        }

        private PdsAddressModel _PermanentAddress;
        public PdsAddressModel PermanentAddress
        {
            get { return _PermanentAddress; }
            set { SetProperty(ref _PermanentAddress, value); }
        }

        public override IPersonalDataSheet GetSource()
        {
            throw new NotImplementedException();
        }
    }
}
