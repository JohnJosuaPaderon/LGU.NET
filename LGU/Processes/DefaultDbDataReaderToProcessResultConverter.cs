using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Processes
{
    public sealed class DefaultDbDataReaderToProcessResultConverter : IDbDataReaderToProcessResultConverter
    {
        public IProcessResult<T> FromReader<T>(DbDataReader reader, Func<DbDataReader, T> converter)
        {
            if (reader.HasRows)
            {
                try
                {
                    reader.Read();
                    return ProcessResult<T>.Success(converter(reader));
                }
                catch (Exception ex)
                {
                    return ProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return ProcessResult<T>.NoResult();
            }
        }

        public async Task<IProcessResult<T>> FromReaderAsync<T>(DbDataReader reader, Func<DbDataReader, Task<T>> convertAsync)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync();
                    return ProcessResult<T>.Success(await convertAsync(reader));
                }
                catch (Exception ex)
                {
                    return ProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return ProcessResult<T>.NoResult();
            }
        }

        public async Task<IProcessResult<T>> FromReaderAsync<T>(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, CancellationToken, Task<T>> convertAsync)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync(cancellationToken);
                    return ProcessResult<T>.Success(await convertAsync(reader, cancellationToken));
                }
                catch (Exception ex)
                {
                    return ProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return ProcessResult<T>.NoResult();
            }
        }

        public async Task<IProcessResult<T>> FromReaderAsync<T>(DbDataReader reader, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync();
                    return ProcessResult<T>.Success(convert(reader));
                }
                catch (Exception ex)
                {
                    return ProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return ProcessResult<T>.NoResult();
            }
        }

        public async Task<IProcessResult<T>> FromReaderAsync<T>(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync(cancellationToken);
                    return ProcessResult<T>.Success(convert(reader));
                }
                catch (Exception ex)
                {
                    return ProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return ProcessResult<T>.NoResult();
            }
        }
    }
}
