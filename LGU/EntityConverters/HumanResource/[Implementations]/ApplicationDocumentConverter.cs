using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Entities.HumanResource;
using LGU.EntityManagers.Core;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.HumanResource
{
    public sealed class ApplicationDocumentConverter : IApplicationDocumentConverter<SqlDataReader>
    {
        private readonly IDocumentPathTypeManager r_DocumentPathTypeManager;
        private readonly IApplicationManager r_ApplicationManager;

        public ApplicationDocumentConverter(
            IDocumentPathTypeManager documentPathTypeManager,
            IApplicationManager applicationManager)
        {
            r_DocumentPathTypeManager = documentPathTypeManager;
            r_ApplicationManager = applicationManager;
        }

        private IApplicationDocument GetData(IApplication application, IDocumentPathType pathType, SqlDataReader reader)
        {
            if (application != null)
            {
                return new ApplicationDocument(application)
                {
                    Id = reader.GetInt64("Id"),
                    Title = reader.GetString("Title"),
                    Description = reader.GetString("Description"),
                    PathType = pathType,
                    Path = reader.GetString("Path"),
                    Data = reader.GetByteArray("Data")
                };
            }
            else
            {
                return null;
            }
        }

        private IApplicationDocument GetData(SqlDataReader reader)
        {
            var applicationResult = r_ApplicationManager.GetById(reader.GetInt64("ApplicationId"));
            var pathTypeResult = r_DocumentPathTypeManager.GetById(reader.GetInt16("PathTypeId"));

            return GetData(applicationResult.Data, pathTypeResult.Data, reader);
        }

        private async Task<IApplicationDocument> GetDataAsync(SqlDataReader reader)
        {
            var applicationResult = await r_ApplicationManager.GetByIdAsync(reader.GetInt64("ApplicationId"));
            var pathTypeResult = await r_DocumentPathTypeManager.GetByIdAsync(reader.GetInt16("PathTypeId"));

            return GetData(applicationResult.Data, pathTypeResult.Data, reader);
        }

        private async Task<IApplicationDocument> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var applicationResult = await r_ApplicationManager.GetByIdAsync(reader.GetInt64("ApplicationId"), cancellationToken);
            var pathTypeResult = await r_DocumentPathTypeManager.GetByIdAsync(reader.GetInt16("PathTypeId"), cancellationToken);

            return GetData(applicationResult.Data, pathTypeResult.Data, reader);
        }

        public IEnumerableProcessResult<IApplicationDocument> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IApplicationDocument>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IApplicationDocument>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicationDocument>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplicationDocument>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IApplicationDocument>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IApplicationDocument>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicationDocument>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IApplicationDocument>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IApplicationDocument>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IApplicationDocument>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IApplicationDocument>(ex);
            }
        }

        public IProcessResult<IApplicationDocument> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IApplicationDocument>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicationDocument>(ex);
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IApplicationDocument>(await GetDataAsync(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicationDocument>(ex);
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IApplicationDocument>(await GetDataAsync(reader, cancellationToken));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IApplicationDocument>(ex);
            }
        }
    }
}
