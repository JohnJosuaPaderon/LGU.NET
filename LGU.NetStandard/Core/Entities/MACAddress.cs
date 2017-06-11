namespace LGU.Core.Entities
{
    public class MACAddress
    {
        public byte Block1 { get; set; }
        public byte Block2 { get; set; }
        public byte Block3 { get; set; }
        public byte Block4 { get; set; }
        public byte Block5 { get; set; }
        public byte Block6 { get; set; }

        public static implicit operator MACAddress(string value)
        {
            return new MACAddress();
        }

        public static bool operator ==(MACAddress left, MACAddress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MACAddress left, MACAddress right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as MACAddress;

            return
                Block1.Equals(value.Block1) &&
                Block2.Equals(value.Block2) &&
                Block3.Equals(value.Block3) &&
                Block4.Equals(value.Block4) &&
                Block5.Equals(value.Block5) &&
                Block6.Equals(value.Block6);
        }

        public override int GetHashCode()
        {
            return
                Block1.GetHashCode() ^
                Block2.GetHashCode() ^
                Block3.GetHashCode() ^
                Block4.GetHashCode() ^
                Block5.GetHashCode() ^
                Block6.GetHashCode();
        }
    }
}
