namespace LGU.Configurations
{
    public class ApplicationSetting
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public static bool operator ==(ApplicationSetting left, ApplicationSetting right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ApplicationSetting left, ApplicationSetting right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as ApplicationSetting;
            return Key.Equals(value.Key);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return Value?.ToString() ?? "Value is null.";
        }
    }
}
