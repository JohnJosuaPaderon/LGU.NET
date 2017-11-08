namespace LGU
{
    public struct ValueRange<T>
    {
        public ValueRange(T dateTime)
        {
            Begin = dateTime;
            End = dateTime;
        }

        public ValueRange(T begin, T end)
        {
            Begin = begin;
            End = end;
        }

        public T Begin { get; set; }
        public T End { get; set; }

        public static bool operator ==(ValueRange<T> left, ValueRange<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueRange<T> left, ValueRange<T> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is ValueRange<T> value)
            {
                return (
                    (Equals(Begin, default(T)) || Equals(End, default(T))) ||
                    (Equals(value.Begin, default(T)) || Equals(value.End, default(T)))) ? false :
                    (Equals(Begin, value.Begin) && Equals(End, value.End));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Begin.GetHashCode();
        }
    }
}
