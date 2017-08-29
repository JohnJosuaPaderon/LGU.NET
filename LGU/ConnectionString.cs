using System.Security;

namespace LGU
{
    public sealed class ConnectionString : IConnectionString
    {
        public string Key { get; set; }
        public SecureString Value { get; set; }


        public static bool operator ==(ConnectionString left, ConnectionString right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ConnectionString left, ConnectionString right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as ConnectionString;
            return Key.Equals(value.Key);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
