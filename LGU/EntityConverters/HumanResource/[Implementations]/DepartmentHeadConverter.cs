using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.Core;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class DepartmentHeadConverter : IDepartmentHeadConverter<SqlDataReader>
    {
        private readonly IGenderManager r_GenderManager;

        public DepartmentHeadConverter(IGenderManager genderManager)
        {
            r_GenderManager = genderManager;
        }

        private IDepartmentHead GetData(IGender gender, SqlDataReader reader)
        {
            return new DepartmentHead()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                Gender = gender,
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Deceased = reader.GetBoolean("Deceased"),
                Title = reader.GetString("Title")
            };
        }

        private IDepartmentHead GetData(SqlDataReader reader)
        {
            var genderResult = r_GenderManager.GetById(reader.GetInt16("GenderId"));
            return GetData(genderResult.Data, reader);
        }

        private async Task<IDepartmentHead> GetDataAsync(SqlDataReader reader)
        {
            var genderResult = await r_GenderManager.GetByIdAsync(reader.GetInt16("GenderId"));
            return GetData(genderResult.Data, reader);
        }

        private async Task<IDepartmentHead> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var genderResult = await r_GenderManager.GetByIdAsync(reader.GetInt16("GenderId"), cancellationToken);
            return GetData(genderResult.Data, reader);
        }

        public IEnumerableProcessResult<IDepartmentHead> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IDepartmentHead>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDepartmentHead>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDepartmentHead>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDepartmentHead>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IDepartmentHead>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDepartmentHead>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDepartmentHead>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDepartmentHead>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IDepartmentHead>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDepartmentHead>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDepartmentHead>(ex);
            }
        }

        public IProcessResult<IDepartmentHead> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IDepartmentHead>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDepartmentHead>(ex);
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IDepartmentHead>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDepartmentHead>(ex);
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IDepartmentHead>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDepartmentHead>(ex);
            }
        }
    }
}
