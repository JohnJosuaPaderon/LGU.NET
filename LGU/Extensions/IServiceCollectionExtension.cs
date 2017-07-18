using LGU.EntityConverters.Core;
using LGU.EntityConverters.HumanResource;
using LGU.EntityManagers;
using LGU.EntityManagers.Core;
using LGU.EntityManagers.HumanResource;
using LGU.EntityProcesses;
using LGU.EntityProcesses.Core;
using LGU.EntityProcesses.HumanResource;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace LGU.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection serviceCollection)
        {
            #region SystemManager
            serviceCollection.AddSingleton<IGetSystemDate, GetSystemDate>();
            serviceCollection.AddSingleton<ISystemManager, SystemManager>();
            #endregion

            // Core

            #region GenderManager
            serviceCollection.AddSingleton<IGenderConverter<SqlDataReader>, GenderConverter>();
            serviceCollection.AddSingleton<IGetGenderById, GetGenderById>();
            serviceCollection.AddSingleton<IGetGenderList, GetGenderList>();
            serviceCollection.AddSingleton<IGenderManager, GenderManager>();
            #endregion

            #region PersonManager
            serviceCollection.AddSingleton<IPersonConverter<SqlDataReader>, PersonConverter>();
            serviceCollection.AddSingleton<IDeletePerson, DeletePerson>();
            serviceCollection.AddSingleton<IGetPersonById, GetPersonById>();
            serviceCollection.AddSingleton<IGetPersonList, GetPersonList>();
            serviceCollection.AddSingleton<IInsertPerson, InsertPerson>();
            serviceCollection.AddSingleton<IUpdatePerson, UpdatePerson>();
            serviceCollection.AddSingleton<ISearchPerson, SearchPerson>();
            serviceCollection.AddSingleton<IPersonManager, PersonManager>();
            #endregion

            #region UserStatusManager
            serviceCollection.AddSingleton<IUserStatusConverter<SqlDataReader>, UserStatusConverter>();
            serviceCollection.AddSingleton<IGetUserStatusById, GetUserStatusById>();
            serviceCollection.AddSingleton<IGetUserStatusList, GetUserStatusList>();
            serviceCollection.AddSingleton<IUserStatusManager, UserStatusManager>();
            #endregion

            #region UserTypeManager
            serviceCollection.AddSingleton<IUserTypeConverter<SqlDataReader>, UserTypeConverter>();
            serviceCollection.AddSingleton<IGetUserTypeById, GetUserTypeById>();
            serviceCollection.AddSingleton<IGetUserTypeList, GetUserTypeList>();
            serviceCollection.AddSingleton<IUserTypeManager, UserTypeManager>();
            #endregion

            #region UserManager
            serviceCollection.AddSingleton<IUserConverter<SqlDataReader>, UserConverter>();
            serviceCollection.AddSingleton<IDeleteUser, DeleteUser>();
            serviceCollection.AddSingleton<IGetUserById, GetUserById>();
            serviceCollection.AddSingleton<IGetUserList, GetUserList>();
            serviceCollection.AddSingleton<IInsertUser, InsertUser>();
            serviceCollection.AddSingleton<IUpdateUser, UpdateUser>();
            serviceCollection.AddSingleton<ILoginUser, LoginUser>();
            serviceCollection.AddSingleton<IIsUsernameExists, IsUsernameExists>();
            serviceCollection.AddSingleton<IUserManager, UserManager>();
            #endregion

            // HumanResource

            #region DepartmentManager
            serviceCollection.AddSingleton<IDepartmentConverter<SqlDataReader>, DepartmentConverter>();
            serviceCollection.AddSingleton<IDeleteDepartment, DeleteDepartment>();
            serviceCollection.AddSingleton<IGetDepartmentById, GetDepartmentById>();
            serviceCollection.AddSingleton<IGetDepartmentList, GetDepartmentList>();
            serviceCollection.AddSingleton<ISearchDepartment, SearchDepartment>();
            serviceCollection.AddSingleton<IInsertDepartment, InsertDepartment>();
            serviceCollection.AddSingleton<IUpdateDepartment, UpdateDepartment>();
            serviceCollection.AddSingleton<IDepartmentManager, DepartmentManager>();
            #endregion

            #region EmployeeManager
            serviceCollection.AddSingleton<IEmployeeConverter<SqlDataReader>, EmployeeConverter>();
            serviceCollection.AddSingleton<IDeleteEmployee, DeleteEmployee>();
            serviceCollection.AddSingleton<IGetEmployeeById, GetEmployeeById>();
            serviceCollection.AddSingleton<IGetEmployeeList, GetEmployeeList>();
            serviceCollection.AddSingleton<IInsertEmployee, InsertEmployee>();
            serviceCollection.AddSingleton<IUpdateEmployee, UpdateEmployee>();
            serviceCollection.AddSingleton<ISearchEmployee, SearchEmployee>();
            serviceCollection.AddSingleton<IEmployeeManager, EmployeeManager>();
            #endregion

            #region TimeLogTypeManger
            serviceCollection.AddSingleton<ITimeLogTypeConverter<SqlDataReader>, TimeLogTypeConverter>();
            serviceCollection.AddSingleton<IDeleteTimeLogType, DeleteTimeLogType>();
            serviceCollection.AddSingleton<IGetTimeLogTypeById, GetTimeLogTypeById>();
            serviceCollection.AddSingleton<IGetTimeLogTypeList, GetTimeLogTypeList>();
            serviceCollection.AddSingleton<IInsertTimeLogType, InsertTimeLogType>();
            serviceCollection.AddSingleton<IUpdateTimeLogType, UpdateTimeLogType>();
            serviceCollection.AddSingleton<ITimeLogTypeManager, TimeLogTypeManager>();
            #endregion

            #region TimeLogManager
            serviceCollection.AddSingleton<ITimeLogConverter<SqlDataReader>, TimeLogConverter>();
            serviceCollection.AddSingleton<IDeleteTimeLog, DeleteTimeLog>();
            serviceCollection.AddSingleton<IGetTimeLogById, GetTimeLogById>();
            serviceCollection.AddSingleton<IGetTimeLogList, GetTimeLogList>();
            serviceCollection.AddSingleton<IInsertTimeLog, InsertTimeLog>();
            serviceCollection.AddSingleton<ILogEmployee, LogEmployee>();
            serviceCollection.AddSingleton<IUpdateTimeLog, UpdateTimeLog>();
            serviceCollection.AddSingleton<ITimeLogManager, TimeLogManager>();
            #endregion

            return serviceCollection;
        }
    }
}
