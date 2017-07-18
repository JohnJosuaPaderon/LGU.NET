using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Data.RDBMS
{
    public interface IDbConnectionEstablisher<TConnection>
        where TConnection : DbConnection
    {
        TConnection Establish();
        Task<TConnection> EstablishAsync();
        Task<TConnection> EstablishAsync(CancellationToken cancellationToken);
    }
}
