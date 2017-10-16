using LGU.EntityConverters.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.EntityProcesses.HumanResource;
using Microsoft.Extensions.DependencyInjection;

namespace LGU.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseDigitalPersona(this IServiceCollection serviceCollection)
        {
            #region EmployeeFingerPrintSetManager
            serviceCollection.AddSingleton<IEmployeeFingerPrintSetConverter, EmployeeFingerPrintSetConverter>();
            serviceCollection.AddSingleton<IDeleteEmployeeFingerPrintSet, DeleteEmployeeFingerPrintSet>();
            serviceCollection.AddSingleton<IGetEmployeeFingerPrintSetList, GetEmployeeFingerPrintSetList>();
            serviceCollection.AddSingleton<IInsertEmployeeFingerPrintSet, InsertEmployeeFingerPrintSet>();
            serviceCollection.AddSingleton<IUpdateEmployeeFingerPrintSet, UpdateEmployeeFingerPrintSet>();
            serviceCollection.AddSingleton<IGetEmployeeFingerPrintSetById, GetEmployeeFingerPrintSetById>();
            serviceCollection.AddSingleton<IGetUpdatedEmployeeFingerPrintSetList, GetUpdatedEmployeeFingerPrintSetList>();
            serviceCollection.AddSingleton<IEmployeeFingerPrintSetManager, EmployeeFingerPrintSetManager>();
            #endregion

            return serviceCollection;
        }
    }
}
