using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.EntityManagers.Core;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class UserConverter : IUserConverter
    {
        public UserConverter(
            IPersonManager personManager,
            IUserStatusManager userStatusManager,
            IUserTypeManager userTypeManager)
        {
            _PersonManager = personManager;
            _UserStatusManager = userStatusManager;
            _UserTypeManager = userTypeManager;
        }

        private readonly IPersonManager _PersonManager;
        private readonly IUserStatusManager _UserStatusManager;
        private readonly IUserTypeManager _UserTypeManager;

        private IUser GetData(IPerson owner, IUserStatus status, IUserType type, DbDataReader reader)
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

        private IUser GetData(DbDataReader reader)
        {
            var ownerResult = _PersonManager.GetById(reader.GetInt64("OwnerId"));
            var statusResult = _UserStatusManager.GetById(reader.GetInt16("StatusId"));
            var typeResult = _UserTypeManager.GetById(reader.GetInt16("TypeId"));

            return GetData(ownerResult.Data, statusResult.Data, typeResult.Data, reader);
        }

        private async Task<IUser> GetDataAsync(DbDataReader reader)
        {
            var ownerResult = await _PersonManager.GetByIdAsync(reader.GetInt64("OwnerId"));
            var statusResult = await _UserStatusManager.GetByIdAsync(reader.GetInt16("StatusId"));
            var typeResult = await _UserTypeManager.GetByIdAsync(reader.GetInt16("TypeId"));

            return GetData(ownerResult.Data, statusResult.Data, typeResult.Data, reader);
        }

        private async Task<IUser> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var ownerResult = await _PersonManager.GetByIdAsync(reader.GetInt64("OwnerId"), cancellationToken);
            var statusResult = await _UserStatusManager.GetByIdAsync(reader.GetInt16("StatusId"), cancellationToken);
            var typeResult = await _UserTypeManager.GetByIdAsync(reader.GetInt16("TypeId"), cancellationToken);

            return GetData(ownerResult.Data, statusResult.Data, typeResult.Data, reader);
        }

        public IEnumerableProcessResult<IUser> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IUser>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IUser>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IUser>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IUser>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IUser>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IUser>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IUser>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IUser>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IUser>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IUser>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IUser>(ex);
            }
        }

        public IProcessResult<IUser> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IUser>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IUser>(ex);
            }
        }

        public async Task<IProcessResult<IUser>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IUser>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IUser>(ex);
            }
        }

        public async Task<IProcessResult<IUser>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IUser>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IUser>(ex);
            }
        }
    }
}
