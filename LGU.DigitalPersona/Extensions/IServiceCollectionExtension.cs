using LGU.EntityConverters.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.EntityProcesses.HumanResource;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace LGU.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseDigitalPersona(this IServiceCollection serviceCollection)
        {
            #region EmployeeFingerPrintSetManager
            serviceCollection.AddSingleton<IEmployeeFingerPrintSetConverter<SqlDataReader>, EmployeeFingerPrintSetConverter>();
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
