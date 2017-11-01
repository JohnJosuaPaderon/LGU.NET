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
    public sealed class ApplicationStatusConverter : IApplicationStatusConverter
    {
        private IApplicationStatus GetData(DbDataReader reader)
        {
            return new ApplicationStatus()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IApplicationStatus> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IApplicationStatus>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplicationStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicationStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplicationStatus>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IApplicationStatus>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplicationStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicationStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplicationStatus>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IApplicationStatus>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplicationStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicationStatus>(ex);
            }
        }

        public IProcessResult<IApplicationStatus> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IApplicationStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicationStatus>(ex);
            }
        }

        public async Task<IProcessResult<IApplicationStatus>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IApplicationStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicationStatus>(ex);
            }
        }

        public async Task<IProcessResult<IApplicationStatus>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IApplicationStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicationStatus>(ex);
            }
        }

        public void InitializeDependency()
        {
            // TODO: Initialize Entity Managers
        }
    }
}
