using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateApplicationDocument : ApplicationDocumentProcess, IUpdateApplicationDocument
    {
        public UpdateApplicationDocument(IConnectionStringSource connectionStringSource, IApplicationDocumentConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IApplicationDocument ApplicationDocument { get; set; }

        private SqlQueryInfo<IApplicationDocument> QueryInfo =>
            SqlQueryInfo<IApplicationDocument>.CreateProcedureQueryInfo(ApplicationDocument, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", ApplicationDocument.Id)
            .AddInputParameter("@_Title", ApplicationDocument.Title)
            .AddInputParameter("@_Description", ApplicationDocument.Description)
            .AddInputParameter("@_PathTypeId", ApplicationDocument.PathType?.Id)
            .AddInputParameter("@_Path", ApplicationDocument.Path)
            .AddInputParameter("@_Data", ApplicationDocument.Data)
            .AddInputParameter("@_ApplicationId", ApplicationDocument.Application?.Id)
            .AddLogByParameter();

        private IProcessResult<IApplicationDocument> GetProcessResult(IApplicationDocument data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IApplicationDocument>(data);
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Failed to update application document.");
            }
        }

        public IProcessResult<IApplicationDocument> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }


        public Task<IProcessResult<IApplicationDocument>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IApplicationDocument>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
