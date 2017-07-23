using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class ModuleConverter : IModuleConverter<SqlDataReader>
    {
        private Module GetData(SqlDataReader reader)
        {
            return new Module()
            {
                Id = reader.GetInt16("Id"),
                Name = reader.GetString("Name")
            };
        }

        public IEnumerableProcessResult<Module> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<Module>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Module>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Module>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Module>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<Module>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Module>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Module>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<Module>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<Module>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<Module>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<Module>(ex);
            }
        }

        public IProcessResult<Module> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<Module>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Module>(ex);
            }
        }

        public async Task<IProcessResult<Module>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<Module>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Module>(ex);
            }
        }

        public async Task<IProcessResult<Module>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<Module>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<Module>(ex);
            }
        }
    }
}
