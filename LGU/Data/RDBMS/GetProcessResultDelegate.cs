namespace LGU.Data.RDBMS
{
    public delegate IProcessResult GetProcessResultDelegate<TCommand>(TCommand command, int affectedRows);
}
