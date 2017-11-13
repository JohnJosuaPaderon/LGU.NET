namespace LGU.Models
{
    public sealed class ValueRangeModel<T> : ModelBase<ValueRange<T>> 
    {
        public static ValueRangeModel<T> TryCreate(T identicalValues)
        {
            return new ValueRangeModel<T>(new ValueRange<T>(identicalValues));
        }

        public static ValueRangeModel<T> TryCreate(T begin, T end)
        {
            return new ValueRangeModel<T>(new ValueRange<T>(begin, end));
        }

        public ValueRangeModel(ValueRange<T> source) : base(source)
        {
            Begin = source.Begin;
            End = source.End;
        }

        private T _Begin;
        public T Begin
        {
            get { return _Begin; }
            set { SetProperty(ref _Begin, value); }
        }

        private T _End;
        public T End
        {
            get { return _End; }
            set { SetProperty(ref _End, value); }
        }

        public override ValueRange<T> GetSource()
        {
            return new ValueRange<T>(Begin, End);
        }

        public static bool operator ==(ValueRangeModel<T> left, ValueRangeModel<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueRangeModel<T> left, ValueRangeModel<T> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is ValueRangeModel<T> value)
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
