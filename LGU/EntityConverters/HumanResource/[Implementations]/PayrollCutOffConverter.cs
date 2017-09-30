using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class PayrollCutOffConverter : IPayrollCutOffConverter<SqlDataReader>
    {
        private const string FIELD_ID = "Id";
        private const string FIELD_COUNT = "Count";
        private const string FIELD_DESCRIPTION = "Description";

        private IPayrollCutOff Get(SqlDataReader reader)
        {
            return new PayrollCutOff()
            {
                Id = reader.GetInt16(FIELD_ID),
                Count = reader.GetInt32(FIELD_COUNT),
                Description = reader.GetString(FIELD_DESCRIPTION)
            };
        }

        public IEnumerableProcessResult<IPayrollCutOff> EnumerableFromReader(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<IPayrollCutOff>> EnumerableFromReaderAsync(SqlDataReader reader)
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

        public async Task<IEnumerableProcessResult<IPayrollCutOff>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IPayrollCutOff> FromReader(SqlDataReader reader)
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

        public async Task<IProcessResult<IPayrollCutOff>> FromReaderAsync(SqlDataReader reader)
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

        public async Task<IProcessResult<IPayrollCutOff>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
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
    }
}
