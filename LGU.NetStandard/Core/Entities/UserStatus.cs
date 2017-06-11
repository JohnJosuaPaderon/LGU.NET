namespace LGU.Core.Entities
{
    public struct UserStatus
    {
        public string Name { get; set; }
        public string Remarks { get; set; }

        public static bool operator ==(UserStatus left, UserStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserStatus left, UserStatus right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = (UserStatus)obj;
            return Name.Equals(value.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
