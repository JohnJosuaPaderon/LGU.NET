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
        private Position GetData(SqlDataReader reader)
        {
            return new Position()
            {
                Id = reader.GetInt32("Id"),
                Description = reader.GetString("Description"),
                Abbreviation = reader.GetString("Abbreviation")
            };
        }

        public IEnumerableProcessResult<Position> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Position>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Position>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Position>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Position>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Position>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Position>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Position>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Position>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Position>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Position>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Position>(ex);
            }
        }

        public IProcessResult<Position> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<Position>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Position>(ex);
            }
        }

        public async Task<IProcessResult<Position>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<Position>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Position>(ex);
            }
        }

        public async Task<IProcessResult<Position>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<Position>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Position>(ex);
            }
        }
    }
}
