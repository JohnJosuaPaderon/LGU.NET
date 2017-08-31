using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class SalaryGradeStepConverter : ISalaryGradeStepConverter<SqlDataReader>
    {
        private readonly ISalaryGradeManager r_SalaryGradeManager;

        public SalaryGradeStepConverter(ISalaryGradeManager salaryGradeManager)
        {
            r_SalaryGradeManager = salaryGradeManager;
        }

        private ISalaryGradeStep GetData(ISalaryGrade salaryGrade, SqlDataReader reader)
        {
            return new SalaryGradeStep(salaryGrade, reader.GetInt32("Step"))
            {
                Id = reader.GetInt64("Id"),
                Amount = reader.GetDecimal("Amount")
            };
        }

        private ISalaryGradeStep GetData(SqlDataReader reader)
        {
            var salaryGradeResult = r_SalaryGradeManager.GetById(reader.GetInt64("SalaryGradeId"));

            return GetData(salaryGradeResult.Data, reader);
        }

        private async Task<ISalaryGradeStep> GetDataAsync(SqlDataReader reader)
        {
            var salaryGradeResult = await r_SalaryGradeManager.GetByIdAsync(reader.GetInt64("SalaryGradeId"));

            return GetData(salaryGradeResult.Data, reader);
        }

        private async Task<ISalaryGradeStep> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var salaryGradeResult = await r_SalaryGradeManager.GetByIdAsync(reader.GetInt64("SalaryGradeId"), cancellationToken);

            return GetData(salaryGradeResult.Data, reader);
        }

        public IEnumerableProcessResult<ISalaryGradeStep> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<ISalaryGradeStep>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ISalaryGradeStep>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ISalaryGradeStep>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeStep>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<ISalaryGradeStep>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ISalaryGradeStep>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ISalaryGradeStep>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<ISalaryGradeStep>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<ISalaryGradeStep>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<ISalaryGradeStep>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<ISalaryGradeStep>(ex);
            }
        }

        public IProcessResult<ISalaryGradeStep> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<ISalaryGradeStep>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ISalaryGradeStep>(ex);
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<ISalaryGradeStep>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ISalaryGradeStep>(ex);
            }
        }

        public async Task<IProcessResult<ISalaryGradeStep>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<ISalaryGradeStep>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<ISalaryGradeStep>(ex);
            }
        }
    }
}
