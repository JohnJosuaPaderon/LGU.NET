using LGU.Data.Extensions;
using LGU.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class GenderConverter : IGenderConverter<SqlDataReader>
    {
        private Gender GetData(SqlDataReader reader)
        {
            return new Gender()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableDataProcessResult<Gender> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Gender>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<Gender>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<Gender>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<Gender>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Gender>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<Gender>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<Gender>(ex);
            }
        }

        public async Task<IEnumerableDataProcessResult<Gender>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Gender>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<Gender>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<Gender>(ex);
            }
        }

        public IDataProcessResult<Gender> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new DataProcessResult<Gender>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<Gender>(ex);
            }
        }

        public async Task<IDataProcessResult<Gender>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new DataProcessResult<Gender>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<Gender>(ex);
            }
        }

        public async Task<IDataProcessResult<Gender>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new DataProcessResult<Gender>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<Gender>(ex);
            }
        }
    }
}
