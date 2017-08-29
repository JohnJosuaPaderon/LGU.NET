namespace LGU.Entities.Core
{
    public abstract class FingerPrintSet : IFingerPrintSet
    {
        public IFingerPrint LeftThumb { get; } = new FingerPrint(FingerType.Thumb, HandType.Left);
        public IFingerPrint LeftIndexFinger { get; } = new FingerPrint(FingerType.IndexFinger, HandType.Left);
        public IFingerPrint LeftMiddleFinger { get; } = new FingerPrint(FingerType.MiddleFinger, HandType.Left);
        public IFingerPrint LeftRingFinger { get; } = new FingerPrint(FingerType.RingFinger, HandType.Left);
        public IFingerPrint LeftLittleFinger { get; } = new FingerPrint(FingerType.LittleFinger, HandType.Left);
        public IFingerPrint RightThumb { get; } = new FingerPrint(FingerType.Thumb, HandType.Right);
        public IFingerPrint RightIndexFinger { get; } = new FingerPrint(FingerType.IndexFinger, HandType.Right);
        public IFingerPrint RightMiddleFinger { get; } = new FingerPrint(FingerType.MiddleFinger, HandType.Right);
        public IFingerPrint RightRingFinger { get; } = new FingerPrint(FingerType.RingFinger, HandType.Right);
        public IFingerPrint RightLittleFinger { get; } = new FingerPrint(FingerType.LittleFinger, HandType.Right);

        public static bool operator ==(FingerPrintSet left, FingerPrintSet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FingerPrintSet left, FingerPrintSet right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as FingerPrintSet;
            return
                LeftThumb.Equals(value.LeftThumb) &&
                LeftIndexFinger.Equals(value.LeftIndexFinger) &&
                LeftMiddleFinger.Equals(value.LeftMiddleFinger) &&
                LeftRingFinger.Equals(value.LeftRingFinger) &&
                LeftLittleFinger.Equals(value.LeftLittleFinger) &&
                RightThumb.Equals(value.RightThumb) &&
                RightIndexFinger.Equals(value.RightIndexFinger) &&
                RightMiddleFinger.Equals(value.RightMiddleFinger) &&
                RightRingFinger.Equals(value.RightRingFinger) &&
                RightLittleFinger.Equals(value.RightLittleFinger);
        }

        public override int GetHashCode()
        {
            return
                LeftThumb.GetHashCode() ^
                LeftIndexFinger.GetHashCode() ^
                LeftMiddleFinger.GetHashCode() ^
                LeftRingFinger.GetHashCode() ^
                LeftLittleFinger.GetHashCode() ^
                RightThumb.GetHashCode() ^
                RightIndexFinger.GetHashCode() ^
                RightMiddleFinger.GetHashCode() ^
                RightRingFinger.GetHashCode() ^
                RightLittleFinger.GetHashCode();
        }
    }
}
