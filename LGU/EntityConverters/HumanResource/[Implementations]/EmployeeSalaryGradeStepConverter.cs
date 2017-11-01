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
    public sealed class EmployeeSalaryGradeStepConverter : IEmployeeSalaryGradeStepConverter
    {
        private IEmployeeManager EmployeeManager;
        private ISalaryGradeStepManager SalaryGradeStepManager;

        private IEmployeeSalaryGradeStep GetData(IEmployee employee, ISalaryGradeStep salaryGradeStep, DbDataReader reader)
        {
            return new EmployeeSalaryGradeStep()
            {
                Employee = employee,
                SalaryGradeStep = salaryGradeStep,
                EffectivityDate = reader.GetDateTime("EffectivityDate")
            };
        }

        private IEmployeeSalaryGradeStep GetData(DbDataReader reader)
        {
            var employeeResult = EmployeeManager.GetById(reader.GetInt64("EmployeeId"));
            var salaryGradeStepResult = SalaryGradeStepManager.GetById(reader.GetInt64("SalaryGradeStepId"));

            return GetData(employeeResult.Data, salaryGradeStepResult.Data, reader);
        }

        private async Task<IEmployeeSalaryGradeStep> GetDataAsync(DbDataReader reader)
        {
            var employeeResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"));
            var salaryGradeStepResult = await SalaryGradeStepManager.GetByIdAsync(reader.GetInt64("SalaryGradeStepId"));

            return GetData(employeeResult.Data, salaryGradeStepResult.Data, reader);
        }

        private async Task<IEmployeeSalaryGradeStep> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var employeeResult = await EmployeeManager.GetByIdAsync(reader.GetInt64("EmployeeId"), cancellationToken);
            var salaryGradeStepResult = await SalaryGradeStepManager.GetByIdAsync(reader.GetInt64("SalaryGradeStepId"), cancellationToken);

            return GetData(employeeResult.Data, salaryGradeStepResult.Data, reader);
        }

        public IEnumerableProcessResult<IEmployeeSalaryGradeStep> EnumerableFromReader(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IEmployeeSalaryGradeStep>> EnumerableFromReaderAsync(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IEmployeeSalaryGradeStep>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IEmployeeSalaryGradeStep> FromReader(DbDataReader reader)
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

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> FromReaderAsync(DbDataReader reader)
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

        public async Task<IProcessResult<IEmployeeSalaryGradeStep>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public void InitializeDependency()
        {
            EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            SalaryGradeStepManager = ApplicationDomain.GetService<ISalaryGradeStepManager>();
        }
    }
}
