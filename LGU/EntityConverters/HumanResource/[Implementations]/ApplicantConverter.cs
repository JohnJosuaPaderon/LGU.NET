﻿using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.Core;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ApplicantConverter : IApplicantConverter
    {
        private IGenderManager GenderManager;
        private IApplicantStatusManager ApplicantStatusManager;

        private IApplicant GetData(IGender gender, IApplicantStatus status, DbDataReader reader)
        {
            return new Applicant()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Gender = gender,
                Deceased = reader.GetBoolean("Deceased"),
                Status = status,
                ContactNumber = reader.GetString("ContactNumber")
            };
        }

        private IApplicant GetData(DbDataReader reader)
        {
            var genderResult = GenderManager.GetById(reader.GetInt16("GenderId"));
            var statusResult = ApplicantStatusManager.GetById(reader.GetInt16("StatusId"));

            return GetData(genderResult.Data, statusResult.Data, reader);
        }

        private async Task<IApplicant> GetDataAsync(DbDataReader reader)
        {
            var genderResult = await GenderManager.GetByIdAsync(reader.GetInt16("GenderId"));
            var statusResult = await ApplicantStatusManager.GetByIdAsync(reader.GetInt16("StatusId"));

            return GetData(genderResult.Data, statusResult.Data, reader);
        }

        private async Task<IApplicant> GetDataAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var genderResult = await GenderManager.GetByIdAsync(reader.GetInt16("GenderId"), cancellationToken);
            var statusResult = await ApplicantStatusManager.GetByIdAsync(reader.GetInt16("StatusId"), cancellationToken);

            return GetData(genderResult.Data, statusResult.Data, reader);
        }

        public IEnumerableProcessResult<IApplicant> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IApplicant>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplicant>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicant>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplicant>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IApplicant>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IApplicant>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicant>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplicant>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IApplicant>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IApplicant>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicant>(ex);
            }
        }

        public IProcessResult<IApplicant> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IApplicant>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicant>(ex);
            }
        }

        public async Task<IProcessResult<IApplicant>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IApplicant>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicant>(ex);
            }
        }

        public async Task<IProcessResult<IApplicant>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IApplicant>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicant>(ex);
            }
        }

        public void InitializeDependency()
        {
            GenderManager = ApplicationDomain.GetService<IGenderManager>();
            ApplicantStatusManager = ApplicationDomain.GetService<IApplicantStatusManager>();
        }
    }
}
