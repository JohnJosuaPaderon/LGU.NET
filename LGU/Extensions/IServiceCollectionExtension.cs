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
            #region System
            serviceCollection.AddSingleton<IGetSystemDate, GetSystemDate>();
            serviceCollection.AddSingleton<ISystemManager, SystemManager>();
            #endregion

            // Core

            #region DocumentPathType
            serviceCollection.AddSingleton<IDocumentPathTypeConverter<SqlDataReader>, DocumentPathTypeConverter>();
            serviceCollection.AddSingleton<IGetDocumentPathTypeById, GetDocumentPathTypeById>();
            serviceCollection.AddSingleton<IGetDocumentPathTypeList, GetDocumentPathTypeList>();
            serviceCollection.AddSingleton<IDocumentPathTypeManager, DocumentPathTypeManager>();
            #endregion

            #region Document
            serviceCollection.AddSingleton<IDocumentConverter<SqlDataReader>, DocumentConverter>();
            serviceCollection.AddSingleton<IDeleteDocument, DeleteDocument>();
            serviceCollection.AddSingleton<IGetDocumentById, GetDocumentById>();
            serviceCollection.AddSingleton<IGetDocumentList, GetDocumentList>();
            serviceCollection.AddSingleton<IInsertDocument, InsertDocument>();
            serviceCollection.AddSingleton<IUpdateDocument, UpdateDocument>();
            serviceCollection.AddSingleton<IDocumentManager, DocumentManager>();
            #endregion

            #region Gender
            serviceCollection.AddSingleton<IGenderConverter<SqlDataReader>, GenderConverter>();
            serviceCollection.AddSingleton<IGetGenderById, GetGenderById>();
            serviceCollection.AddSingleton<IGetGenderList, GetGenderList>();
            serviceCollection.AddSingleton<IGenderManager, GenderManager>();
            #endregion

            #region Person
            serviceCollection.AddSingleton<IPersonConverter<SqlDataReader>, PersonConverter>();
            serviceCollection.AddSingleton<IDeletePerson, DeletePerson>();
            serviceCollection.AddSingleton<IGetPersonById, GetPersonById>();
            serviceCollection.AddSingleton<IGetPersonList, GetPersonList>();
            serviceCollection.AddSingleton<IInsertPerson, InsertPerson>();
            serviceCollection.AddSingleton<IUpdatePerson, UpdatePerson>();
            serviceCollection.AddSingleton<ISearchPerson, SearchPerson>();
            serviceCollection.AddSingleton<IPersonManager, PersonManager>();
            #endregion

            #region Module
            serviceCollection.AddSingleton<IModuleConverter<SqlDataReader>, ModuleConverter>();
            serviceCollection.AddSingleton<IGetModuleById, GetModuleById>();
            serviceCollection.AddSingleton<IGetModuleList, GetModuleList>();
            serviceCollection.AddSingleton<IModuleManager, ModuleManager>();
            #endregion

            #region UserStatus
            serviceCollection.AddSingleton<IUserStatusConverter<SqlDataReader>, UserStatusConverter>();
            serviceCollection.AddSingleton<IGetUserStatusById, GetUserStatusById>();
            serviceCollection.AddSingleton<IGetUserStatusList, GetUserStatusList>();
            serviceCollection.AddSingleton<IUserStatusManager, UserStatusManager>();
            #endregion

            #region UserType
            serviceCollection.AddSingleton<IUserTypeConverter<SqlDataReader>, UserTypeConverter>();
            serviceCollection.AddSingleton<IGetUserTypeById, GetUserTypeById>();
            serviceCollection.AddSingleton<IGetUserTypeList, GetUserTypeList>();
            serviceCollection.AddSingleton<IUserTypeManager, UserTypeManager>();
            #endregion

            #region User
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

            #region ApplicantStatus
            serviceCollection.AddSingleton<IApplicantStatusConverter<SqlDataReader>, ApplicantStatusConverter>();
            serviceCollection.AddSingleton<IGetApplicantStatusById, GetApplicantStatusById>();
            serviceCollection.AddSingleton<IGetApplicantStatusList, GetApplicantStatusList>();
            serviceCollection.AddSingleton<IApplicantStatusManager, ApplicantStatusManager>();
            #endregion

            #region Applicant
            serviceCollection.AddSingleton<IApplicantConverter<SqlDataReader>, ApplicantConverter>();
            serviceCollection.AddSingleton<IDeleteApplicant, DeleteApplicant>();
            serviceCollection.AddSingleton<IGetApplicantById, GetApplicantById>();
            serviceCollection.AddSingleton<IGetApplicantList, GetApplicantList>();
            serviceCollection.AddSingleton<IInsertApplicant, InsertApplicant>();
            serviceCollection.AddSingleton<IUpdateApplicant, UpdateApplicant>();
            serviceCollection.AddSingleton<IApplicantManager, ApplicantManager>();
            #endregion

            #region Application
            serviceCollection.AddSingleton<IApplicationConverter<SqlDataReader>, ApplicationConverter>();
            serviceCollection.AddSingleton<IDeleteApplication, DeleteApplication>();
            serviceCollection.AddSingleton<IGetApplicationById, GetApplicationById>();
            serviceCollection.AddSingleton<IGetApplicationList, GetApplicationList>();
            serviceCollection.AddSingleton<IInsertApplication, InsertApplication>();
            serviceCollection.AddSingleton<IUpdateApplication, UpdateApplication>();
            serviceCollection.AddSingleton<IApplicationManager, ApplicationManager>();
            #endregion

            #region ApplicationDocument
            serviceCollection.AddSingleton<IApplicationDocumentConverter<SqlDataReader>, ApplicationDocumentConverter>();
            serviceCollection.AddSingleton<IDeleteApplicationDocument, DeleteApplicationDocument>();
            serviceCollection.AddSingleton<IGetApplicationDocumentById, GetApplicationDocumentById>();
            serviceCollection.AddSingleton<IGetApplicationDocumentList, GetApplicationDocumentList>();
            serviceCollection.AddSingleton<IInsertApplicationDocument, InsertApplicationDocument>();
            serviceCollection.AddSingleton<IUpdateApplicationDocument, UpdateApplicationDocument>();
            serviceCollection.AddSingleton<IApplicationDocumentManager, ApplicationDocumentManager>();
            #endregion

            #region Department
            serviceCollection.AddSingleton<IDepartmentConverter<SqlDataReader>, DepartmentConverter>();
            serviceCollection.AddSingleton<IDeleteDepartment, DeleteDepartment>();
            serviceCollection.AddSingleton<IGetDepartmentById, GetDepartmentById>();
            serviceCollection.AddSingleton<IGetDepartmentList, GetDepartmentList>();
            serviceCollection.AddSingleton<ISearchDepartment, SearchDepartment>();
            serviceCollection.AddSingleton<IInsertDepartment, InsertDepartment>();
            serviceCollection.AddSingleton<IUpdateDepartment, UpdateDepartment>();
            serviceCollection.AddSingleton<IDepartmentManager, DepartmentManager>();
            #endregion

            #region DepartmentHead
            serviceCollection.AddSingleton<IDepartmentHeadConverter<SqlDataReader>, DepartmentHeadConverter>();
            serviceCollection.AddSingleton<IDeleteDepartmentHead, DeleteDepartmentHead>();
            serviceCollection.AddSingleton<IGetDepartmentHeadById, GetDepartmentHeadById>();
            serviceCollection.AddSingleton<IGetDepartmentHeadList, GetDepartmentHeadList>();
            serviceCollection.AddSingleton<IInsertDepartmentHead, InsertDepartmentHead>();
            serviceCollection.AddSingleton<IUpdateDepartmentHead, UpdateDepartmentHead>();
            serviceCollection.AddSingleton<IDepartmentHeadManager, DepartmentHeadManager>();
            #endregion

            #region ExamSet
            serviceCollection.AddSingleton<IExamSetConverter<SqlDataReader>, ExamSetConverter>();
            serviceCollection.AddSingleton<IDeleteExamSet, DeleteExamSet>();
            serviceCollection.AddSingleton<IGetExamSetById, GetExamSetById>();
            serviceCollection.AddSingleton<IGetExamSetList, GetExamSetList>();
            serviceCollection.AddSingleton<IInsertExamSet, InsertExamSet>();
            serviceCollection.AddSingleton<IUpdateExamSet, UpdateExamSet>();
            serviceCollection.AddSingleton<IExamSetManager, ExamSetManager>();
            #endregion

            #region EssayQuestion
            serviceCollection.AddSingleton<IEssayQuestionConverter<SqlDataReader>, EssayQuestionConverter>();
            serviceCollection.AddSingleton<IDeleteEssayQuestion, DeleteEssayQuestion>();
            serviceCollection.AddSingleton<IGetEssayQuestionById, GetEssayQuestionById>();
            serviceCollection.AddSingleton<IGetEssayQuestionList, GetEssayQuestionList>();
            serviceCollection.AddSingleton<IInsertEssayQuestion, InsertEssayQuestion>();
            serviceCollection.AddSingleton<IUpdateEssayQuestion, UpdateEssayQuestion>();
            serviceCollection.AddSingleton<IEssayQuestionManager, EssayQuestionManager>();
            #endregion

            #region Exam
            serviceCollection.AddSingleton<IExamConverter<SqlDataReader>, ExamConverter>();
            serviceCollection.AddSingleton<IDeleteExam, DeleteExam>();
            serviceCollection.AddSingleton<IGetExamById, GetExamById>();
            serviceCollection.AddSingleton<IGetExamList, GetExamList>();
            serviceCollection.AddSingleton<IInsertExam, InsertExam>();
            serviceCollection.AddSingleton<IUpdateExam, UpdateExam>();
            serviceCollection.AddSingleton<IExamManager, ExamManager>();
            #endregion

            #region ExamEssayAnswer
            serviceCollection.AddSingleton<IExamEssayAnswerConverter<SqlDataReader>, ExamEssayAnswerConverter>();
            serviceCollection.AddSingleton<IDeleteExamEssayAnswer, DeleteExamEssayAnswer>();
            serviceCollection.AddSingleton<IGetExamEssayAnswerList, GetExamEssayAnswerList>();
            serviceCollection.AddSingleton<IInsertExamEssayAnswer, InsertExamEssayAnswer>();
            serviceCollection.AddSingleton<IUpdateExamEssayAnswer, UpdateExamEssayAnswer>();
            serviceCollection.AddSingleton<IExamEssayAnswerManager, ExamEssayAnswerManager>();
            #endregion

            #region ExamMultipleChoiceAnswer
            serviceCollection.AddSingleton<IExamMultipleChoiceAnswerConverter<SqlDataReader>, ExamMultipleChoiceAnswerConverter>();
            serviceCollection.AddSingleton<IDeleteExamMultipleChoiceAnswer, DeleteExamMultipleChoiceAnswer>();
            serviceCollection.AddSingleton<IGetExamMultipleChoiceAnswerList, GetExamMultipleChoiceAnswerList>();
            serviceCollection.AddSingleton<IInsertExamMultipleChoiceAnswer, InsertExamMultipleChoiceAnswer>();
            serviceCollection.AddSingleton<IUpdateExamMultipleChoiceAnswer, UpdateExamMultipleChoiceAnswer>();
            serviceCollection.AddSingleton<IExamMultipleChoiceAnswerManager, ExamMultipleChoiceAnswerManager>();
            #endregion

            #region EmployeeType
            serviceCollection.AddSingleton<IEmployeeTypeConverter<SqlDataReader>, EmployeeTypeConverter>();
            serviceCollection.AddSingleton<IGetEmployeeTypeById, GetEmployeeTypeById>();
            serviceCollection.AddSingleton<IGetEmployeeTypeList, GetEmployeeTypeList>();
            serviceCollection.AddSingleton<IEmployeeTypeManager, EmployeeTypeManager>();
            #endregion

            #region EmploymentStatus
            serviceCollection.AddSingleton<IEmploymentStatusConverter<SqlDataReader>, EmploymentStatusConverter>();
            serviceCollection.AddSingleton<IGetEmploymentStatusById, GetEmploymentStatusById>();
            serviceCollection.AddSingleton<IGetEmploymentStatusList, GetEmploymentStatusList>();
            serviceCollection.AddSingleton<IEmploymentStatusManager, EmploymentStatusManager>();
            #endregion

            #region MultipleChoiceCandidateAnswer
            serviceCollection.AddSingleton<IMultipleChoiceCandidateAnswerConverter<SqlDataReader>, MultipleChoiceCandidateAnswerConverter>();
            serviceCollection.AddSingleton<IDeleteMultipleChoiceCandidateAnswer, DeleteMultipleChoiceCandidateAnswer>();
            serviceCollection.AddSingleton<IGetMultipleChoiceCandidateAnswerById, GetMultipleChoiceCandidateAnswerById>();
            serviceCollection.AddSingleton<IGetMultipleChoiceCandidateAnswerList, GetMultipleChoiceCandidateAnswerList>();
            serviceCollection.AddSingleton<IInsertMultipleChoiceCandidateAnswer, InsertMultipleChoiceCandidateAnswer>();
            serviceCollection.AddSingleton<IUpdateMultipleChoiceCandidateAnswer, UpdateMultipleChoiceCandidateAnswer>();
            serviceCollection.AddSingleton<IMultipleChoiceCandidateAnswerManager, MultipleChoiceCandidateAnswerManager>();
            #endregion

            #region MultipleChoiceQuestion
            serviceCollection.AddSingleton<IMultipleChoiceQuestionConverter<SqlDataReader>, MultipleChoiceQuestionConverter>();
            serviceCollection.AddSingleton<IDeleteMultipleChoiceQuestion, DeleteMultipleChoiceQuestion>();
            serviceCollection.AddSingleton<IGetMultipleChoiceQuestionById, GetMultipleChoiceQuestionById>();
            serviceCollection.AddSingleton<IGetMultipleChoiceQuestionList, GetMultipleChoiceQuestionList>();
            serviceCollection.AddSingleton<IInsertMultipleChoiceQuestion, InsertMultipleChoiceQuestion>();
            serviceCollection.AddSingleton<IUpdateMultipleChoiceQuestion, UpdateMultipleChoiceQuestion>();
            serviceCollection.AddSingleton<IMultipleChoiceQuestionManager, MultipleChoiceQuestionManager>();
            #endregion

            #region Position
            serviceCollection.AddSingleton<IPositionConverter<SqlDataReader>, PositionConverter>();
            serviceCollection.AddSingleton<IDeletePosition, DeletePosition>();
            serviceCollection.AddSingleton<IGetPositionById, GetPositionById>();
            serviceCollection.AddSingleton<IGetPositionList, GetPositionList>();
            serviceCollection.AddSingleton<IInsertPosition, InsertPosition>();
            serviceCollection.AddSingleton<IUpdatePosition, UpdatePosition>();
            serviceCollection.AddSingleton<IPositionManager, PositionManager>();
            #endregion

            #region Employee
            serviceCollection.AddSingleton<IEmployeeConverter<SqlDataReader>, EmployeeConverter>();
            serviceCollection.AddSingleton<IDeleteEmployee, DeleteEmployee>();
            serviceCollection.AddSingleton<IGetEmployeeById, GetEmployeeById>();
            serviceCollection.AddSingleton<IGetEmployeeList, GetEmployeeList>();
            serviceCollection.AddSingleton<IInsertEmployee, InsertEmployee>();
            serviceCollection.AddSingleton<IUpdateEmployee, UpdateEmployee>();
            serviceCollection.AddSingleton<ISearchEmployee, SearchEmployee>();
            serviceCollection.AddSingleton<IGetEmployeeListWithTimeLog, GetEmployeeListWithTimeLog>();
            serviceCollection.AddSingleton<ISearchEmployeeWithTimeLog, SearchEmployeeWithTimeLog>();
            serviceCollection.AddSingleton<IEmployeeManager, EmployeeManager>();
            #endregion

            #region EmployeeWorkTimeSchedule
            serviceCollection.AddSingleton<IEmployeeWorkTimeScheduleConverter<SqlDataReader>, EmployeeWorkTimeScheduleConverter>();
            serviceCollection.AddSingleton<IDeleteEmployeeWorkTimeSchedule, DeleteEmployeeWorkTimeSchedule>();
            serviceCollection.AddSingleton<IGetEmployeeWorkTimeScheduleById, GetEmployeeWorkTimeScheduleById>();
            serviceCollection.AddSingleton<IGetEmployeeWorkTimeScheduleList, GetEmployeeWorkTimeScheduleList>();
            serviceCollection.AddSingleton<IInsertEmployeeWorkTimeSchedule, InsertEmployeeWorkTimeSchedule>();
            serviceCollection.AddSingleton<IUpdateEmployeeWorkTimeSchedule, UpdateEmployeeWorkTimeSchedule>();
            serviceCollection.AddSingleton<IEmployeeWorkTimeScheduleManager, EmployeeWorkTimeScheduleManager>();
            #endregion

            #region Locator
            serviceCollection.AddSingleton<ILocatorConverter<SqlDataReader>, LocatorConverter>();
            serviceCollection.AddSingleton<IDeleteLocator, DeleteLocator>();
            serviceCollection.AddSingleton<IGetLocatorById, GetLocatorById>();
            serviceCollection.AddSingleton<IGetLocatorList, GetLocatorList>();
            serviceCollection.AddSingleton<IInsertLocator, InsertLocator>();
            serviceCollection.AddSingleton<IUpdateLocator, UpdateLocator>();
            serviceCollection.AddSingleton<ILocatorManager, LocatorManager>();
            #endregion

            #region LocatorLeaveType
            serviceCollection.AddSingleton<ILocatorLeaveTypeConverter<SqlDataReader>, LocatorLeaveTypeConverter>();
            serviceCollection.AddSingleton<IGetLocatorLeaveTypeById, GetLocatorLeaveTypeById>();
            serviceCollection.AddSingleton<IGetLocatorLeaveTypeList, GetLocatorLeaveTypeList>();
            serviceCollection.AddSingleton<ILocatorLeaveTypeManager, LocatorLeaveTypeManager>();
            #endregion

            #region TimeLogType
            serviceCollection.AddSingleton<ITimeLogTypeConverter<SqlDataReader>, TimeLogTypeConverter>();
            serviceCollection.AddSingleton<IGetTimeLogTypeById, GetTimeLogTypeById>();
            serviceCollection.AddSingleton<IGetTimeLogTypeList, GetTimeLogTypeList>();
            serviceCollection.AddSingleton<ITimeLogTypeManager, TimeLogTypeManager>();
            #endregion

            #region TimeLog
            serviceCollection.AddSingleton<ITimeLogConverter<SqlDataReader>, TimeLogConverter>();
            serviceCollection.AddSingleton<IDeleteTimeLog, DeleteTimeLog>();
            serviceCollection.AddSingleton<IGetTimeLogById, GetTimeLogById>();
            serviceCollection.AddSingleton<IGetTimeLogList, GetTimeLogList>();
            serviceCollection.AddSingleton<IInsertTimeLog, InsertTimeLog>();
            serviceCollection.AddSingleton<ILogEmployee, LogEmployee>();
            serviceCollection.AddSingleton<IUpdateTimeLog, UpdateTimeLog>();
            serviceCollection.AddSingleton<IGetActualTimeLogListByEmployeeCutOff, GetActualTimeLogListByEmployeeCutOff>();
            serviceCollection.AddSingleton<ITimeLogManager, TimeLogManager>();
            #endregion

            return serviceCollection;
        }
    }
}
