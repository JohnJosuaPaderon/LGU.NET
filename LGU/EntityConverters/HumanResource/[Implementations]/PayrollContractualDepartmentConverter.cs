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
    public sealed class PayrollContractualDepartmentConverter : IPayrollContractualDepartmentConverter
    {
        public PayrollContractualDepartmentConverter(
            IPayrollContractualDepartmentFields fields,
            IDepartmentManager departmentManager,
            IDepartmentHeadManager departmentHeadManager)
        {
            _Fields = fields;
            _DepartmentManager = departmentManager;
            _DepartmentHeadManager = departmentHeadManager;

            PDepartment = new DataConverterProperty<IDepartment>();
            PPayroll = new DataConverterProperty<IPayrollContractual>();
            PHead = new DataConverterProperty<IDepartmentHead>();
            POrdinal = new DataConverterProperty<int>();
        }

        private readonly IPayrollContractualDepartmentFields _Fields;
        private readonly IDepartmentManager _DepartmentManager;
        private readonly IDepartmentHeadManager _DepartmentHeadManager;

        public IDataConverterProperty<IDepartment> PDepartment { get; }
        public IDataConverterProperty<IPayrollContractual> PPayroll { get; }
        public IDataConverterProperty<IDepartmentHead> PHead { get; }
        public IDataConverterProperty<int> POrdinal { get; }
        public IEnumerableProcess<IPayrollContractualEmployee> GetEmployees { get; set; }
        public Action<(IDepartment Department, IDepartmentHead Head)> GetEmployeesInitializer { get; set; } 

        private IPayrollContractualDepartment Get(
            IDepartment department,
            IPayrollContractual payroll,
            IDepartmentHead head,
            IEnumerableProcessResult<IPayrollContractualEmployee> employeesResult,
            DbDataReader reader)
        {
            var value = new PayrollContractualDepartment()
            {
                Department = department,
                Payroll = payroll,
                Head = head,
                Ordinal = POrdinal.TryGetValue(reader.GetInt32, _Fields.Ordinal)
            };

            if (employeesResult.Status == ProcessResultStatus.Success && employeesResult.DataList != null)
            {
                value.Employees.AddRange(employeesResult.DataList);
            }

            return value;
        }

        private IPayrollContractualDepartment Get(DbDataReader reader)
        {
            var department = PDepartment.TryGetValueFromProcess(_DepartmentManager.GetById, reader.GetInt32, _Fields.DepartmentId);
            var head = PHead.TryGetValueFromProcess(_DepartmentHeadManager.GetById, reader.GetInt64, _Fields.HeadId);

            GetEmployeesInitializer?.Invoke((department, head));
            return Get(department, null, head, GetEmployees?.Execute(), reader);
        }

        private async Task<IPayrollContractualDepartment> GetAsync(DbDataReader reader)
        {
            var department = await PDepartment.TryGetValueFromProcessAsync(_DepartmentManager.GetByIdAsync, reader.GetInt32, _Fields.DepartmentId);
            var head = await PHead.TryGetValueFromProcessAsync(_DepartmentHeadManager.GetByIdAsync, reader.GetInt64, _Fields.HeadId);

            GetEmployeesInitializer?.Invoke((department, head));
            return Get(department, null, head, await GetEmployees?.ExecuteAsync(), reader);
        }

        private async Task<IPayrollContractualDepartment> GetAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var department = await PDepartment.TryGetValueFromProcessAsync(_DepartmentManager.GetByIdAsync, reader.GetInt32, _Fields.DepartmentId, cancellationToken);
            var head = await PHead.TryGetValueFromProcessAsync(_DepartmentHeadManager.GetByIdAsync, reader.GetInt64, _Fields.HeadId, cancellationToken);

            GetEmployeesInitializer?.Invoke((department, head));
            return Get(department, null, head, await GetEmployees?.ExecuteAsync(cancellationToken), reader);
        }

        public IEnumerableProcessResult<IPayrollContractualDepartment> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IPayrollContractualDepartment>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IPayrollContractualDepartment>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollContractualDepartment>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayrollContractualDepartment>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IPayrollContractualDepartment>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetAsync(reader));
                }

                return new EnumerableProcessResult<IPayrollContractualDepartment>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollContractualDepartment>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayrollContractualDepartment>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IPayrollContractualDepartment>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IPayrollContractualDepartment>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollContractualDepartment>(ex);
            }
        }

        public IProcessResult<IPayrollContractualDepartment> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IPayrollContractualDepartment>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollContractualDepartment>(ex);
            }
        }

        public async Task<IProcessResult<IPayrollContractualDepartment>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IPayrollContractualDepartment>(await GetAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollContractualDepartment>(ex);
            }
        }

        public async Task<IProcessResult<IPayrollContractualDepartment>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IPayrollContractualDepartment>(await GetAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollContractualDepartment>(ex);
            }
        }
    }
}
