using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class DeleteDocument : DocumentProcess, IDeleteDocument
    {
        public DeleteDocument(IConnectionStringSource connectionStringSource, IDocumentConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IDocument Document { get; set; }

        private SqlQueryInfo<IDocument> QueryInfo =>
            SqlQueryInfo<IDocument>.CreateProcedureQueryInfo(Document, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Document.Id)
            .AddLogByParameter();

        private IProcessResult<IDocument> GetProcessResult(IDocument data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IDocument>(data);
            }
            else
            {
                return new ProcessResult<IDocument>(ProcessResultStatus.Failed, "Failed to delete document.");
            }
        }

        public IProcessResult<IDocument> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IDocument>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IDocument>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
