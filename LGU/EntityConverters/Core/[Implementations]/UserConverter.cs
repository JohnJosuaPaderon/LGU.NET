using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.EntityManagers.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class UserConverter : IUserConverter<SqlDataReader>
    {
        private readonly IPersonManager PersonManager;
        private readonly IUserStatusManager UserStatusManager;
        private readonly IUserTypeManager UserTypeManager;

        public UserConverter(IPersonManager personManager, IUserStatusManager userStatusManager, IUserTypeManager userTypeManager)
        {
            PersonManager = personManager;
            UserStatusManager = userStatusManager;
            UserTypeManager = userTypeManager;
        }

        private User GetData(SqlDataReader reader)
        {
            var ownerResult = PersonManager.GetById(reader.GetInt64("OwnerId"));
            var statusResult = UserStatusManager.GetById(reader.GetInt16("StatusId"));
            var typeResult = UserTypeManager.GetById(reader.GetInt16("TypeId"));

            if (ownerResult.Status == ProcessResultStatus.Success)
            {
                return new User(ownerResult.Data)
                {
                    Id = reader.GetInt64("Id"),
                    SecureUsername = null,
                    SecurePassword = null,
                    Status = statusResult.Data,
                    Type = typeResult.Data,
                    DisplayName = reader.GetString("DisplayName")
                };
            }
            else
            {
                return new User()
                {
                    Id = reader.GetInt64("Id"),
                    SecureUsername = null,
                    SecurePassword = null,
                    Status = statusResult.Data,
                    Type = typeResult.Data,
                    DisplayName = reader.GetString("DisplayName")
                };
            }
        }

        private async Task<User> GetDataAsync(SqlDataReader reader)
        {
            var ownerResult = await PersonManager.GetByIdAsync(reader.GetInt64("OwnerId"));
            var statusResult = await UserStatusManager.GetByIdAsync(reader.GetInt16("StatusId"));
            var typeResult = await UserTypeManager.GetByIdAsync(reader.GetInt16("TypeId"));

            if (ownerResult.Status == ProcessResultStatus.Success)
            {
                return new User(ownerResult.Data)
                {
                    Id = reader.GetInt64("Id"),
                    SecureUsername = null,
                    SecurePassword = null,
                    Status = statusResult.Data,
                    Type = typeResult.Data,
                    DisplayName = reader.GetString("DisplayName")
                };
            }
            else
            {
                return new User()
                {
                    Id = reader.GetInt64("Id"),
                    SecureUsername = null,
                    SecurePassword = null,
                    Status = statusResult.Data,
                    Type = typeResult.Data,
                    DisplayName = reader.GetString("DisplayName")
                };
            }
        }

        private async Task<User> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var ownerResult = await PersonManager.GetByIdAsync(reader.GetInt64("OwnerId"), cancellationToken);
            var statusResult = await UserStatusManager.GetByIdAsync(reader.GetInt16("StatusId"), cancellationToken);
            var typeResult = await UserTypeManager.GetByIdAsync(reader.GetInt16("TypeId"), cancellationToken);

            if (ownerResult.Status == ProcessResultStatus.Success)
            {
                return new User(ownerResult.Data)
                {
                    Id = reader.GetInt64("Id"),
                    SecureUsername = null,
                    SecurePassword = null,
                    Status = statusResult.Data,
                    Type = typeResult.Data,
                    DisplayName = reader.GetString("DisplayName")
                };
            }
            else
            {
                return new User()
                {
                    Id = reader.GetInt64("Id"),
                    SecureUsername = null,
                    SecurePassword = null,
                    Status = statusResult.Data,
                    Type = typeResult.Data,
                    DisplayName = reader.GetString("DisplayName")
                };
            }
        }

        public IEnumerableDataProcessResult<User> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<User>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<User>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<User>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<User>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<User>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableDataProcessResult<User>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<User>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<User>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<User>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableDataProcessResult<User>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<User>(ex);
            }
        }

        public IDataProcessResult<User> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new DataProcessResult<User>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<User>(ex);
            }
        }

        public async Task<IDataProcessResult<User>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new DataProcessResult<User>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<User>(ex);
            }
        }

        public async Task<IDataProcessResult<User>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new DataProcessResult<User>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<User>(ex);
            }
        }
    }
}
