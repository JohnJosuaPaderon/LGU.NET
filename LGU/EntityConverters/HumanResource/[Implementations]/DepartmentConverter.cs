using LGU.Data.Extensions;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Extensions;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public class DepartmentConverter : IDepartmentConverter
    {
        public DepartmentConverter(IDepartmentFields fields, IDepartmentHeadManager departmentHeadManager)
        {
            _Fields = fields;
            _DepartmentHeadManager = departmentHeadManager;

            PId = new DataConverterProperty<int>();
            PDescription = new DataConverterProperty<string>();
            PAbbreviation = new DataConverterProperty<string>();
            PHead = new DataConverterProperty<IDepartmentHead>();
        }

        private readonly IDepartmentFields _Fields;
        private readonly IDepartmentHeadManager _DepartmentHeadManager;

        public IDataConverterProperty<int> PId { get; }
        public IDataConverterProperty<string> PDescription { get; }
        public IDataConverterProperty<string> PAbbreviation { get; }
        public IDataConverterProperty<IDepartmentHead> PHead { get; }

        private IDepartment Get(IDepartmentHead head, DbDataReader reader)
        {
            return new Department()
            {
                Id = PId.TryGetValue(reader.GetInt32, _Fields.Id),
                Description = PDescription.TryGetValue(reader.GetString, _Fields.Description),
                Abbreviation = PAbbreviation.TryGetValue(reader.GetString, _Fields.Abbreviation),
                Head = head
            };
        }

        private IDepartment Get(DbDataReader reader)
        {
            var head = PHead.TryGetValueFromProcess(_DepartmentHeadManager.GetById, reader.GetInt64, _Fields.HeadId);
            return Get(head, reader);
        }

        private async Task<IDepartment> GetAsync(DbDataReader reader)
        {
            var head = await PHead.TryGetValueFromProcessAsync(_DepartmentHeadManager.GetByIdAsync, reader.GetInt64, _Fields.HeadId);
            return Get(head, reader);
        }

        private async Task<IDepartment> GetAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            var head = await PHead.TryGetValueFromProcessAsync(_DepartmentHeadManager.GetByIdAsync, reader.GetInt64, _Fields.HeadId, cancellationToken);
            return Get(head, reader);
        }

        public IEnumerableProcessResult<IDepartment> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IDepartment>();

                while (reader.Read())
                {
                    list.Add(Get(reader));
                }

                return new EnumerableProcessResult<IDepartment>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDepartment>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDepartment>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IDepartment>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetAsync(reader));
                }

                return new EnumerableProcessResult<IDepartment>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDepartment>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDepartment>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IDepartment>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IDepartment>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDepartment>(ex);
            }

        }

        public IProcessResult<IDepartment> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IDepartment>(Get(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDepartment>(ex);
            }
        }

        public async Task<IProcessResult<IDepartment>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IDepartment>(await GetAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDepartment>(ex);
            }
        }

        public async Task<IProcessResult<IDepartment>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IDepartment>(await GetAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDepartment>(ex);
            }
        }
    }
}
