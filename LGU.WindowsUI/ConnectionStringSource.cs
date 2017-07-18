using LGU.Security;
using LGU.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security;
using System.Windows;

namespace LGU
{
    public sealed class ConnectionStringSource : IConnectionStringSource
    {
        public ConnectionStringSource()
        {
            var connectionStringSourcePath = GetPath();

            Source = JObject.Parse(File.ReadAllText(connectionStringSourcePath));
            IsEncrypted = (bool)Source[nameof(IsEncrypted)];
            JConnectionStrings = (JArray)Source[nameof(ConnectionStrings)];
            Load();
        }

        private JObject Source { get; }
        public bool IsEncrypted { get; }
        private JArray JConnectionStrings { get; }
        private Dictionary<string, SecureString> ConnectionStrings { get; } = new Dictionary<string, SecureString>();

        public SecureString this[string key]
        {
            get
            {
                return ConnectionStrings[key];
            }
        }

        private string GetPath()
        {
            var connectionStringSourcePath = SystemRuntime.ResolveSystemPath(ConfigurationManager.AppSettings["ConnectionStringSource"]);

            if (string.IsNullOrWhiteSpace(connectionStringSourcePath))
            {
                throw new Exception("Invalid Connection String Source Path.");
            }

            if (!File.Exists(connectionStringSourcePath))
            {
                throw new Exception("Connection String Source doesn't exists.");
            }

            return connectionStringSourcePath;
        }

        private void Load()
        {
            foreach (JObject item in JConnectionStrings)
            {
                var raw = (string)item["Value"];
                var secure = SecureStringConverter.Convert(IsEncrypted ? Crypto.Decrypt(raw, nameof(IConnectionStringSource)) : raw);
                ConnectionStrings.Add((string)item["Key"], secure);
            }
        }

        public IEnumerable<ConnectionString> GetSource()
        {
            var list = new List<ConnectionString>();

            foreach (var item in ConnectionStrings)
            {
                list.Add(new ConnectionString()
                {
                    Key = item.Key,
                    Value = item.Value
                });
            }

            return list;
        }

        public void Overwrite(bool isEncrypted, IEnumerable<ConnectionString> connectionStrings)
        {
            JConnectionStrings.Clear();

            foreach (var item in connectionStrings)
            {
                var jConnectionString = new JObject
                {
                    { "Key", item.Key },
                    { "Value", isEncrypted ? Crypto.Encrypt(SecureStringConverter.Convert(item.Value), nameof(IConnectionStringSource)) : SecureStringConverter.Convert(item.Value) }
                };
                JConnectionStrings.Add(jConnectionString);
            }

            Source[nameof(IsEncrypted)] = isEncrypted;
            Source[nameof(ConnectionStrings)] = JConnectionStrings;

            File.WriteAllText(GetPath(), Source.ToString());

            Application.Current.Shutdown();
        }
    }
}
