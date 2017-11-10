using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Processes
{
    public sealed class DefaultDbDataReaderToEnumerableProcessResultConverter : IDbDataReaderToEnumerableProcessResultConverter
    {
        public IEnumerableProcessResult<T> EnumerableFromReader<T>(DbDataReader reader, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (reader.Read())
                    {
                        list.Add(convert(reader));
                    }

                    return EnumerableProcessResult<T>.Success(list);
                }
                catch (Exception ex)
                {
                    return EnumerableProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return EnumerableProcessResult<T>.NoResult();
            }
        }

        public async Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync<T>(DbDataReader reader, Func<DbDataReader, Task<T>> convertAsync)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (await reader.ReadAsync())
                    {
                        list.Add(await convertAsync(reader));
                    }

                    return EnumerableProcessResult<T>.Success(list);
                }
                catch (Exception ex)
                {
                    return EnumerableProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return EnumerableProcessResult<T>.NoResult();
            }
        }

        public async Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync<T>(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, CancellationToken, Task<T>> convertAsync)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (await reader.ReadAsync(cancellationToken))
                    {
                        list.Add(await convertAsync(reader, cancellationToken));
                    }

                    return EnumerableProcessResult<T>.Success(list);
                }
                catch (Exception ex)
                {
                    return EnumerableProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return EnumerableProcessResult<T>.NoResult();
            }
        }

        public async Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync<T>(DbDataReader reader, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (await reader.ReadAsync())
                    {
                        list.Add(convert(reader));
                    }

                    return EnumerableProcessResult<T>.Success(list);
                }
                catch (Exception ex)
                {
                    return EnumerableProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return EnumerableProcessResult<T>.NoResult();
            }
        }

        public async Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync<T>(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (await reader.ReadAsync(cancellationToken))
                    {
                        list.Add(convert(reader));
                    }

                    return EnumerableProcessResult<T>.Success(list);
                }
                catch (Exception ex)
                {
                    return EnumerableProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return EnumerableProcessResult<T>.NoResult();
            }
        }
    }
}
