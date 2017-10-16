using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class PayrollContractualDepartmentConverter : IPayrollContractualDepartmentConverter
    {
        public PayrollContractualDepartmentConverter(
            IPayrollContractualDepartmentFields fields,
            IDepartmentManager departmentManager,
            IPayrollManager<SqlConnection, SqlTransaction> payrollManager,
            IEmployeeManager employeeManager)
        {
            _Fields = fields;
            _DepartmentManager = departmentManager;
            _PayrollManager = payrollManager;
            _EmployeeManager = employeeManager;

            PDepartment = new DataConverterProperty<IDepartment>();
            PPayroll = new DataConverterProperty<IPayroll>();
            PHead = new DataConverterProperty<IEmployee>();
            POrdinal = new DataConverterProperty<int>();
        }

        private readonly IPayrollContractualDepartmentFields _Fields;
        private readonly IDepartmentManager _DepartmentManager;
        private readonly IPayrollManager<SqlConnection, SqlTransaction> _PayrollManager;
        private readonly IEmployeeManager _EmployeeManager;

        public IDataConverterProperty<IDepartment> PDepartment { get; }
        public IDataConverterProperty<IPayroll> PPayroll { get; }
        public IDataConverterProperty<IEmployee> PHead { get; }
        public IDataConverterProperty<int> POrdinal { get; }

        private IPayrollContractualDepartment Get(
            IDepartment department,
            IPayroll payroll,
            IEmployee head,
            IEnumerable<IPayrollContractualEmployee> employees)
        {
            return new PayrollContractualDepartment()
            {
                Department = department,
                Payroll = payroll,
                Head = head,
                Employees = employees
            };
        }
        
        //private IPayrollContractualDepartment Get(DbDataReader reader)
        //{
        //    var department = PDepartment.TryGetValueFromProcess(_DepartmentManager.GetById, reader.GetInt32, _Fields.DepartmentId);
        //    var payroll = PPayroll.TryGetValueFromProcess(_PayrollManager.GetById, reader.GetInt64, _Fields.PayrollId);
        //    var head = PHead.TryGetValueFromProcess(_EmployeeManager.GetById, reader.GetInt64, _Fields.HeadId);
        //}

        public IEnumerableProcessResult<IPayrollContractualDepartment> EnumerableFromReader(DbDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<IPayrollContractualDepartment>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<IPayrollContractualDepartment>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<IPayrollContractualDepartment> FromReader(DbDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<IPayrollContractualDepartment>> FromReaderAsync(DbDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<IPayrollContractualDepartment>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
