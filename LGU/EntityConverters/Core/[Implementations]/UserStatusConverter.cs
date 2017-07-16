using LGU.Data.Extensions;
using LGU.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class UserStatusConverter : IUserStatusConverter<SqlDataReader>
    {
        private UserStatus GetData(SqlDataReader reader)
        {
            return new UserStatus()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableDataProcessResult<UserStatus> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<UserStatus>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<UserStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<UserStatus>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<UserStatus>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<UserStatus>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<UserStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<UserStatus>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<UserStatus>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<UserStatus>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<UserStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<UserStatus>(ex);
            }
        }

        public IDataProcessResult<UserStatus> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new DataProcessResult<UserStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<UserStatus>(ex);
            }
        }

        public async Task<IDataProcessResult<UserStatus>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new DataProcessResult<UserStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<UserStatus>(ex);
            }
        }

        public async Task<IDataProcessResult<UserStatus>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new DataProcessResult<UserStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<UserStatus>(ex);
            }
        }
    }
}
