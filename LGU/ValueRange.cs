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
    }
}
