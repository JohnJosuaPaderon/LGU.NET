using DPFP;

namespace LGU.Entities.Core
{
    public class FingerPrint
    {
        public FingerPrint(FingerType fingerType, HandType handType)
        {
            FingerType = fingerType;
            HandType = handType;
        }

        private byte[] _RawData;

        public FingerType FingerType { get; }
        public HandType HandType { get; }
        public byte[] RawData
        {
            get => _RawData;
            set
            {
                //if (value != null)
                //{
                //    GraiuleTempate = new FingerprintTemplate()
                //    {
                //        Buffer = value,
                //        Size = value.Length,
                //        Quality = 2
                //    };
                //}

                _RawData = value;
            }
        }
        public Template Data { get; set; }
        //public FingerprintTemplate GraiuleTempate { get; private set; }

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
