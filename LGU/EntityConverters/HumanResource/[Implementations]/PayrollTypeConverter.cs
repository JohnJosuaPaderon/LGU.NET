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
    public sealed class PayrollTypeConverter : IPayrollTypeConverter
    {
        private const string FIELD_ID = "Id";
        private const string FIELD_DESCRIPTION = "Description";

        private IPayrollType Get(DbDataReader reader)
        {
            return new PayrollType
            {
                Id = reader.GetInt16(FIELD_ID),
                Description = reader.GetString(FIELD_DESCRIPTION)
            };
        }

        public IEnumerableProcessResult<IPayrollType> EnumerableFromReader(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IPayrollType>> EnumerableFromReaderAsync(DbDataReader reader)
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

        public async Task<IEnumerableProcessResult<IPayrollType>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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

        public IProcessResult<IPayrollType> FromReader(DbDataReader reader)
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

        public async Task<IProcessResult<IPayrollType>> FromReaderAsync(DbDataReader reader)
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

        public async Task<IProcessResult<IPayrollType>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
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
