using LGU.EntityManagers;
using LGU.EntityManagers.Core;
using LGU.EntityManagers.HumanResource;
using LGU.EntityProcesses;
using LGU.EntityProcesses.Core;
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

            #region GenderManager
            serviceCollection.AddTransient<IGetGenderById, GetGenderById>();
            serviceCollection.AddTransient<IGetGenderList, GetGenderList>();
            serviceCollection.AddSingleton<IGenderManager, GenderManager>();
            #endregion

            #region PersonManager
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

            #region EmployeeManager
            serviceCollection.AddTransient<IDeleteEmployee, DeleteEmployee>();
            serviceCollection.AddTransient<IGetEmployeeById, GetEmployeeById>();
            serviceCollection.AddTransient<IGetEmployeeList, GetEmployeeList>();
            serviceCollection.AddTransient<IInsertEmployee, InsertEmployee>();
            serviceCollection.AddTransient<IUpdateEmployee, UpdateEmployee>();
            serviceCollection.AddTransient<ISearchEmployee, SearchEmployee>();
            serviceCollection.AddSingleton<IEmployeeManager, EmployeeManager>();
            #endregion

            return serviceCollection;
        }
    }
}
