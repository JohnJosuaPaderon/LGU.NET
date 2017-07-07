using LGU.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security;

namespace LGU
{
    public sealed class ConnectionStringSource : IConnectionStringSource
    {
        public ConnectionStringSource()
        {
            var connectionStringSourcePath = ConfigurationManager.AppSettings["ConnectionStringSource"];

            if (string.IsNullOrWhiteSpace(connectionStringSourcePath))
            {
                throw new Exception("Invalid Connection String Source Path.");
            }

            if (!File.Exists(connectionStringSourcePath))
            {
                throw new Exception("Connection String Source doesn't exists.");
            }

            Source = JObject.Parse(File.ReadAllText(connectionStringSourcePath));
            IsEncrypted = (bool)Source[nameof(IsEncrypted)];
            JConnectionStrings = (JArray)Source[nameof(ConnectionStrings)];
            Load();
        }

        private JObject Source { get; }
        private bool IsEncrypted { get; }
        private JArray JConnectionStrings { get; }
        private Dictionary<string, SecureString> ConnectionStrings { get; } = new Dictionary<string, SecureString>();

        public SecureString this[string key]
        {
            get
            {
                return ConnectionStrings[key];
            }
        }

        private void Load()
        {
            foreach (JObject item in JConnectionStrings)
            {
                ConnectionStrings.Add((string)item["Key"], SecureStringConverter.ConvertToSecureString((string)item["Value"]));
            }
        }
    }
}
