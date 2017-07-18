using LGU.Processes;

namespace LGU.Data.Rdbms
{
    public delegate IProcessResult GetProcessResultDelegate<TCommand>(TCommand command, int affectedRows);
    public delegate IProcessResult<T> GetProcessResultDelegate<T, TCommand>(T data, TCommand command, int affectedRows);
}
