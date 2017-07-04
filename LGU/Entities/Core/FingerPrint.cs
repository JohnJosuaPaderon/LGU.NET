namespace LGU.Entities.Core
{
    public class FingerPrint
    {
        internal FingerPrint(FingerType fingerType, HandType handType)
        {
            FingerType = fingerType;
            HandType = handType;
        }

        public FingerType FingerType { get; }
        public HandType HandType { get; }
        public byte[] Data { get; set; }

        public static bool operator ==(FingerPrint left, FingerPrint right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FingerPrint left, FingerPrint right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as FingerPrint;
            return
                FingerType.Equals(value.FingerType) &&
                HandType.Equals(value.HandType);
        }

        public override int GetHashCode()
        {
            return FingerType.GetHashCode() ^ HandType.GetHashCode();
        }

        public override string ToString()
        {
            return $"{HandType} {FingerTypeConverter.GetDisplay(FingerType)}";
        }
    }
}
