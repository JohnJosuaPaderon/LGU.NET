using LGU.Processes;
using LGU.Security;
using LGU.Utilities;
using System;
using System.IO;
using System.Security;

namespace LGU
{
    public sealed class SystemAdministratorManager : ISystemAdministratorManager
    {
        public SystemAdministratorManager()
        {
            SystemAdministrationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LGU.NET", "system_administration");
            SystemAdministrationTemplateDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LGU.NET", "system_administration");

            AdministratorKeyPath = Path.Combine(SystemAdministrationDirectory, "admin_key.txt");
            AdministratorKeyTemplatePath = Path.Combine(SystemAdministrationTemplateDirectory, "admin_key.txt");
        }

        private string SystemAdministrationDirectory { get; }
        private string SystemAdministrationTemplateDirectory { get; }
        private string AdministratorKeyPath { get; }
        private string AdministratorKeyTemplatePath { get; }

        public void GenerateAdministratorKey()
        {
            if (!File.Exists(AdministratorKeyTemplatePath))
            {
                Directory.CreateDirectory(SystemAdministrationTemplateDirectory);
                using (var fileStream = File.Create(AdministratorKeyTemplatePath))
                {
                    fileStream.Close();
                }
            }
            else
            {
                Directory.CreateDirectory(SystemAdministrationDirectory);
                File.WriteAllText(AdministratorKeyPath, SecureHash.ComputeSHA256(File.ReadAllText(AdministratorKeyTemplatePath)));
                File.Delete(AdministratorKeyTemplatePath);
            }
        }

        public IProcessResult Verify(SecureString secureAdministratorKey)
        {
            if (File.Exists(AdministratorKeyPath))
            {
                var administratorKey = File.ReadAllText(AdministratorKeyPath);

                try
                {
                    if (administratorKey == SecureHash.ComputeSHA256(SecureStringConverter.Convert(secureAdministratorKey)))
                    {
                        return new ProcessResult(ProcessResultStatus.Success);
                    }
                    else
                    {
                        return new ProcessResult(ProcessResultStatus.Failed, "Administrator's Key mismatched.");
                    }
                }
                finally
                {
                    administratorKey = null;
                }
            }
            else
            {
                return new ProcessResult(ProcessResultStatus.Failed, "File doesn't exists.");
            }
        }
    }
}
