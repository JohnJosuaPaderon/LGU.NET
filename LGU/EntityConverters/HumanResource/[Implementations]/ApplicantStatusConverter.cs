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
    public sealed class ApplicantStatusConverter : IApplicantStatusConverter
    {
        private IApplicantStatus GetData(DbDataReader reader)
        {
            return new ApplicantStatus()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IApplicantStatus> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IApplicantStatus>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplicantStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicantStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplicantStatus>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IApplicantStatus>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplicantStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicantStatus>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplicantStatus>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IApplicantStatus>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplicantStatus>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicantStatus>(ex);
            }
        }

        public IProcessResult<IApplicantStatus> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IApplicantStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicantStatus>(ex);
            }
        }

        public async Task<IProcessResult<IApplicantStatus>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IApplicantStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicantStatus>(ex);
            }
        }

        public async Task<IProcessResult<IApplicantStatus>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IApplicantStatus>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicantStatus>(ex);
            }
        }

        public void InitializeDependency()
        {
            // TODO: Initialize Entity Managers
        }
    }
}
