using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class SalaryGradeConverter : ISalaryGradeConverter
    {
        private readonly ISalaryGradeBatchManager r_SalaryGradeBatchManager;

        public SalaryGradeConverter(ISalaryGradeBatchManager salaryGradeBatchManager)
        {
            r_SalaryGradeBatchManager = salaryGradeBatchManager;
        }

        private ISalaryGrade GetData(ISalaryGradeBatch batch, DbDataReader reader)
        {
            return new SalaryGrade(batch, reader.GetInt32("Number"))
            {
                Id = reader.GetInt64("Id")
            };
        }

        private ISalaryGrade GetData(DbDataReader reader)
        {
            var batchResult = r_SalaryGradeBatchManager.GetById(reader.GetInt32("BatchId"));

            return GetData(batchResult.Data, reader);
        }

        private async Task<ISalaryGrade> GetDataAsync(DbDataReader reader)
        {
            var batchResult = await r_SalaryGradeBatchManager.GetByIdAsync(reader.GetInt32("BatchId"));

            return GetData(batchResult.Data, reader);
        }

        private async Task<ISalaryGrade> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var batchResult = await r_SalaryGradeBatchManager.GetByIdAsync(reader.GetInt32("BatchId"), cancellationToken);

            return GetData(batchResult.Data, reader);
        }

        public IEnumerableProcessResult<ISalaryGrade> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<ISalaryGrade>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ISalaryGrade>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ISalaryGrade>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ISalaryGrade>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<ISalaryGrade>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ISalaryGrade>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ISalaryGrade>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ISalaryGrade>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ISalaryGrade>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ISalaryGrade>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ISalaryGrade>(ex);
            }
        }

        public IProcessResult<ISalaryGrade> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ISalaryGrade>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ISalaryGrade>(ex);
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ISalaryGrade>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ISalaryGrade>(ex);
            }
        }

        public async Task<IProcessResult<ISalaryGrade>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ISalaryGrade>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ISalaryGrade>(ex);
            }
        }
    }
}
