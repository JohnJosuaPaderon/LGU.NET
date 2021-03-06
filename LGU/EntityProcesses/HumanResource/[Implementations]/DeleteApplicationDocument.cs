﻿using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteApplicationDocument : ApplicationDocumentProcess, IDeleteApplicationDocument
    {
        public DeleteApplicationDocument(IConnectionStringSource connectionStringSource, IApplicationDocumentConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IApplicationDocument ApplicationDocument { get; set; }

        private SqlQueryInfo<IApplicationDocument> QueryInfo =>
            SqlQueryInfo<IApplicationDocument>.CreateProcedureQueryInfo(ApplicationDocument, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", ApplicationDocument.Id)
            .AddLogByParameter();

        private IProcessResult<IApplicationDocument> GetProcessResult(IApplicationDocument data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IApplicationDocument>(data);
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Failed to delete application document.");
            }
        }

        public IProcessResult<IApplicationDocument> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IApplicationDocument>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IApplicationDocument>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
