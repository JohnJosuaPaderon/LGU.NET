using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.Extensions
{
    public static class IDataConverterPropertyExtension
    {
        public static T TryGetValue<T>(this IDataConverterProperty<T> instance, Func<string, T> expression, string arg)
        {
            return instance.UseProvidedValue ? instance.Value : expression(arg);
        }

        public static TResult TryGetValueFromProcess<TResult, TArg>(this IDataConverterProperty<TResult> instance, Func<TArg, IProcessResult<TResult>> expression, TArg arg)
        {
            return instance.UseProvidedValue ? instance.Value : expression(arg).Data;
        }

        public static TResult TryGetValueFromProcess2<TResult, TArg>(this IDataConverterProperty<TResult> instance, Func<TArg, IProcessResult<TResult>> getDataById, Func<string, TArg> getIdFromReader, string idField)
        {
            return instance.UseProvidedValue ? instance.Value : getDataById(getIdFromReader(idField)).Data;
        }

        public static async Task<TResult> TryGetValueFromProcessAsync<TResult, TArg>(this IDataConverterProperty<TResult> instance, Func<TArg, Task<IProcessResult<TResult>>> expressionAsync, TArg arg)
        {
            return instance.UseProvidedValue ? instance.Value : (await expressionAsync(arg)).Data;
        }

        public static async Task<TResult> TryGetValueFromProcessAsync<TResult, TArg>(this IDataConverterProperty<TResult> instance, Func<TArg, Task<IProcessResult<TResult>>> getDataByIdAsync, Func<string, TArg> getIdFromReader, string idField)
        {
            return instance.UseProvidedValue ? instance.Value : (await getDataByIdAsync(getIdFromReader(idField))).Data;
        }

        public static async Task<TResult> TryGetValueFromProcessAsync<TResult, TArg>(this IDataConverterProperty<TResult> instance, Func<TArg, CancellationToken, Task<IProcessResult<TResult>>> expressionAsync, TArg arg, CancellationToken cancellationToken)
        {
            return instance.UseProvidedValue ? instance.Value : (await expressionAsync(arg, cancellationToken)).Data;
        }

        public static async Task<TResult> TryGetValueFromProcessAsync<TResult, TArg>(this IDataConverterProperty<TResult> instance, Func<TArg, CancellationToken, Task<IProcessResult<TResult>>> getDataByIdAsync, Func<string, TArg> getIdFromReader, string idField, CancellationToken cancellationToken)
        {
            return instance.UseProvidedValue ? instance.Value : (await getDataByIdAsync(getIdFromReader(idField), cancellationToken)).Data;
        }
    }
}
