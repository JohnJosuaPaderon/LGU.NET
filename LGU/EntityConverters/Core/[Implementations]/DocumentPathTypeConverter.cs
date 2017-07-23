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
    public sealed class DocumentPathTypeConverter : IDocumentPathTypeConverter<SqlDataReader>
    {
        private DocumentPathType GetData(SqlDataReader reader)
        {
            return new DocumentPathType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<DocumentPathType> EnumerableFromReader(SqlDataReader reader)
        {
            try
            {
                var list = new List<DocumentPathType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<DocumentPathType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<DocumentPathType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<DocumentPathType>> EnumerableFromReaderAsync(SqlDataReader reader)
        {
            try
            {
                var list = new List<DocumentPathType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<DocumentPathType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<DocumentPathType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<DocumentPathType>> EnumerableFromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<DocumentPathType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<DocumentPathType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<DocumentPathType>(ex);
            }
        }

        public IProcessResult<DocumentPathType> FromReader(SqlDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<DocumentPathType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<DocumentPathType>(ex);
            }
        }

        public async Task<IProcessResult<DocumentPathType>> FromReaderAsync(SqlDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<DocumentPathType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<DocumentPathType>(ex);
            }
        }

        public async Task<IProcessResult<DocumentPathType>> FromReaderAsync(SqlDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<DocumentPathType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<DocumentPathType>(ex);
            }
        }
    }
}
