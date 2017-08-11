namespace LGU.Models
{
    public sealed class ValueRangeModel<T> : ModelBase<ValueRange<T>> 
    {
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
    }
}
