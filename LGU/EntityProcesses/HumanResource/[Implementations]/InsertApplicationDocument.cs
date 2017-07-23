using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertApplicationDocument : ApplicationDocumentProcess, IInsertApplicationDocument
    {
        public InsertApplicationDocument(IConnectionStringSource connectionStringSource, IApplicationDocumentConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ApplicationDocument ApplicationDocument { get; set; }

        private SqlQueryInfo<ApplicationDocument> QueryInfo =>
            SqlQueryInfo<ApplicationDocument>.CreateProcedureQueryInfo(ApplicationDocument, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_Title", ApplicationDocument.Title)
            .AddInputParameter("@_Description", ApplicationDocument.Description)
            .AddInputParameter("@_PathTypeId", ApplicationDocument.PathType?.Id)
            .AddInputParameter("@_Path", ApplicationDocument.Path)
            .AddInputParameter("@_Data", ApplicationDocument.Data)
            .AddInputParameter("@_ApplicationId", ApplicationDocument.Application?.Id)
            .AddLogByParameter();

        private IProcessResult<ApplicationDocument> GetProcessResult(ApplicationDocument data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<ApplicationDocument>(data);
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Failed to insert application document.");
            }
        }

        public IProcessResult<ApplicationDocument> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ApplicationDocument>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ApplicationDocument>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
