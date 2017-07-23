using LGU.Utilities;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Data.Rdbms
{
    public class SqlConnectionEstablisher : IDbConnectionEstablisher<SqlConnection>
    {
        public SqlConnectionEstablisher(SecureString secureConnectionString)
        {
            SecureConnectionString = secureConnectionString ?? throw new ArgumentNullException(nameof(secureConnectionString));
        }

        private SecureString SecureConnectionString { get; set; }

        private SqlConnection InstantiateConnection()
        {
            return new SqlConnection(SecureStringConverter.Convert(SecureConnectionString));
        }

        public SqlConnection Establish()
        {
            var connection = InstantiateConnection();

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            return connection;
        }

        public async Task<SqlConnection> EstablishAsync()
        {
            var connection = InstantiateConnection();

            try
            {
                await connection.OpenAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return connection;
        }

        public async Task<SqlConnection> EstablishAsync(CancellationToken cancellationToken)
        {
            var connection = InstantiateConnection();

            try
            {
                await connection.OpenAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }

            return connection;
        }
    }
}
