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
    public sealed class EmploymentStatusConverter : IEmploymentStatusConverter
    {
        private IEmploymentStatus GetData(DbDataReader reader)
        {
            return new EmploymentStatus()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IEmploymentStatus> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IEmploymentStatus>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmploymentStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmploymentStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmploymentStatus>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IEmploymentStatus>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmploymentStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmploymentStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IEmploymentStatus>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IEmploymentStatus>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IEmploymentStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IEmploymentStatus>(ex);
            }
        }

        public IProcessResult<IEmploymentStatus> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IEmploymentStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmploymentStatus>(ex);
            }
        }

        public async Task<IProcessResult<IEmploymentStatus>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IEmploymentStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmploymentStatus>(ex);
            }
        }

        public async Task<IProcessResult<IEmploymentStatus>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IEmploymentStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IEmploymentStatus>(ex);
            }
        }

        public void InitializeDependency()
        {
            // TODO: Initialize Entity Managers
        }
    }
}
