using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class PayrollContractualEmployeeConverter : IPayrollContractualEmployeeConverter
    {
        public PayrollContractualEmployeeConverter(IPayrollContractualEmployeeFields fields, IEmployeeManager employeeManager)
        {
            _EmployeeManager = employeeManager;
            _Fields = fields;

            PDepartment = new DataConverterProperty<IPayrollContractualDepartment>();
            PEmployee = new DataConverterProperty<IEmployee>();
            PMonthlyRate = new DataConverterProperty<decimal>();
            PWithholdingTax = new DataConverterProperty<decimal?>();
            PHdmfPremiumPs = new DataConverterProperty<decimal?>();
            PTimeLogDeduction = new DataConverterProperty<decimal>();
        }

        private readonly IPayrollContractualEmployeeFields _Fields;
        private readonly IEmployeeManager _EmployeeManager;

        public IDataConverterProperty<IPayrollContractualDepartment> PDepartment { get; }
        public IDataConverterProperty<IEmployee> PEmployee { get; }
        public IDataConverterProperty<decimal> PMonthlyRate { get; }
        public IDataConverterProperty<decimal?> PWithholdingTax { get; }
        public IDataConverterProperty<decimal?> PHdmfPremiumPs { get; }
        public IDataConverterProperty<decimal> PTimeLogDeduction { get; }

        private IPayrollContractualEmployee Get(IEmployee employee, DbDataReader reader)
        {
            return new PayrollContractualEmployee()
            {
                Employee = employee,
                MonthlyRate = PMonthlyRate.TryGetValue(reader.GetDecimal, _Fields.MonthlyRate),
                HdmfPremiumPs = PHdmfPremiumPs.TryGetValue(reader.GetNullableDecimal, _Fields.HdmfPremiumPs),
                TimeLogDeduction = PTimeLogDeduction.TryGetValue(reader.GetDecimal, _Fields.TimeLogDeduction),
                WithholdingTax = PWithholdingTax.TryGetValue(reader.GetNullableDecimal, _Fields.WithholdingTax)
            };
        }

        private IPayrollContractualEmployee Get(DbDataReader reader)
        {
            var employee = PEmployee.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64, _Fields.EmployeeId);

            return Get(employee, reader);
        }

        private async Task<IPayrollContractualEmployee> GetAsync(DbDataReader reader)
        {
            var employee = await PEmployee.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.EmployeeId);

            return Get(employee, reader);
        }

        private async Task<IPayrollContractualEmployee> GetAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var employee = await PEmployee.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.EmployeeId, cancellationToken);

            return Get(employee, reader);
        }

        public IEnumerableProcessResult<IPayrollContractualEmployee> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IPayrollContractualEmployee>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IPayrollContractualEmployee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollContractualEmployee>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayrollContractualEmployee>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IPayrollContractualEmployee>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetAsync(reader));
                }

                return new EnumerableProcessResult<IPayrollContractualEmployee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollContractualEmployee>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayrollContractualEmployee>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IPayrollContractualEmployee>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IPayrollContractualEmployee>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollContractualEmployee>(ex);
            }
        }

        public IProcessResult<IPayrollContractualEmployee> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IPayrollContractualEmployee>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollContractualEmployee>(ex);
            }
        }

        public async Task<IProcessResult<IPayrollContractualEmployee>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IPayrollContractualEmployee>(await GetAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollContractualEmployee>(ex);
            }
        }

        public async Task<IProcessResult<IPayrollContractualEmployee>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IPayrollContractualEmployee>(await GetAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollContractualEmployee>(ex);
            }
        }
    }
}
