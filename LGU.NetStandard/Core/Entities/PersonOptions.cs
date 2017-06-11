namespace LGU.Core.Entities
{
    public class PersonOptions
    {
        private static PersonOptions _Default;

        public static PersonOptions Default
        {
            get
            {
                if (_Default == null)
                {
                    throw LGUException.NullReference($"Default {nameof(PersonOptions)} is not initialized.");
                }

                return _Default;
            }
            set
            {
                _Default = value;
            }
        }

        public char MiddleNameSeparator { get; set; }
    }
}
