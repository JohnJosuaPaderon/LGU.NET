namespace LGU.Core.Entities
{
    public class IPv4AddressOptions
    {
        private static IPv4AddressOptions _Default;

        public static IPv4AddressOptions Default
        {
            get
            {
                if (_Default == null)
                {
                    throw LGUException.NullReference($"Default {nameof(IPv4AddressOptions)} is not initialized.");
                }

                return _Default;
            }
            set
            {
                _Default = value;
            }
        }

        public char ClassSeparator { get; set; }
    }
}
