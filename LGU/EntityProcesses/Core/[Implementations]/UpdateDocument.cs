﻿using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class UpdateDocument : DocumentProcess, IUpdateDocument
    {
        public UpdateDocument(IConnectionStringSource connectionStringSource, IDocumentConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Document Document { get; set; }

        private SqlQueryInfo<Document> QueryInfo =>
            SqlQueryInfo<Document>.CreateProcedureQueryInfo(Document, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Document.Id)
            .AddInputParameter("@_Description", Document.Description)
            .AddInputParameter("@_PathTypeId", Document.PathType?.Id)
            .AddInputParameter("@_Path", Document.Path)
            .AddInputParameter("@_Data", Document.Data, SqlDbType.VarBinary)
            .AddLogByParameter();

        private IProcessResult<Document> GetProcessResult(Document data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<Document>(data);
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Failed to update document.");
            }
        }

        public IProcessResult<Document> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Document>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Document>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}