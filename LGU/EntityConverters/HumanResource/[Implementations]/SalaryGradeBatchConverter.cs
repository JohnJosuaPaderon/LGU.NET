using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class SalaryGradeBatchConverter : ISalaryGradeBatchConverter<SqlDataReader>
    {
        private ISalaryGradeBatch GetData(SqlDataReader reader)
        {
            return new SalaryGradeBatch()
            {
            };
        }

        public IEnumerableProcessResult<ISalaryGradeBatch> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<ISalaryGradeBatch>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ISalaryGradeBatch>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ISalaryGradeBatch>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeBatch>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<ISalaryGradeBatch>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ISalaryGradeBatch>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ISalaryGradeBatch>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeBatch>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ISalaryGradeBatch>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ISalaryGradeBatch>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ISalaryGradeBatch>(ex);
            }
        }

        public IProcessResult<ISalaryGradeBatch> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ISalaryGradeBatch>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ISalaryGradeBatch>(ex);
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ISalaryGradeBatch>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ISalaryGradeBatch>(ex);
            }
        }

        public async Task<IProcessResult<ISalaryGradeBatch>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ISalaryGradeBatch>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ISalaryGradeBatch>(ex);
            }
        }
    }
}
