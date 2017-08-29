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
        private IModule GetData(SqlDataReader reader)
        {
            return new Module()
            {
                Id = reader.GetInt16("Id"),
                Name = reader.GetString("Name")
            };
        }

        public IEnumerableProcessResult<IModule> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IModule>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IModule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IModule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IModule>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IModule>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IModule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IModule>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IModule>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IModule>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IModule>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IModule>(ex);
            }
        }

        public IProcessResult<IModule> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IModule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IModule>(ex);
            }
        }

        public async Task<IProcessResult<IModule>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IModule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IModule>(ex);
            }
        }

        public async Task<IProcessResult<IModule>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IModule>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IModule>(ex);
            }
        }
    }
}
