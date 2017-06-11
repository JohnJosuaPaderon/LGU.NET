namespace LGU.Core.Entities
{
    public class MACAddressOptions
    {
        private static MACAddressOptions _Default;

        public static MACAddressOptions Default
        {
            get
            {
                if (_Default == null)
                {
                    throw LGUException.NullReference($"Default {nameof(MACAddressOptions)} is not initialized.");
                }

                return _Default;
            }
            set
            {
                _Default = value;
            }
        }

        public char BlockSeparator { get; set; }
    }
}
