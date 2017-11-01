using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class PayrollCutOffConverter : IPayrollCutOffConverter
    {
        private const string FIELD_ID = "Id";
        private const string FIELD_COUNT = "Count";
        private const string FIELD_DESCRIPTION = "Description";

        private IPayrollCutOff Get(DbDataReader reader)
        {
            return new PayrollCutOff()
            {
                Id = reader.GetInt16(FIELD_ID),
                Count = reader.GetInt32(FIELD_COUNT),
                Description = reader.GetString(FIELD_DESCRIPTION)
            };
        }

        public IEnumerableProcessResult<IPayrollCutOff> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IPayrollCutOff>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IPayrollCutOff>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollCutOff>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayrollCutOff>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IPayrollCutOff>();

                while (await reader.ReadAsync())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IPayrollCutOff>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollCutOff>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayrollCutOff>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IPayrollCutOff>();

                while (await reader.ReadAsync())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IPayrollCutOff>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollCutOff>(ex);
            }
        }

        public IProcessResult<IPayrollCutOff> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IPayrollCutOff>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollCutOff>(ex);
            }
        }

        public async Task<IProcessResult<IPayrollCutOff>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IPayrollCutOff>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollCutOff>(ex);
            }
        }

        public async Task<IProcessResult<IPayrollCutOff>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IPayrollCutOff>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollCutOff>(ex);
            }
        }

        public void InitializeDependency()
        {
            // TODO: Initialize Entity Managers
        }
    }
}
