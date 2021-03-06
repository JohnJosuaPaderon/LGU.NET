﻿using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class SearchPerson : PersonProcess, ISearchPerson
    {
        public SearchPerson(IConnectionStringSource connectionStringSource, IPersonConverter converter) : base(connectionStringSource, converter)
        {
        }

        public string SearchKey { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_SearchKey", SearchKey);

        public IEnumerableProcessResult<IPerson> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IPerson>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IPerson>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
