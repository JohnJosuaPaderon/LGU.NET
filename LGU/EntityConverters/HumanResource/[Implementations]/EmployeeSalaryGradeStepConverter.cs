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
    public sealed class EmployeeSalaryGradeStepConverter : IEmployeeSalaryGradeStepConverter<SqlDataReader>
    {
        public EmployeeSalaryGradeStepConverter(
            IEmployeeManager employeeManager,
            ISalaryGradeStepManager salaryGradeStepManager)
        {
            r_EmployeeManager = employeeManager;
            r_SalaryGradeStepManager = salaryGradeStepManager;
        }

        private readonly IEmployeeManager r_EmployeeManager;
        private readonly ISalaryGradeStepManager r_SalaryGradeStepManager;

        private IEmployeeSalaryGradeStep GetData(IEmployee employee, ISalaryGradeStep salaryGradeStep, SqlDataReader reader)
        {
            return new EmployeeSalaryGradeStep()
            {
                Employee = employee,
                SalaryGradeStep = salaryGradeStep,
                EffectivityDate = reader.GetDateTime("EffectivityDate")
            };
        }

        private IEmployeeSalaryGradeStep GetData(SqlDataReader reader)
        {
            var employeeResult = r_EmployeeManager.GetById(reader.GetInt64("EmployeeId"));
            var salaryGradeStepResult = r_SalaryGradeStepManager.GetById(reader.GetInt64("SalaryGradeStepId"));

            return GetData(employeeResult.Data, salaryGradeStepResult.Data, reader);
        }

        private async Task<IEmployeeSalaryGradeStep> GetDataAsync(SqlDataReader reader)
        {
            var employeeResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"));
            var salaryGradeStepResult = await r_SalaryGradeStepManager.GetByIdAsync(reader.GetInt64("SalaryGradeStepId"));

            return GetData(employeeResult.Data, salaryGradeStepResult.Data, reader);
        }

        private async Task<IEmployeeSalaryGradeStep> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var employeeResult = await r_EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"), cancellationToken);
            var salaryGradeStepResult = await r_SalaryGradeStepManager.GetByIdAsync(reader.GetInt64("SalaryGradeStepId"), cancellationToken);

            return GetData(employeeResult.Data, salaryGradeStepResult.Data, reader);
        }

        public IEnumerableProcessResult<IEmployeeSalaryGradeStep> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeSalaryGradeStep>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmployeeSalaryGradeStep>(list);
            }
            catch (Exception ex)
            {

                return new EnumerableProcessResult<IEmployeeSalaryGradeStep>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeSalaryGradeStep>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IEmployeeSalaryGradeStep>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IEmployeeSalaryGradeStep>(list);
            }
            catch (Exception ex)
            {

                return new EnumerableProcessResult<IEmployeeSalaryGradeStep>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmployeeSalaryGradeStep>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEmployeeSalaryGradeStep>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IEmployeeSalaryGradeStep>(list);
            }
            catch (Exception ex)
            {

                return new EnumerableProcessResult<IEmployeeSalaryGradeStep>(ex);
            }
        }

        public IProcessResult<IEmployeeSalaryGradeStep> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEmployeeSalaryGradeStep>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEmployeeSalaryGradeStep>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ex);
            }
        }

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEmployeeSalaryGradeStep>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ex);
            }
        }
    }
}
