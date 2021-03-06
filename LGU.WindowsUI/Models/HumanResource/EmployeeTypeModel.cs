﻿using LGU.Entities.HumanResource;

namespace LGU.Models.HumanResource
{
    public sealed class EmployeeTypeModel : ModelBase<IEmployeeType>
    {
        public static EmployeeTypeModel TryCreate(IEmployeeType employeeType)
        {
            return employeeType != null ? new EmployeeTypeModel(employeeType) : null;
        }

        public EmployeeTypeModel(IEmployeeType source) : base(source)
        {
            Id = source?.Id ?? default(short);
            Description = source?.Description;
        }

        private short _Id;
        public short Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        public override IEmployeeType GetSource()
        {
            Source.Id = Id;
            Source.Description = Description;

            return Source;
        }

        public static bool operator ==(EmployeeTypeModel left, EmployeeTypeModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EmployeeTypeModel left, EmployeeTypeModel right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is EmployeeTypeModel value)
            {
                return (Id == 0 || value.Id == 0) ? false : Id == value.Id;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
