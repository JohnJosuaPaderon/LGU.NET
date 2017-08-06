using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.EntityManagers.Core;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class PersonConverter : IPersonConverter<SqlDataReader>
    {
        private readonly IGenderManager r_GenderManager;

        public PersonConverter(IGenderManager genderManager)
        {
            r_GenderManager = genderManager;
        }

        private Person GetData(Gender gender, SqlDataReader reader)
        {
            return new Person()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                Gender = gender,
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Deceased = reader.GetBoolean("Deceased")
            };
        }

        private Person GetData(SqlDataReader reader)
        {
            var genderResult = r_GenderManager.GetById(reader.GetInt16("GenderId"));

            return GetData(genderResult.Data, reader);
        }

        private async Task<Person> GetDataAsync(SqlDataReader reader)
        {
            var genderResult = await r_GenderManager.GetByIdAsync(reader.GetInt16("GenderId"));

            return GetData(genderResult.Data, reader);
        }

        private async Task<Person> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var genderResult = await r_GenderManager.GetByIdAsync(reader.GetInt16("GenderId"), cancellationToken);

            return GetData(genderResult.Data, reader);
        }

        public IProcessResult<Person> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<Person>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Person>(ex);
            }
        }

        public async Task<IProcessResult<Person>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<Person>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Person>(ex);
            }
        }

        public async Task<IProcessResult<Person>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<Person>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Person>(ex);
            }
        }

        public IEnumerableProcessResult<Person> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Person>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Person>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Person>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Person>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Person>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<Person>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Person>(ex);
            }
        }

        public  async Task<IEnumerableProcessResult<Person>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Person>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<Person>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Person>(ex);
            }
        }
    }
}
