using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU
{
    /// <summary>
    /// Represents a complex data process
    /// </summary>
    public interface IProcess : IDisposable
    {
        /// <summary>
        /// Executes a series of data processing statements
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// Represents a complex data process
    /// </summary>
    /// <typeparam name="T">The type of the returned value after the execution has finished</typeparam>
    public interface IProcess<T> : IDisposable
    {
        /// <summary>
        /// Executes a series of data processing statements then returns a value
        /// </summary>
        /// <returns></returns>
        T Execute();
    }

    /// <summary>
    /// Represents a complex data process that can be executed asynchronously
    /// </summary>
    public interface IAsyncProcess : IDisposable
    {
        /// <summary>
        /// Executes a series of data processing statements asynchronously
        /// </summary>
        /// <returns></returns>
        Task ExecuteAsync();
    }

    /// <summary>
    /// Represents a complex data process that can be executed asynchronously
    /// </summary>
    /// <typeparam name="T">The type of the returned value after the execution has finished</typeparam>
    public interface IAsyncProcess<T> : IDisposable
    {
        /// <summary>
        /// Executes a series of data processing statements asynchronously then returns a value
        /// </summary>
        /// <returns></returns>
        Task<T> ExecuteAsync();
    }

    /// <summary>
    /// Represents a complex data process that can be executed asynchronously and can be cancelled
    /// </summary>
    public interface ICancellableAsyncProcess : IDisposable
    {
        /// <summary>
        /// Executes a series of data processing statements asynchronously
        /// </summary>
        /// <param name="cancellationToken">Signals the operation to cancel</param>
        /// <returns></returns>
        Task ExecuteAsync(CancellationToken cancellationToken);
    }

    /// <summary>
    /// Represents a complex data process that can be executed asynchronously and can be cancelled
    /// </summary>
    /// <typeparam name="T">The type of the returned value after the execution has finished</typeparam>
    public interface ICancellableAsyncProcess<T> : IDisposable
    {
        /// <summary>
        /// Executes a series of data processing statements asynchronously then returns a value
        /// </summary>
        /// <param name="cancellationToken">Signals the operation to cancel</param>
        /// <returns></returns>
        Task<T> ExecuteAsync(CancellationToken cancellationToken);
    }
}
