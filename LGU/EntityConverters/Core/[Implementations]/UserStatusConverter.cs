using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class UserStatusConverter : IUserStatusConverter
    {
        private IUserStatus GetData(DbDataReader reader)
        {
            return new UserStatus()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IUserStatus> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IUserStatus>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IUserStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IUserStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IUserStatus>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IUserStatus>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IUserStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IUserStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IUserStatus>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IUserStatus>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IUserStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IUserStatus>(ex);
            }
        }

        public IProcessResult<IUserStatus> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IUserStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IUserStatus>(ex);
            }
        }

        public async Task<IProcessResult<IUserStatus>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IUserStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IUserStatus>(ex);
            }
        }

        public async Task<IProcessResult<IUserStatus>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IUserStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IUserStatus>(ex);
            }
        }

        public void InitializeDependency()
        {
            // TODO: Initialize Entity Managers
        }
    }
}
