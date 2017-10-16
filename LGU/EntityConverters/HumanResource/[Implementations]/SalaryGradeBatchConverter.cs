using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class SalaryGradeBatchConverter : ISalaryGradeBatchConverter
    {
        private ISalaryGradeBatch GetData(DbDataReader reader)
        {
            return new SalaryGradeBatch()
            {
                Id = reader.GetInt32("Id"),
                EffectivityDate = reader.GetDateTime("EffectivityDate"),
                ExpiryDate = reader.GetNullableDateTime("ExpiryDate"),
                Description = reader.GetString("Description")

            };
        }

        public IEnumerableProcessResult<ISalaryGradeBatch> EnumerableFromReader(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<ISalaryGradeBatch>> EnumerableFromReaderAsync(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<ISalaryGradeBatch>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<ISalaryGradeBatch> FromReader(DbDataReader reader)
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

        public async Task<IProcessResult<ISalaryGradeBatch>> FromReaderAsync(DbDataReader reader)
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

        public async Task<IProcessResult<ISalaryGradeBatch>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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
