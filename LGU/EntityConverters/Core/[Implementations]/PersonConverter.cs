using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.EntityManagers.Core;
using LGU.Extensions;
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
        private const string FIELD_ID = "Id";
        private const string FIELD_FIRST_NAME = "FirstName";
        private const string FIELD_MIDDLE_NAME = "MiddleName";
        private const string FIELD_LAST_NAME = "LastName";
        private const string FIELD_NAME_EXTENSION = "NameExtension";
        private const string FIELD_GENDER_ID = "GenderId";
        private const string FIELD_BIRTH_DATE = "BirthDate";
        private const string FIELD_DECEASED = "Deceased";

        public PersonConverter(IGenderManager genderManager)
        {
            r_GenderManager = genderManager;

            Prop_Id = new DataConverterProperty<long>();
            Prop_FirstName = new DataConverterProperty<string>();
            Prop_MiddleName = new DataConverterProperty<string>();
            Prop_LastName = new DataConverterProperty<string>();
            Prop_NameExtension = new DataConverterProperty<string>();
        }

        private readonly IGenderManager r_GenderManager;

        public IDataConverterProperty<long> Prop_Id { get; }
        public IDataConverterProperty<string> Prop_FirstName { get; }
        public IDataConverterProperty<string> Prop_MiddleName { get; }
        public IDataConverterProperty<string> Prop_LastName { get; }
        public IDataConverterProperty<string> Prop_NameExtension { get; }
        public IDataConverterProperty<string> Prop_MiddleInitials { get; }
        public IDataConverterProperty<DateTime?> Prop_BirthDate { get; }
        public IDataConverterProperty<IGender> Prop_Gender { get; }
        public IDataConverterProperty<bool> Prop_Deceased { get; }

        private IPerson GetData(IGender gender, SqlDataReader reader)
        {
            return new Person()
            {
                Id = Prop_Id.TryGetValue(reader.GetInt64, FIELD_ID),
                FirstName = Prop_FirstName.TryGetValue(reader.GetString, FIELD_FIRST_NAME),
                MiddleName = Prop_MiddleName.TryGetValue(reader.GetString, FIELD_MIDDLE_NAME),
                LastName = Prop_LastName.TryGetValue(reader.GetString, FIELD_LAST_NAME),
                NameExtension = Prop_NameExtension.TryGetValue(reader.GetString, FIELD_NAME_EXTENSION),
                Gender = gender,
                BirthDate = Prop_BirthDate.TryGetValue(reader.GetNullableDateTime, FIELD_BIRTH_DATE),
                Deceased = Prop_Deceased.TryGetValue(reader.GetBoolean, FIELD_DECEASED)
            };
        }

        private IPerson GetData(SqlDataReader reader)
        {
            var gender = Prop_Gender.TryGetValueFromProcess(r_GenderManager.GetById, reader.GetInt16, FIELD_GENDER_ID) ;
            return GetData(gender, reader);
        }

        private async Task<IPerson> GetDataAsync(SqlDataReader reader)
        {
            var gender = await Prop_Gender.TryGetValueFromProcessAsync(r_GenderManager.GetByIdAsync, reader.GetInt16, FIELD_GENDER_ID);
            return GetData(gender, reader);
        }

        private async Task<IPerson> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var gender = await Prop_Gender.TryGetValueFromProcessAsync(r_GenderManager.GetByIdAsync, reader.GetInt16, FIELD_GENDER_ID, cancellationToken);
            return GetData(gender, reader);
        }

        public IProcessResult<IPerson> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IPerson>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPerson>(ex);
            }
        }

        public async Task<IProcessResult<IPerson>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IPerson>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPerson>(ex);
            }
        }

        public async Task<IProcessResult<IPerson>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IPerson>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IPerson>(ex);
            }
        }

        public IEnumerableProcessResult<IPerson> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IPerson>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IPerson>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPerson>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IPerson>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IPerson>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IPerson>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPerson>(ex);
            }
        }

        public  async Task<IEnumerableProcessResult<IPerson>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IPerson>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IPerson>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IPerson>(ex);
            }
        }
    }
}
