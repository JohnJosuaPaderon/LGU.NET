using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
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
        private readonly IDepartmentHeadManager r_DepartmentHeadManager;

        public DepartmentConverter(IDepartmentHeadManager departmentHeadManager)
        {
            r_DepartmentHeadManager = departmentHeadManager;
        }

        private IDepartment GetData(IDepartmentHead head, SqlDataReader reader)
        {
            return new Department()
            {
                Id = reader.GetInt32("Id"),
                Description = reader.GetString("Description"),
                Abbreviation = reader.GetString("Abbreviation"),
                Head = head
            };
        }

        private IDepartment GetData(SqlDataReader reader)
        {
            var headResult = r_DepartmentHeadManager.GetById(reader.GetInt64("HeadId"));
            return GetData(headResult.Data, reader);
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
