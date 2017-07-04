using LGU.Data.RDBMS;
using System;
using System.Data.Common;

namespace LGU.Data.Extensions
{
    public static class DbQueryInfoExtension
    {
        public static void InvokeIfUsingTransaction<TConnection, TTransaction, TCommand, TParameter>(this IDbQueryInfo<TConnection, TTransaction, TCommand, TParameter> dbQueryInfo, Action action)
            where TConnection : DbConnection
            where TTransaction : DbTransaction
            where TCommand : DbCommand
            where TParameter : DbParameter
        {
            if (dbQueryInfo.UseTransaction)
            {
                action();
            }
        }

        public static void InvokeInTransaction<TData, TConnection, TTransaction, TCommand, TParameter>(this IDataDbQueryInfo<TData, TConnection, TTransaction, TCommand, TParameter> dataDbQueryInfo, Action action)
            where TConnection : DbConnection
            where TTransaction : DbTransaction
            where TCommand : DbCommand
            where TParameter : DbParameter
        {
            if (dataDbQueryInfo.UseTransaction)
            {
                action();
            }
        }
    }
}
