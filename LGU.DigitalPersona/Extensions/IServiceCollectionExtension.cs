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
            serviceCollection.AddTransient<IDeleteEmployeeFingerPrintSet, DeleteEmployeeFingerPrintSet>();
            serviceCollection.AddTransient<IGetEmployeeFingerPrintSetList, GetEmployeeFingerPrintSetList>();
            serviceCollection.AddTransient<IInsertEmployeeFingerPrintSet, InsertEmployeeFingerPrintSet>();
            serviceCollection.AddTransient<IUpdateEmployeeFingerPrintSet, UpdateEmployeeFingerPrintSet>();
            serviceCollection.AddTransient<IGetEmployeeFingerPrintSetById, GetEmployeeFingerPrintSetById>();
            serviceCollection.AddSingleton<IEmployeeFingerPrintSetManager, EmployeeFingerPrintSetManager>();
            #endregion

            return serviceCollection;
        }
    }
}
