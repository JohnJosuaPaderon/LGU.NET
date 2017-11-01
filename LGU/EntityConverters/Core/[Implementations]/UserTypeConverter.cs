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
    public sealed class UserTypeConverter : IUserTypeConverter
    {
        private IUserType GetData(DbDataReader reader)
        {
            return new UserType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IUserType> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IUserType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IUserType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IUserType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IUserType>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IUserType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IUserType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IUserType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IUserType>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IUserType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IUserType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IUserType>(ex);
            }
        }

        public IProcessResult<IUserType> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IUserType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IUserType>(ex);
            }
        }

        public async Task<IProcessResult<IUserType>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IUserType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IUserType>(ex);
            }
        }

        public async Task<IProcessResult<IUserType>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IUserType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IUserType>(ex);
            }
        }

        public void InitializeDependency()
        {
            // TODO: Initialize Entity Managers
        }
    }
}
