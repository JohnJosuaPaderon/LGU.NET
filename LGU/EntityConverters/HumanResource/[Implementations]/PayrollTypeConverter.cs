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
    public sealed class PayrollTypeConverter : IPayrollTypeConverter<SqlDataReader>
    {
        private const string FIELD_ID = "Id";
        private const string FIELD_DESCRIPTION = "Description";

        private IPayrollType Get(SqlDataReader reader)
        {
            return new PayrollType
            {
                Id = reader.GetInt16(FIELD_ID),
                Description = reader.GetString(FIELD_DESCRIPTION)
            };
        }

        public IEnumerableProcessResult<IPayrollType> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IPayrollType>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IPayrollType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayrollType>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IPayrollType>();

                while (await reader.ReadAsync())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IPayrollType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPayrollType>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IPayrollType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IPayrollType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPayrollType>(ex);
            }
        }

        public IProcessResult<IPayrollType> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IPayrollType>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollType>(ex);
            }
        }

        public async Task<IProcessResult<IPayrollType>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IPayrollType>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollType>(ex);
            }
        }

        public async Task<IProcessResult<IPayrollType>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IPayrollType>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPayrollType>(ex);
            }
        }
    }
}
