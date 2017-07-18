using LGU.Processes;

namespace LGU.Data.RDBMS
{
    public delegate IProcessResult<T> GetDataProcessResultDelegate<T, TCommand>(T data, TCommand command, int affectedRows);
}
