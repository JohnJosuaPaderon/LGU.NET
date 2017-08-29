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
    public sealed class GenderConverter : IGenderConverter<SqlDataReader>
    {
        private IGender GetData(SqlDataReader reader)
        {
            return new Gender()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IGender> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IGender>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IGender>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IGender>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IGender>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IGender>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IGender>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IGender>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IGender>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IGender>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IGender>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IGender>(ex);
            }
        }

        public IProcessResult<IGender> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IGender>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IGender>(ex);
            }
        }

        public async Task<IProcessResult<IGender>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IGender>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IGender>(ex);
            }
        }

        public async Task<IProcessResult<IGender>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IGender>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IGender>(ex);
            }
        }
    }
}
