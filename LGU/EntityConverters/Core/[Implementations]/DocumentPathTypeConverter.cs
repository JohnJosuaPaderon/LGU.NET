using LGU.Data.Extensions;
using LGU.Entities.Core;
using LGU.Processes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityConverters.Core
{
    public sealed class DocumentPathTypeConverter : IDocumentPathTypeConverter
    {
        private IDocumentPathType GetData(DbDataReader reader)
        {
            return new DocumentPathType()
            {
                Id = reader.GetInt16("Id"),
                Description = reader.GetString("Description")
            };
        }

        public IEnumerableProcessResult<IDocumentPathType> EnumerableFromReader(DbDataReader reader)
        {
            try
            {
                var list = new List<IDocumentPathType>();

                while (reader.Read())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDocumentPathType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDocumentPathType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDocumentPathType>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            try
            {
                var list = new List<IDocumentPathType>();

                while (await reader.ReadAsync())
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDocumentPathType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDocumentPathType>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<IDocumentPathType>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                var list = new List<IDocumentPathType>();

                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(GetData(reader));
                }

                return new EnumerableProcessResult<IDocumentPathType>(list);
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<IDocumentPathType>(ex);
            }
        }

        public IProcessResult<IDocumentPathType> FromReader(DbDataReader reader)
        {
            try
            {
                reader.Read();
                return new ProcessResult<IDocumentPathType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDocumentPathType>(ex);
            }
        }

        public async Task<IProcessResult<IDocumentPathType>> FromReaderAsync(DbDataReader reader)
        {
            try
            {
                await reader.ReadAsync();
                return new ProcessResult<IDocumentPathType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDocumentPathType>(ex);
            }
        }

        public async Task<IProcessResult<IDocumentPathType>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            try
            {
                await reader.ReadAsync(cancellationToken);
                return new ProcessResult<IDocumentPathType>(GetData(reader));
            }
            catch (Exception ex)
            {
                return new ProcessResult<IDocumentPathType>(ex);
            }
        }

        public void InitializeDependency()
        {
            // TODO: Initialize Entity Managers
        }
    }
}
