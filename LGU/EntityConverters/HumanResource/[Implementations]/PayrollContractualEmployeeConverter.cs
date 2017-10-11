﻿using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class PayrollContractualEmployeeConverter : IPayrollContractualEmployeeConverter<SqlDataReader>
    {
        public PayrollContractualEmployeeConverter(IPayrollContractualEmployeeFields fields, IEmployeeManager employeeManager, IPayrollManager<SqlConnection, SqlTransaction> payrollManager)
        {
            _EmployeeManager = employeeManager;
            _PayrollManager = payrollManager;
            _Fields = fields;

            PEmployee = new DataConverterProperty<IEmployee>();
            PPayroll = new DataConverterProperty<IPayroll>();
            PMonthlyRate = new DataConverterProperty<decimal>();
            PWithholdingTax = new DataConverterProperty<decimal?>();
            PHdmfPremiumPs = new DataConverterProperty<decimal?>();
            PTimeLogDeduction = new DataConverterProperty<decimal>();
        }

        private readonly IPayrollContractualEmployeeFields _Fields;
        private readonly IEmployeeManager _EmployeeManager;
        private readonly IPayrollManager<SqlConnection, SqlTransaction> _PayrollManager;

        public IDataConverterProperty<IEmployee> PEmployee { get; }
        public IDataConverterProperty<IPayroll> PPayroll { get; }
        public IDataConverterProperty<decimal> PMonthlyRate { get; }
        public IDataConverterProperty<decimal?> PWithholdingTax { get; }
        public IDataConverterProperty<decimal?> PHdmfPremiumPs { get; }
        public IDataConverterProperty<decimal> PTimeLogDeduction { get; }

        private IPayrollContractualEmployee Get(IEmployee employee, IPayroll payroll, SqlDataReader reader)
        {
            return new PayrollContractualEmployee()
            {
                Employee = employee,
                Payroll = payroll,
                MonthlyRate = PMonthlyRate.TryGetValue(reader.GetDecimal, _Fields.MonthlyRate),
                HdmfPremiumPs = PHdmfPremiumPs.TryGetValue(reader.GetNullableDecimal, _Fields.HdmfPremiumPs),
                TimeLogDeduction = PTimeLogDeduction.TryGetValue(reader.GetDecimal, _Fields.TimeLogDeduction),
                WithholdingTax = PWithholdingTax.TryGetValue(reader.GetNullableDecimal, _Fields.WithholdingTax)
            };
        }

        private IPayrollContractualEmployee Get(SqlDataReader reader)
        {
            var employee = PEmployee.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64, _Fields.EmployeeId);
            var payroll = PPayroll.TryGetValueFromProcess(_PayrollManager.GetById, reader.GetInt64, _Fields.PayrollId);

            return Get(employee, payroll, reader);
        }

        private async Task<IPayrollContractualEmployee> GetAsync(SqlDataReader reader)
        {
            var employee = await PEmployee.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.EmployeeId);
            var payroll = await PPayroll.TryGetValueFromProcessAsync(_PayrollManager.GetByIdAsync, reader.GetInt64, _Fields.PayrollId);

            return Get(employee, payroll, reader);
        }

        private async Task<IPayrollContractualEmployee> GetAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var employee = await PEmployee.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.EmployeeId, cancellationToken);
            var payroll = await PPayroll.TryGetValueFromProcessAsync(_PayrollManager.GetByIdAsync, reader.GetInt64, _Fields.PayrollId, cancellationToken);

            return Get(employee, payroll, reader);
        }

        public IEnumerableProcessResult<IPayrollContractualEmployee> EnumerableFromReader(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<IPayrollContractualEmployee>> EnumerableFromReaderAsync(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<IPayrollContractualEmployee>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IPayrollContractualEmployee> FromReader(SqlDataReader reader)
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

        public async Task<IProcessResult<IPayrollContractualEmployee>> FromReaderAsync(SqlDataReader reader)
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

        public async Task<IProcessResult<IPayrollContractualEmployee>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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
