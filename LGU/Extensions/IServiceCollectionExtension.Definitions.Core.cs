using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.EntityManagers.Core;
using LGU.EntityProcesses.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace LGU.Extensions
{
    partial class IServiceCollectionExtension
    {

        public static IServiceCollection UseSqlServerForCore(this IServiceCollection instance)
        {
            instance.UseSqlServer_Document();
            instance.UseSqlServer_DocumentPathType();
            instance.UseSqlServer_Gender();
            instance.UseSqlServer_Module();
            instance.UseSqlServer_Person();
            instance.UseSqlServer_User();
            instance.UseSqlServer_UserStatus();
            instance.UseSqlServer_UserType();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Document(this IServiceCollection instance)
        {
            instance.AddSingleton<IDocumentConverter<SqlDataReader>, DocumentConverter>();
            instance.AddSingleton<IDeleteDocument, DeleteDocument>();
            instance.AddSingleton<IGetDocumentById, GetDocumentById>();
            instance.AddSingleton<IGetDocumentList, GetDocumentList>();
            instance.AddSingleton<IInsertDocument, InsertDocument>();
            instance.AddSingleton<IUpdateDocument, UpdateDocument>();
            instance.AddSingleton<IDocumentManager, DocumentManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_DocumentPathType(this IServiceCollection instance)
        {
            instance.AddSingleton<IDocumentPathTypeConverter<SqlDataReader>, DocumentPathTypeConverter>();
            instance.AddSingleton<IGetDocumentPathTypeById, GetDocumentPathTypeById>();
            instance.AddSingleton<IGetDocumentPathTypeList, GetDocumentPathTypeList>();
            instance.AddSingleton<IDocumentPathTypeManager, DocumentPathTypeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Gender(this IServiceCollection instance)
        {
            instance.AddSingleton<IGenderConverter<SqlDataReader>, GenderConverter>();
            instance.AddSingleton<IGetGenderById, GetGenderById>();
            instance.AddSingleton<IGetGenderList, GetGenderList>();
            instance.AddSingleton<IGenderManager, GenderManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Module(this IServiceCollection instance)
        {
            instance.AddSingleton<IModuleConverter<SqlDataReader>, ModuleConverter>();
            instance.AddSingleton<IGetModuleById, GetModuleById>();
            instance.AddSingleton<IGetModuleList, GetModuleList>();
            instance.AddSingleton<IModuleManager, ModuleManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Person(this IServiceCollection instance)
        {
            instance.AddSingleton<IPersonConverter<SqlDataReader>, PersonConverter>();
            instance.AddSingleton<IPersonFields, PersonFields>();
            instance.AddSingleton<IPersonParameters, PersonParameters>();
            instance.AddSingleton<IDeletePerson, DeletePerson>();
            instance.AddSingleton<IGetPersonById, GetPersonById>();
            instance.AddSingleton<IGetPersonList, GetPersonList>();
            instance.AddSingleton<IInsertPerson, InsertPerson>();
            instance.AddSingleton<IUpdatePerson, UpdatePerson>();
            instance.AddSingleton<ISearchPerson, SearchPerson>();
            instance.AddSingleton<IPersonManager, PersonManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_User(this IServiceCollection instance)
        {
            instance.AddSingleton<IUserConverter<SqlDataReader>, UserConverter>();
            instance.AddSingleton<IDeleteUser, DeleteUser>();
            instance.AddSingleton<IGetUserById, GetUserById>();
            instance.AddSingleton<IGetUserList, GetUserList>();
            instance.AddSingleton<IInsertUser, InsertUser>();
            instance.AddSingleton<IUpdateUser, UpdateUser>();
            instance.AddSingleton<ILoginUser, LoginUser>();
            instance.AddSingleton<IIsUsernameExists, IsUsernameExists>();
            instance.AddSingleton<IUserManager, UserManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_UserStatus(this IServiceCollection instance)
        {
            instance.AddSingleton<IUserStatusConverter<SqlDataReader>, UserStatusConverter>();
            instance.AddSingleton<IGetUserStatusById, GetUserStatusById>();
            instance.AddSingleton<IGetUserStatusList, GetUserStatusList>();
            instance.AddSingleton<IUserStatusManager, UserStatusManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_UserType(this IServiceCollection instance)
        {
            instance.AddSingleton<IUserTypeConverter<SqlDataReader>, UserTypeConverter>();
            instance.AddSingleton<IGetUserTypeById, GetUserTypeById>();
            instance.AddSingleton<IGetUserTypeList, GetUserTypeList>();
            instance.AddSingleton<IUserTypeManager, UserTypeManager>();

            return instance;
        }
    }
}
