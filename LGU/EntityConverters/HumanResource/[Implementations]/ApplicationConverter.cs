﻿using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ApplicationConverter : IApplicationConverter
    {
        private IApplicantManager ApplicantManager;
        private IApplicationStatusManager ApplicationStatusManager;
        private IPositionManager PositionManager;

        private IApplication GetData(IApplicant applicant, IApplicationStatus status, IPosition applyingPosition, DbDataReader reader)
        {
            if (applicant != null)
            {
                return new Application(applicant)
                {
                    Id = reader.GetInt64("Id"),
                    Status = status,
                    Date = reader.GetDateTime("Date"),
                    ApplyingPosition = applyingPosition
                };
            }
            else
            {
                return null;
            }
        }

        private IApplication GetData(DbDataReader reader)
        {
            var applicantResult = ApplicantManager.GetById(reader.GetInt64("ApplicantId"));
            var statusResult = ApplicationStatusManager.GetById(reader.GetInt16("StatusId"));
            var applyingPositionResult = PositionManager.GetById(reader.GetInt16("ApplyingPositionId"));

            return GetData(applicantResult.Data, statusResult.Data, applyingPositionResult.Data, reader);
        }

        private async Task<IApplication> GetDataAsync(DbDataReader reader)
        {
            var applicantResult = await ApplicantManager.GetByIdAsync(reader.GetInt64("ApplicantId"));
            var statusResult = await ApplicationStatusManager.GetByIdAsync(reader.GetInt16("StatusId"));
            var applyingPositionResult = await PositionManager.GetByIdAsync(reader.GetInt16("ApplyingPositionId"));

            return GetData(applicantResult.Data, statusResult.Data, applyingPositionResult.Data, reader);
        }

        private async Task<IApplication> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var applicantResult = await ApplicantManager.GetByIdAsync(reader.GetInt64("ApplicantId"), cancellationToken);
            var statusResult = await ApplicationStatusManager.GetByIdAsync(reader.GetInt16("StatusId"), cancellationToken);
            var applyingPositionResult = await PositionManager.GetByIdAsync(reader.GetInt16("ApplyingPositionId"), cancellationToken);

            return GetData(applicantResult.Data, statusResult.Data, applyingPositionResult.Data, reader);
        }

        public IEnumerableProcessResult<IApplication> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IApplication>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplication>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplication>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplication>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IApplication>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplication>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplication>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplication>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IApplication>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplication>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplication>(ex);
            }
        }

        public IProcessResult<IApplication> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IApplication>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplication>(ex);
            }
        }

        public async Task<IProcessResult<IApplication>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IApplication>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplication>(ex);
            }
        }

        public async Task<IProcessResult<IApplication>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IApplication>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplication>(ex);
            }
        }

        public void InitializeDependency()
        {
            ApplicantManager = ApplicationDomain.GetService<IApplicantManager>();
            ApplicationStatusManager = ApplicationDomain.GetService<IApplicationStatusManager>();
            PositionManager = ApplicationDomain.GetService<IPositionManager>();
        }
    }
}
