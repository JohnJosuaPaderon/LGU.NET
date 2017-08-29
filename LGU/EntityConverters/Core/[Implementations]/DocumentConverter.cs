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
    public sealed class DocumentConverter : IDocumentConverter<SqlDataReader>
    {
        private readonly IDocumentPathTypeManager r_DocumentPathTypeManager;

        public DocumentConverter(IDocumentPathTypeManager documentPathTypeManager)
        {
            r_DocumentPathTypeManager = documentPathTypeManager;
        }

        private IDocument GetData(IDocumentPathType pathType, SqlDataReader reader)
        {
            return new Document()
            {
                Id = reader.GetInt16("Id"),
                Title = reader.GetString("Title"),
                Description = reader.GetString("Description"),
                PathType = pathType,
                Path = reader.GetString("Path"),
                Data = reader.GetByteArray("Data")
            };
        }

        private IDocument GetData(SqlDataReader reader)
        {
            var pathTypeResult = r_DocumentPathTypeManager.GetById(reader.GetInt16("PathTypeId"));

            return GetData(pathTypeResult.Data, reader);
        }

        private async Task<IDocument> GetDataAsync(SqlDataReader reader)
        {
            var pathTypeResult = await r_DocumentPathTypeManager.GetByIdAsync(reader.GetInt16("PathTypeId"));

            return GetData(pathTypeResult.Data, reader);
        }

        private async Task<IDocument> GetDataAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            var pathTypeResult = await r_DocumentPathTypeManager.GetByIdAsync(reader.GetInt16("PathTypeId"), cancellationToken);

            return GetData(pathTypeResult.Data, reader);
        }

        public IEnumerableProcessResult<IDocument> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<IDocument>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDocument>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDocument>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDocument>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<IDocument>();

                while (await reader.ReadAsync())
                {
                    list.Add(await GetDataAsync(reader));
                }

                return new EnumerableProcessResult<IDocument>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDocument>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDocument>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IDocument>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(await GetDataAsync(reader, cancellationToken));
                }

                return new EnumerableProcessResult<IDocument>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDocument>(ex);
            }
        }

        public IProcessResult<IDocument> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IDocument>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDocument>(ex);
            }
        }

        public Task<IProcessResult<IDocument>> FromReaderAsync(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<IDocument>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
