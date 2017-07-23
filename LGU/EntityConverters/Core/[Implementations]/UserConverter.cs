using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.EntityManagers.Core;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class UserConverter : IUserConverter<SqlDataReader>
    {
        private readonly IPersonManager r_PersonManager;
        private readonly IUserStatusManager r_UserStatusManager;
        private readonly IUserTypeManager r_UserTypeManager;

        public UserConverter(
            IPersonManager personManager,
            IUserStatusManager userStatusManager,
            IUserTypeManager userTypeManager)
        {
            r_PersonManager = personManager;
            r_UserStatusManager = userStatusManager;
            r_UserTypeManager = userTypeManager;
        }

        private User GetData(Person owner, UserStatus status, UserType type, SqlDataReader reader)
        {
            if (owner != null)
            {
                return new User(owner)
                {
                    Id = reader.GetInt64("Id"),
                    SecureUsername = null,
                    SecurePassword = null,
                    Status = status,
                    Type = type,
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
                    Status = status,
                    Type = type,
                    DisplayName = reader.GetString("DisplayName")
                };
            }
        }

        private User GetData(SqlDataReader reader)
        {
            var ownerResult = r_PersonManager.GetById(reader.GetInt64("OwnerId"));
            var statusResult = r_UserStatusManager.GetById(reader.GetInt16("StatusId"));
            var typeResult = r_UserTypeManager.GetById(reader.GetInt16("TypeId"));

            return GetData(ownerResult.Data, statusResult.Data, typeResult.Data, reader);
        }

        private async Task<User> GetDataAsync(SqlDataReader reader)
        {
            var ownerResult = await r_PersonManager.GetByIdAsync(reader.GetInt64("OwnerId"));
            var statusResult = await r_UserStatusManager.GetByIdAsync(reader.GetInt16("StatusId"));
            var typeResult = await r_UserTypeManager.GetByIdAsync(reader.GetInt16("TypeId"));

            return GetData(ownerResult.Data, statusResult.Data, typeResult.Data, reader);
        }

        private async Task<User> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var ownerResult = await r_PersonManager.GetByIdAsync(reader.GetInt64("OwnerId"), cancellationToken);
            var statusResult = await r_UserStatusManager.GetByIdAsync(reader.GetInt16("StatusId"), cancellationToken);
            var typeResult = await r_UserTypeManager.GetByIdAsync(reader.GetInt16("TypeId"), cancellationToken);

            return GetData(ownerResult.Data, statusResult.Data, typeResult.Data, reader);
        }

        public IEnumerableProcessResult<User> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<User>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<User>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<User>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<User>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<User>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<User>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<User>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<User>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<User>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<User>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<User>(ex);
            }
        }

        public IProcessResult<User> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<User>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<User>(ex);
            }
        }

        public async Task<IProcessResult<User>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<User>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<User>(ex);
            }
        }

        public async Task<IProcessResult<User>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<User>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<User>(ex);
            }
        }
    }
}
