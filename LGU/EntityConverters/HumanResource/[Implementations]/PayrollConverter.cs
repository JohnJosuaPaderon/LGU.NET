using LGU.Data.Extensions;
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
    public sealed class PayrollConverter : IPayrollConverter<SqlDataReader>
    {
        public PayrollConverter(
            IPayrollFields fields,
            IPayrollTypeManager payrollTypeManager,
            IPayrollCutOffManager payrollCutOffManager,
            IEmployeeManager employeeManager)
        {
            _Fields = fields;
            _PayrollTypeManager = payrollTypeManager;
            _PayrollCutOffManager = payrollCutOffManager;
            _EmployeeManager = employeeManager;

            PId = new DataConverterProperty<long>();
            PType = new DataConverterProperty<IPayrollType>();
            PCutOff = new DataConverterProperty<IPayrollCutOff>();
            PRangeDate = new DataConverterProperty<ValueRange<DateTime>>();
            PRunDate = new DataConverterProperty<DateTime>();
            PHumanResourceHead = new DataConverterProperty<IEmployee>();
            PMayor = new DataConverterProperty<IEmployee>();
            PTreasurer = new DataConverterProperty<IEmployee>();
            PCityAccountant = new DataConverterProperty<IEmployee>();
            PCityBudgetOfficer = new DataConverterProperty<IEmployee>();
        }

        private readonly IPayrollFields _Fields;
        private readonly IPayrollTypeManager _PayrollTypeManager;
        private readonly IPayrollCutOffManager _PayrollCutOffManager;
        private readonly IEmployeeManager _EmployeeManager;

        public IDataConverterProperty<long> PId { get; }
        public IDataConverterProperty<IPayrollType> PType { get; }
        public IDataConverterProperty<IPayrollCutOff> PCutOff { get; }
        public IDataConverterProperty<ValueRange<DateTime>> PRangeDate { get; }
        public IDataConverterProperty<DateTime> PRunDate { get; }
        public IDataConverterProperty<IEmployee> PHumanResourceHead { get; }
        public IDataConverterProperty<IEmployee> PMayor { get; }
        public IDataConverterProperty<IEmployee> PTreasurer { get; }
        public IDataConverterProperty<IEmployee> PCityAccountant { get; }
        public IDataConverterProperty<IEmployee> PCityBudgetOfficer { get; }

        private IPayroll Get(IPayrollType type, IPayrollCutOff cutOff, IEmployee humanResourceHead, IEmployee mayor, IEmployee treasurer, IEmployee cityAccountant, IEmployee cityBudgetOfficer, SqlDataReader reader)
        {
            return new Payroll
            {
                Id = reader.GetInt64(_Fields.Id),
                Type = type,
                CutOff = cutOff,
                RangeDate = new ValueRange<DateTime>(
                    reader.GetDateTime(_Fields.RangeDateBegin),
                    reader.GetDateTime(_Fields.RangeDateEnd)),
                RunDate = reader.GetDateTime(_Fields.RunDate),
                HumanResourceHead = humanResourceHead,
                Mayor = mayor,
                Treasurer = treasurer,
                CityAccountant = cityAccountant,
                CityBudgetOfficer = cityBudgetOfficer
            };
        }

        private IPayroll Get(SqlDataReader reader)
        {
            var type = PType.TryGetValueFromProcess(_PayrollTypeManager.GetById, reader.GetInt16, _Fields.TypeId);
            var cutOff = PCutOff.TryGetValueFromProcess(_PayrollCutOffManager.GetById, reader.GetInt16, _Fields.CutOffId);
            var humanResourceHead = PHumanResourceHead.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64, _Fields.HumanResourceHeadId);
            var mayor = PMayor.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64, _Fields.MayorId);
            var treasurer = PTreasurer.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64, _Fields.TreasurerId);
            var cityAccountant = PCityAccountant.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64, _Fields.CityAccountantId);
            var cityBudgetOfficer = PCityBudgetOfficer.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64, _Fields.CityBudgetOfficerId);

            return Get(type, cutOff, humanResourceHead, mayor, treasurer, cityAccountant, cityBudgetOfficer, reader);
        }

        private async Task<IPayroll> GetAsync(SqlDataReader reader)
        {
            var type = await PType.TryGetValueFromProcessAsync(_PayrollTypeManager.GetByIdAsync, reader.GetInt16, _Fields.TypeId);
            var cutOff = await PCutOff.TryGetValueFromProcessAsync(_PayrollCutOffManager.GetByIdAsync, reader.GetInt16, _Fields.CutOffId);
            var humanResourceHead = await PHumanResourceHead.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.HumanResourceHeadId);
            var mayor = await PMayor.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.MayorId);
            var treasurer = await PTreasurer.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.TreasurerId);
            var cityAccountant = await PCityAccountant.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.CityAccountantId);
            var cityBudgetOfficer = await PCityBudgetOfficer.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.CityBudgetOfficerId);

            return Get(type, cutOff, humanResourceHead, mayor, treasurer, cityAccountant, cityBudgetOfficer, reader);
        }

        private async Task<IPayroll> GetAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var type = await PType.TryGetValueFromProcessAsync(_PayrollTypeManager.GetByIdAsync, reader.GetInt16, _Fields.TypeId, cancellationToken);
            var cutOff = await PCutOff.TryGetValueFromProcessAsync(_PayrollCutOffManager.GetByIdAsync, reader.GetInt16, _Fields.CutOffId, cancellationToken);
            var humanResourceHead = await PHumanResourceHead.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.HumanResourceHeadId, cancellationToken);
            var mayor = await PMayor.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.MayorId, cancellationToken);
            var treasurer = await PTreasurer.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.TreasurerId, cancellationToken);
            var cityAccountant = await PCityAccountant.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.CityAccountantId, cancellationToken);
            var cityBudgetOfficer = await PCityBudgetOfficer.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64, _Fields.CityBudgetOfficerId, cancellationToken);

            return Get(type, cutOff, humanResourceHead, mayor, treasurer, cityAccountant, cityBudgetOfficer, reader);
        }

        public IEnumerableProcessResult<IPayroll> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IPayroll>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IPayroll>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayroll>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayroll>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IPayroll>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetAsync(reader));
                }

                return new EnumerableProcessResult<IPayroll>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayroll>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayroll>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IPayroll>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IPayroll>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayroll>(ex);
            }
        }

        public IProcessResult<IPayroll> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IPayroll>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayroll>(ex);
            }
        }

        public async Task<IProcessResult<IPayroll>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IPayroll>(await GetAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayroll>(ex);
            }
        }

        public async Task<IProcessResult<IPayroll>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IPayroll>(await GetAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayroll>(ex);
            }
        }
    }
}
