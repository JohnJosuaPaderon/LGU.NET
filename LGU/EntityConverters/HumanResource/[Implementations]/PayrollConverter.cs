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
        private const string FIELD_ID = "Id";
        private const string FIELD_TYPE_ID = "TypeId";
        private const string FIELD_CUT_OFF_ID = "CutOffId";
        private const string FIELD_RANGE_DATE_BEGIN = "RangeDateBegin";
        private const string FIELD_RANGE_DATE_END = "RangeDateEnd";
        private const string FIELD_RUN_DATE = "RunDate";
        private const string FIELD_HUMAN_RESOURCE_HEAD_ID = "HumanResourceHeadId";
        private const string FIELD_MAYOR_ID = "MayorId";
        private const string FIELD_TREASURER_ID = "TreasurerId";
        private const string FIELD_CITY_ACCOUNTANT_ID = "CityAccountantId";
        private const string FIELD_CITY_BUDGET_OFFICER_ID = "CityBudgetOfficerId";

        public PayrollConverter(
            IPayrollTypeManager payrollTypeManager,
            IPayrollCutOffManager payrollCutOffManager,
            IEmployeeManager employeeManager)
        {
            _PayrollTypeManager = payrollTypeManager;
            _PayrollCutOffManager = payrollCutOffManager;
            _EmployeeManager = employeeManager;

            Prop_Id = new DataConverterProperty<long>();
            Prop_Type = new DataConverterProperty<IPayrollType>();
            Prop_CutOff = new DataConverterProperty<IPayrollCutOff>();
            Prop_RangeDate = new DataConverterProperty<ValueRange<DateTime>>();
            Prop_RunDate = new DataConverterProperty<DateTime>();
            Prop_HumanResourceHead = new DataConverterProperty<IEmployee>();
            Prop_Mayor = new DataConverterProperty<IEmployee>();
            Prop_Treasurer = new DataConverterProperty<IEmployee>();
            Prop_CityAccountant = new DataConverterProperty<IEmployee>();
            Prop_CityBudgetOfficer = new DataConverterProperty<IEmployee>();
        }

        private readonly IPayrollTypeManager _PayrollTypeManager;
        private readonly IPayrollCutOffManager _PayrollCutOffManager;
        private readonly IEmployeeManager _EmployeeManager;

        public IDataConverterProperty<long> Prop_Id { get; }
        public IDataConverterProperty<IPayrollType> Prop_Type { get; }
        public IDataConverterProperty<IPayrollCutOff> Prop_CutOff { get; }
        public IDataConverterProperty<ValueRange<DateTime>> Prop_RangeDate { get; }
        public IDataConverterProperty<DateTime> Prop_RunDate { get; }
        public IDataConverterProperty<IEmployee> Prop_HumanResourceHead { get; }
        public IDataConverterProperty<IEmployee> Prop_Mayor { get; }
        public IDataConverterProperty<IEmployee> Prop_Treasurer { get; }
        public IDataConverterProperty<IEmployee> Prop_CityAccountant { get; }
        public IDataConverterProperty<IEmployee> Prop_CityBudgetOfficer { get; }

        private IPayroll Get(IPayrollType type, IPayrollCutOff cutOff, IEmployee humanResourceHead, IEmployee mayor, IEmployee treasurer, IEmployee cityAccountant, IEmployee cityBudgetOfficer, SqlDataReader reader)
        {
            return new Payroll
            {
                Id = reader.GetInt64(FIELD_ID),
                Type = type,
                CutOff = cutOff,
                RangeDate = new ValueRange<DateTime>(
                    reader.GetDateTime(FIELD_RANGE_DATE_BEGIN),
                    reader.GetDateTime(FIELD_RANGE_DATE_END)),
                RunDate = reader.GetDateTime(FIELD_RUN_DATE),
                HumanResourceHead = humanResourceHead,
                Mayor = mayor,
                Treasurer = treasurer,
                CityAccountant = cityAccountant,
                CityBudgetOfficer = cityBudgetOfficer
            };
        }

        private IPayroll Get(SqlDataReader reader)
        {
            var type = Prop_Type.TryGetValueFromProcess(_PayrollTypeManager.GetById, reader.GetInt16(FIELD_TYPE_ID));
            var cutOff = Prop_CutOff.TryGetValueFromProcess(_PayrollCutOffManager.GetById, reader.GetInt16(FIELD_CUT_OFF_ID));
            var humanResourceHead = Prop_HumanResourceHead.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64(FIELD_HUMAN_RESOURCE_HEAD_ID));
            var mayor = Prop_Mayor.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64(FIELD_MAYOR_ID));
            var treasurer = Prop_Treasurer.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64(FIELD_TREASURER_ID));
            var cityAccountant = Prop_CityAccountant.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64(FIELD_CITY_ACCOUNTANT_ID));
            var cityBudgetOfficer = Prop_CityBudgetOfficer.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64(FIELD_CITY_BUDGET_OFFICER_ID));

            return Get(type, cutOff, humanResourceHead, mayor, treasurer, cityAccountant, cityBudgetOfficer, reader);
        }

        private async Task<IPayroll> GetAsync(SqlDataReader reader)
        {
            var type = await Prop_Type.TryGetValueFromProcessAsync(_PayrollTypeManager.GetByIdAsync, reader.GetInt16(FIELD_TYPE_ID));
            var cutOff = await Prop_CutOff.TryGetValueFromProcessAsync(_PayrollCutOffManager.GetByIdAsync, reader.GetInt16(FIELD_CUT_OFF_ID));
            var humanResourceHead = await Prop_HumanResourceHead.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_HUMAN_RESOURCE_HEAD_ID));
            var mayor = await Prop_Mayor.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_MAYOR_ID));
            var treasurer = await Prop_Treasurer.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_TREASURER_ID));
            var cityAccountant = await Prop_CityAccountant.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_CITY_ACCOUNTANT_ID));
            var cityBudgetOfficer = await Prop_CityBudgetOfficer.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_CITY_BUDGET_OFFICER_ID));

            return Get(type, cutOff, humanResourceHead, mayor, treasurer, cityAccountant, cityBudgetOfficer, reader);
        }

        private async Task<IPayroll> GetAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var type = await Prop_Type.TryGetValueFromProcessAsync(_PayrollTypeManager.GetByIdAsync, reader.GetInt16(FIELD_TYPE_ID), cancellationToken);
            var cutOff = await Prop_CutOff.TryGetValueFromProcessAsync(_PayrollCutOffManager.GetByIdAsync, reader.GetInt16(FIELD_CUT_OFF_ID), cancellationToken);
            var humanResourceHead = await Prop_HumanResourceHead.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_HUMAN_RESOURCE_HEAD_ID), cancellationToken);
            var mayor = await Prop_Mayor.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_MAYOR_ID), cancellationToken);
            var treasurer = await Prop_Treasurer.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_TREASURER_ID), cancellationToken);
            var cityAccountant = await Prop_CityAccountant.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_CITY_ACCOUNTANT_ID), cancellationToken);
            var cityBudgetOfficer = await Prop_CityBudgetOfficer.TryGetValueFromProcessAsync(_EmployeeManager.GetByIdAsync, reader.GetInt64(FIELD_CITY_BUDGET_OFFICER_ID), cancellationToken);

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
