using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.EntityManagers.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcessHelpers.Core
{
    internal static class PersonProcessHelper
    {
        static PersonProcessHelper()
        {
            GenderManager = SystemRuntime.Services.GetService<IGenderManager>();
        }

        private static readonly IGenderManager GenderManager;

        private static Person GetData(SqlDataReader reader)
        {
            var genderResult = GenderManager.GetById(reader.GetInt16("GenderId"));

            return new Person()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                Gender = genderResult.Data,
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Deceased = reader.GetBoolean("Deceased")
            };
        }

        private static async Task<Person> GetDataAsync(SqlDataReader reader)
        {
            var genderResult = await GenderManager.GetByIdAsync(reader.GetInt16("GenderId"));

            return new Person()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                Gender = genderResult.Data,
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Deceased = reader.GetBoolean("Deceased")
            };
        }

        private static async Task<Person> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var genderResult = await GenderManager.GetByIdAsync(reader.GetInt16("GenderId"), cancellationToken);

            return new Person()
            {
                Id = reader.GetInt64("Id"),
                FirstName = reader.GetString("FirstName"),
                MiddleName = reader.GetString("MiddleName"),
                LastName = reader.GetString("LastName"),
                NameExtension = reader.GetString("NameExtension"),
                Gender = genderResult.Data,
                BirthDate = reader.GetNullableDateTime("BirthDate"),
                Deceased = reader.GetBoolean("Deceased")
            };
        }

        public static IDataProcessResult<Person> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new DataProcessResult<Person>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<Person>(ex);
            }
        }

        public static async Task<IDataProcessResult<Person>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new DataProcessResult<Person>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<Person>(ex);
            }
        }

        public static async Task<IDataProcessResult<Person>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new DataProcessResult<Person>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new DataProcessResult<Person>(ex);
            }
        }

        public static IEnumerableDataProcessResult<Person> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Person>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableDataProcessResult<Person>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<Person>(ex);
            }
        }

        public static async Task<IEnumerableDataProcessResult<Person>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Person>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableDataProcessResult<Person>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<Person>(ex);
            }
        }

        public static async Task<IEnumerableDataProcessResult<Person>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Person>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableDataProcessResult<Person>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableDataProcessResult<Person>(ex);
            }
        }
    }
}
