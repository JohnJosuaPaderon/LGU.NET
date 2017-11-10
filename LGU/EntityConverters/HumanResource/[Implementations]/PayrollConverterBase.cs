using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public abstract class PayrollConverterBase<T> : IPayrollConverter<T>
        where T : IPayroll
    {
        public PayrollConverterBase(
            IDbDataReaderToProcessResultConverter toProcessResultConverter,
            IDbDataReaderToEnumerableProcessResultConverter toEnumerableProcessResultConverter,
            IPayrollFields payrollFields)
        {
            _ToProcessResultConverter = toProcessResultConverter;
            _ToEnumerableProcessResultConverter = toEnumerableProcessResultConverter;
            _PayrollFields = payrollFields;

            PId = new DataConverterProperty<long>();
            PType = new DataConverterProperty<IPayrollType>();
            PCutOff = new DataConverterProperty<IPayrollCutOff>();
            PRangeDateBegin = new DataConverterProperty<DateTime>();
            PRangeDateEnd = new DataConverterProperty<DateTime>();
            PRunDate = new DataConverterProperty<DateTime>();
            PMayor = new DataConverterProperty<IEmployee>();
            PHumanResourceHead = new DataConverterProperty<IEmployee>();
            PTreasurer = new DataConverterProperty<IEmployee>();
            PCityAccountant = new DataConverterProperty<IEmployee>();
            PCityBudgetOfficer = new DataConverterProperty<IEmployee>();
        }

        protected readonly IPayrollFields _PayrollFields;
        protected readonly IDbDataReaderToProcessResultConverter _ToProcessResultConverter;
        protected readonly IDbDataReaderToEnumerableProcessResultConverter _ToEnumerableProcessResultConverter;

        public IDataConverterProperty<long> PId { get; }
        public IDataConverterProperty<IPayrollType> PType { get; }
        public IDataConverterProperty<IPayrollCutOff> PCutOff { get; }
        public IDataConverterProperty<DateTime> PRangeDateBegin { get; }
        public IDataConverterProperty<DateTime> PRangeDateEnd { get; }
        public IDataConverterProperty<DateTime> PRunDate { get; }
        public IDataConverterProperty<IEmployee> PMayor { get; }
        public IDataConverterProperty<IEmployee> PHumanResourceHead { get; }
        public IDataConverterProperty<IEmployee> PTreasurer { get; }
        public IDataConverterProperty<IEmployee> PCityAccountant { get; }
        public IDataConverterProperty<IEmployee> PCityBudgetOfficer { get; }

        private IPayrollTypeManager PayrollTypeManager;
        private IPayrollCutOffManager PayrollCutOffManager;
        private IEmployeeManager EmployeeManager;

        protected abstract T Get(IPayrollType type, IPayrollCutOff cutOff, IEmployee mayor, IEmployee humanResourceHead, IEmployee treasurer, IEmployee cityAccountant, IEmployee cityBudgetOfficer, DbDataReader reader);

        protected virtual T Get(DbDataReader reader)
        {
            var type = PType.TryGetValueFromProcess(PayrollTypeManager.GetById, reader.GetInt16, _PayrollFields.TypeId);
            var cutOff = PCutOff.TryGetValueFromProcess(PayrollCutOffManager.GetById, reader.GetInt16, _PayrollFields.CutOffId);
            var mayor = PMayor.TryGetValueFromProcess(EmployeeManager.GetById, reader.GetInt64, _PayrollFields.MayorId);
            var humanResourceHead = PHumanResourceHead.TryGetValueFromProcess(EmployeeManager.GetById, reader.GetInt64, _PayrollFields.HumanResourceHeadId);
            var treasurer = PTreasurer.TryGetValueFromProcess(EmployeeManager.GetById, reader.GetInt64, _PayrollFields.TreasurerId);
            var cityAccountant = PCityAccountant.TryGetValueFromProcess(EmployeeManager.GetById, reader.GetInt64, _PayrollFields.CityAccountantId);
            var cityBudgetOfficer = PCityBudgetOfficer.TryGetValueFromProcess(EmployeeManager.GetById, reader.GetInt64, _PayrollFields.CityBudgetOfficerId);

            return Get(type, cutOff, mayor, humanResourceHead, treasurer, cityAccountant, cityBudgetOfficer, reader);
        }

        protected virtual async Task<T> GetAsync(DbDataReader reader)
        {
            var type = await PType.TryGetValueFromProcessAsync(PayrollTypeManager.GetByIdAsync, reader.GetInt16, _PayrollFields.TypeId);
            var cutOff = await PCutOff.TryGetValueFromProcessAsync(PayrollCutOffManager.GetByIdAsync, reader.GetInt16, _PayrollFields.CutOffId);
            var mayor = await PMayor.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.MayorId);
            var humanResourceHead = await PHumanResourceHead.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.HumanResourceHeadId);
            var treasurer = await PTreasurer.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.TreasurerId);
            var cityAccountant = await PCityAccountant.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.CityAccountantId);
            var cityBudgetOfficer = await PCityBudgetOfficer.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.CityBudgetOfficerId);

            return Get(type, cutOff, mayor, humanResourceHead, treasurer, cityAccountant, cityBudgetOfficer, reader);
        }

        protected virtual async Task<T> CancellableGetAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var type = await PType.TryGetValueFromProcessAsync(PayrollTypeManager.GetByIdAsync, reader.GetInt16, _PayrollFields.TypeId, cancellationToken);
            var cutOff = await PCutOff.TryGetValueFromProcessAsync(PayrollCutOffManager.GetByIdAsync, reader.GetInt16, _PayrollFields.CutOffId, cancellationToken);
            var mayor = await PMayor.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.MayorId, cancellationToken);
            var humanResourceHead = await PHumanResourceHead.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.HumanResourceHeadId, cancellationToken);
            var treasurer = await PTreasurer.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.TreasurerId, cancellationToken);
            var cityAccountant = await PCityAccountant.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.CityAccountantId, cancellationToken);
            var cityBudgetOfficer = await PCityBudgetOfficer.TryGetValueFromProcessAsync(EmployeeManager.GetByIdAsync, reader.GetInt64, _PayrollFields.CityBudgetOfficerId, cancellationToken);

            return Get(type, cutOff, mayor, humanResourceHead, treasurer, cityAccountant, cityBudgetOfficer, reader);
        }

        public IEnumerableProcessResult<T> EnumerableFromReader(DbDataReader reader)
        {
            return _ToEnumerableProcessResultConverter.EnumerableFromReader(reader, Get);
        }

        public Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            return _ToEnumerableProcessResultConverter.EnumerableFromReaderAsync(reader, GetAsync);
        }

        public Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            return _ToEnumerableProcessResultConverter.EnumerableFromReaderAsync(reader, cancellationToken, CancellableGetAsync);
        }

        public IProcessResult<T> FromReader(DbDataReader reader)
        {
            return _ToProcessResultConverter.FromReader(reader, Get);
        }

        public Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader)
        {
            return _ToProcessResultConverter.FromReaderAsync(reader, GetAsync);
        }

        public Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            return _ToProcessResultConverter.FromReaderAsync(reader, cancellationToken, CancellableGetAsync);
        }

        public void InitializeDependency()
        {
            PayrollTypeManager = ApplicationDomain.GetService<IPayrollTypeManager>();
            PayrollCutOffManager = ApplicationDomain.GetService<IPayrollCutOffManager>();
            EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
        }
    }
}
