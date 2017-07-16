using LGU.Data.Extensions;
using LGU.Entities.Core;
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

        public IEnumerableDataProcessResult<UserType> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<UserType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<UserType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<UserType>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<UserType>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<UserType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<UserType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<UserType>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<UserType>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<UserType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<UserType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<UserType>(ex);
            }
        }

        public IDataProcessResult<UserType> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new DataProcessResult<UserType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<UserType>(ex);
            }
        }

        public async Task<IDataProcessResult<UserType>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new DataProcessResult<UserType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<UserType>(ex);
            }
        }

        public async Task<IDataProcessResult<UserType>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new DataProcessResult<UserType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<UserType>(ex);
            }
        }
    }
}
