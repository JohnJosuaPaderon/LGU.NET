using LGU.Utilities;

namespace LGU.Models.SystemAdministration
{
    public sealed class ConnectionStringModel : ModelBase<ConnectionString>
    {
        public ConnectionStringModel(ConnectionString source) : base(source)
        {
            Key = source.Key;
            Value = SecureStringConverter.Convert(source.Value);
        }

        private string _Key;
        public string Key
        {
            get { return _Key; }
            set { SetProperty(ref _Key, value); }
        }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { SetProperty(ref _Value, value); }
        }

        public override ConnectionString GetSource()
        {
            return new ConnectionString()
            {
                Key = Key,
                Value = SecureStringConverter.ConvertToSecureString(Value)
            };
        }
    }
}
