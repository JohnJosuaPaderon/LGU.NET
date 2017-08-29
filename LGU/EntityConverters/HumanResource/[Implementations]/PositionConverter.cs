using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class PositionConverter : IPositionConverter<SqlDataReader>
    {
        private IPosition GetData(SqlDataReader reader)
        {
            return new Position()
            {
                Id = reader.GetInt32("Id"),
                Description = reader.GetString("Description"),
                Abbreviation = reader.GetString("Abbreviation")
            };
        }

        public IEnumerableProcessResult<IPosition> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IPosition>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IPosition>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPosition>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPosition>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IPosition>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IPosition>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPosition>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPosition>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IPosition>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IPosition>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPosition>(ex);
            }
        }

        public IProcessResult<IPosition> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IPosition>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPosition>(ex);
            }
        }

        public async Task<IProcessResult<IPosition>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IPosition>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPosition>(ex);
            }
        }

        public async Task<IProcessResult<IPosition>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IPosition>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPosition>(ex);
            }
        }
    }
}
