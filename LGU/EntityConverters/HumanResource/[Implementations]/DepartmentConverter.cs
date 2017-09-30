using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public class DepartmentConverter : IDepartmentConverter<SqlDataReader>
    {
        private const string FIELD_ID = "Id";
        private const string FIELD_DESCRIPTION = "Description";
        private const string FIELD_ABBREVIATION = "Abbreviation";
        private const string FIELD_HEAD_ID = "HeadId";

        public DepartmentConverter(IDepartmentHeadManager departmentHeadManager)
        {
            r_DepartmentHeadManager = departmentHeadManager;

            Prop_Id = new DataConverterProperty<int>();
            Prop_Description = new DataConverterProperty<string>();
            Prop_Abbreviation = new DataConverterProperty<string>();
            Prop_Head = new DataConverterProperty<IDepartmentHead>();
        }

        private readonly IDepartmentHeadManager r_DepartmentHeadManager;

        public IDataConverterProperty<int> Prop_Id { get; }
        public IDataConverterProperty<string> Prop_Description { get; }
        public IDataConverterProperty<string> Prop_Abbreviation { get; }
        public IDataConverterProperty<IDepartmentHead> Prop_Head { get; }

        private IDepartment GetData(IDepartmentHead head, SqlDataReader reader)
        {
            return new Department()
            {
                Id = Prop_Id.TryGetValue(reader.GetInt32, FIELD_ID),
                Description = Prop_Description.TryGetValue(reader.GetString, FIELD_DESCRIPTION),
                Abbreviation = Prop_Abbreviation.TryGetValue(reader.GetString, FIELD_ABBREVIATION),
                Head = head
            };
        }

        private IDepartment GetData(SqlDataReader reader)
        {
            var head = Prop_Head.TryGetValueFromProcess(r_DepartmentHeadManager.GetById, reader.GetInt64(FIELD_HEAD_ID));
            return GetData(head, reader);
        }

        public IEnumerableProcessResult<IDepartment> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IDepartment>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDepartment>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDepartment>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDepartment>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IDepartment>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDepartment>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDepartment>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDepartment>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IDepartment>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDepartment>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDepartment>(ex);
            }

        }

        public IProcessResult<IDepartment> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IDepartment>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDepartment>(ex);
            }
        }

        public async Task<IProcessResult<IDepartment>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IDepartment>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDepartment>(ex);
            }
        }

        public async Task<IProcessResult<IDepartment>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IDepartment>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDepartment>(ex);
            }
        }
    }
}
