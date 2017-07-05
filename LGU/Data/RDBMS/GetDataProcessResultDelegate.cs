namespace LGU.Data.RDBMS
{
    public delegate IDataProcessResult<T> GetDataProcessResultDelegate<T, TCommand>(T data, TCommand command, int affectedRows);
}
