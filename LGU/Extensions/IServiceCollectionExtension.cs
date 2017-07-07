using LGU.EntityManagers;
using LGU.EntityManagers.HumanResource;
using LGU.EntityProcesses;
using LGU.EntityProcesses.HumanResource;
using Microsoft.Extensions.DependencyInjection;

namespace LGU.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection serviceCollection)
        {
            #region SystemManager
            serviceCollection.AddTransient<IGetSystemDate, GetSystemDate>();
            serviceCollection.AddSingleton<ISystemManager, SystemManager>();
            #endregion

            #region DepartmentManager
            serviceCollection.AddTransient<IDeleteDepartment, DeleteDepartment>();
            serviceCollection.AddTransient<IGetDepartmentById, GetDepartmentById>();
            serviceCollection.AddTransient<IGetDepartmentList, GetDepartmentList>();
            serviceCollection.AddTransient<ISearchDepartment, SearchDepartment>();
            serviceCollection.AddTransient<IInsertDepartment, InsertDepartment>();
            serviceCollection.AddTransient<IUpdateDepartment, UpdateDepartment>();
            serviceCollection.AddSingleton<IDepartmentManager, DepartmentManager>(); 
            #endregion

            return serviceCollection;
        }
    }
}
