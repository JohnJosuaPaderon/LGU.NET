using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class UserTypeConverter : IUserTypeConverter<SqlDataReader>
    {
        private UserType GetData(SqlDataReader reader)
        {
            return new UserType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<UserType> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<UserType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<UserType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<UserType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<UserType>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<UserType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<UserType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<UserType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<UserType>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<UserType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<UserType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<UserType>(ex);
            }
        }

        public IProcessResult<UserType> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<UserType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<UserType>(ex);
            }
        }

        public async Task<IProcessResult<UserType>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<UserType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<UserType>(ex);
            }
        }

        public async Task<IProcessResult<UserType>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<UserType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<UserType>(ex);
            }
        }
    }
}
