using LGU.EntityConverters.Core;
using LGU.EntityConverters.HumanResource;
using LGU.EntityManagers;
using LGU.EntityManagers.Core;
using LGU.EntityManagers.HumanResource;
using LGU.EntityProcesses;
using LGU.EntityProcesses.Core;
using LGU.EntityProcesses.HumanResource;
using LGU.Utilities.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace LGU.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection instance)
        {
            #region System
            instance.AddSingleton<IGetSystemDate, GetSystemDate>();
            instance.AddSingleton<ISystemManager, SystemManager>();
            #endregion

            instance.UseSqlServerForCore();
            instance.UseSqlServerForHumanResource();

            return instance;
        }

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

        public static IServiceCollection UseSqlServerForHumanResource(this IServiceCollection instance)
        {
            instance.UseSqlServer_Applicant();
            instance.UseSqlServer_ApplicantStatus();
            instance.UseSqlServer_Application();
            instance.UseSqlServer_ApplicationDocument();
            instance.UseSqlServer_Department();
            instance.UseSqlServer_DepartmentHead();
            instance.UseSqlServer_Employee();
            instance.UseSqlServer_EmployeeSalaryGradeStep();
            instance.UseSqlServer_EmployeeType();
            instance.UseSqlServer_EmployeeWorkTimeSchedule();
            instance.UseSqlServer_EmploymentStatus();
            instance.UseSqlServer_EssayQuestion();
            instance.UseSqlServer_Exam();
            instance.UseSqlServer_ExamEssayAnswer();
            instance.UseSqlServer_ExamMultipleChoiceAnswer();
            instance.UseSqlServer_Locator();
            instance.UseSqlServer_LocatorLeaveType();
            instance.UseSqlServer_MultipleChoiceCandidateAnswer();
            instance.UseSqlServer_MultipleChoiceQuestion();
            instance.UseSqlServer_Position();
            instance.UseSqlServer_SalaryGrade();
            instance.UseSqlServer_SalaryGradeBatch();
            instance.UseSqlServer_SalaryGradeStep();
            instance.UseSqlServer_TimeLog();
            instance.UseSqlServer_TimeLogType();
            instance.UseSqlServer_WorkTimeSchedule();

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

        public static IServiceCollection UseSqlServer_Applicant(this IServiceCollection instance)
        {
            instance.AddSingleton<IApplicantConverter<SqlDataReader>, ApplicantConverter>();
            instance.AddSingleton<IDeleteApplicant, DeleteApplicant>();
            instance.AddSingleton<IGetApplicantById, GetApplicantById>();
            instance.AddSingleton<IGetApplicantList, GetApplicantList>();
            instance.AddSingleton<IInsertApplicant, InsertApplicant>();
            instance.AddSingleton<IUpdateApplicant, UpdateApplicant>();
            instance.AddSingleton<IApplicantManager, ApplicantManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_ApplicantStatus(this IServiceCollection instance)
        {
            instance.AddSingleton<IApplicantStatusConverter<SqlDataReader>, ApplicantStatusConverter>();
            instance.AddSingleton<IGetApplicantStatusById, GetApplicantStatusById>();
            instance.AddSingleton<IGetApplicantStatusList, GetApplicantStatusList>();
            instance.AddSingleton<IApplicantStatusManager, ApplicantStatusManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Application(this IServiceCollection instance)
        {
            instance.AddSingleton<IApplicationConverter<SqlDataReader>, ApplicationConverter>();
            instance.AddSingleton<IDeleteApplication, DeleteApplication>();
            instance.AddSingleton<IGetApplicationById, GetApplicationById>();
            instance.AddSingleton<IGetApplicationList, GetApplicationList>();
            instance.AddSingleton<IInsertApplication, InsertApplication>();
            instance.AddSingleton<IUpdateApplication, UpdateApplication>();
            instance.AddSingleton<IApplicationManager, ApplicationManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_ApplicationDocument(this IServiceCollection instance)
        {
            instance.AddSingleton<IApplicationDocumentConverter<SqlDataReader>, ApplicationDocumentConverter>();
            instance.AddSingleton<IDeleteApplicationDocument, DeleteApplicationDocument>();
            instance.AddSingleton<IGetApplicationDocumentById, GetApplicationDocumentById>();
            instance.AddSingleton<IGetApplicationDocumentList, GetApplicationDocumentList>();
            instance.AddSingleton<IInsertApplicationDocument, InsertApplicationDocument>();
            instance.AddSingleton<IUpdateApplicationDocument, UpdateApplicationDocument>();
            instance.AddSingleton<IApplicationDocumentManager, ApplicationDocumentManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Department(this IServiceCollection instance)
        {
            instance.AddSingleton<IDepartmentConverter<SqlDataReader>, DepartmentConverter>();
            instance.AddSingleton<IDeleteDepartment, DeleteDepartment>();
            instance.AddSingleton<IGetDepartmentById, GetDepartmentById>();
            instance.AddSingleton<IGetDepartmentList, GetDepartmentList>();
            instance.AddSingleton<ISearchDepartment, SearchDepartment>();
            instance.AddSingleton<IInsertDepartment, InsertDepartment>();
            instance.AddSingleton<IUpdateDepartment, UpdateDepartment>();
            instance.AddSingleton<IGetDepartmentListWithTimeLog, GetDepartmentListWithTimeLog>();
            instance.AddSingleton<IDepartmentManager, DepartmentManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_DepartmentHead(this IServiceCollection instance)
        {
            instance.AddSingleton<IDepartmentHeadConverter<SqlDataReader>, DepartmentHeadConverter>();
            instance.AddSingleton<IDeleteDepartmentHead, DeleteDepartmentHead>();
            instance.AddSingleton<IGetDepartmentHeadById, GetDepartmentHeadById>();
            instance.AddSingleton<IGetDepartmentHeadList, GetDepartmentHeadList>();
            instance.AddSingleton<IInsertDepartmentHead, InsertDepartmentHead>();
            instance.AddSingleton<IUpdateDepartmentHead, UpdateDepartmentHead>();
            instance.AddSingleton<IDepartmentHeadManager, DepartmentHeadManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Employee(this IServiceCollection instance)
        {
            instance.AddSingleton<IEmployeeConverter<SqlDataReader>, EmployeeConverter>();
            instance.AddSingleton<IDeleteEmployee, DeleteEmployee>();
            instance.AddSingleton<IGetEmployeeById, GetEmployeeById>();
            instance.AddSingleton<IGetEmployeeList, GetEmployeeList>();
            instance.AddSingleton<IInsertEmployee, InsertEmployee>();
            instance.AddSingleton<IUpdateEmployee, UpdateEmployee>();
            instance.AddSingleton<ISearchEmployee, SearchEmployee>();
            instance.AddSingleton<IGetEmployeeListWithTimeLog, GetEmployeeListWithTimeLog>();
            instance.AddSingleton<ISearchEmployeeWithTimeLog, SearchEmployeeWithTimeLog>();
            instance.AddSingleton<IGetEmployeeListWithTimeLogByDepartment, GetEmployeeListWithTimeLogByDepartment>();
            instance.AddSingleton<IEmployeeManager, EmployeeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EmployeeSalaryGradeStep(this IServiceCollection instance)
        {
            instance.AddSingleton<IEmployeeSalaryGradeStepConverter<SqlDataReader>, EmployeeSalaryGradeStepConverter>();
            instance.AddSingleton<IDeleteEmployeeSalaryGradeStep, DeleteEmployeeSalaryGradeStep>();
            instance.AddSingleton<IGetEmployeeSalaryGradeStepList, GetEmployeeSalaryGradeStepList>();
            instance.AddSingleton<IInsertEmployeeSalaryGradeStep, InsertEmployeeSalaryGradeStep>();
            instance.AddSingleton<IUpdateEmployeeSalaryGradeStep, UpdateEmployeeSalaryGradeStep>();
            instance.AddSingleton<IEmployeeSalaryGradeStepManager, EmployeeSalaryGradeStepManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EmployeeType(this IServiceCollection instance)
        {
            instance.AddSingleton<IEmployeeTypeConverter<SqlDataReader>, EmployeeTypeConverter>();
            instance.AddSingleton<IGetEmployeeTypeById, GetEmployeeTypeById>();
            instance.AddSingleton<IGetEmployeeTypeList, GetEmployeeTypeList>();
            instance.AddSingleton<IEmployeeTypeManager, EmployeeTypeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EmployeeWorkTimeSchedule(this IServiceCollection instance)
        {
            instance.AddSingleton<IEmployeeWorkTimeScheduleConverter<SqlDataReader>, EmployeeWorkTimeScheduleConverter>();
            instance.AddSingleton<IDeleteEmployeeWorkTimeSchedule, DeleteEmployeeWorkTimeSchedule>();
            instance.AddSingleton<IGetEmployeeWorkTimeScheduleList, GetEmployeeWorkTimeScheduleList>();
            instance.AddSingleton<IInsertEmployeeWorkTimeSchedule, InsertEmployeeWorkTimeSchedule>();
            instance.AddSingleton<IUpdateEmployeeWorkTimeSchedule, UpdateEmployeeWorkTimeSchedule>();
            instance.AddSingleton<IEmployeeWorkTimeScheduleManager, EmployeeWorkTimeScheduleManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EmploymentStatus(this IServiceCollection instance)
        {
            instance.AddSingleton<IEmploymentStatusConverter<SqlDataReader>, EmploymentStatusConverter>();
            instance.AddSingleton<IGetEmploymentStatusById, GetEmploymentStatusById>();
            instance.AddSingleton<IGetEmploymentStatusList, GetEmploymentStatusList>();
            instance.AddSingleton<IEmploymentStatusManager, EmploymentStatusManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EssayQuestion(this IServiceCollection instance)
        {
            instance.AddSingleton<IEssayQuestionConverter<SqlDataReader>, EssayQuestionConverter>();
            instance.AddSingleton<IDeleteEssayQuestion, DeleteEssayQuestion>();
            instance.AddSingleton<IGetEssayQuestionById, GetEssayQuestionById>();
            instance.AddSingleton<IGetEssayQuestionList, GetEssayQuestionList>();
            instance.AddSingleton<IInsertEssayQuestion, InsertEssayQuestion>();
            instance.AddSingleton<IUpdateEssayQuestion, UpdateEssayQuestion>();
            instance.AddSingleton<IEssayQuestionManager, EssayQuestionManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Exam(this IServiceCollection instance)
        {
            instance.AddSingleton<IExamConverter<SqlDataReader>, ExamConverter>();
            instance.AddSingleton<IDeleteExam, DeleteExam>();
            instance.AddSingleton<IGetExamById, GetExamById>();
            instance.AddSingleton<IGetExamList, GetExamList>();
            instance.AddSingleton<IInsertExam, InsertExam>();
            instance.AddSingleton<IUpdateExam, UpdateExam>();
            instance.AddSingleton<IExamManager, ExamManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_ExamEssayAnswer(this IServiceCollection instance)
        {
            instance.AddSingleton<IExamEssayAnswerConverter<SqlDataReader>, ExamEssayAnswerConverter>();
            instance.AddSingleton<IDeleteExamEssayAnswer, DeleteExamEssayAnswer>();
            instance.AddSingleton<IGetExamEssayAnswerList, GetExamEssayAnswerList>();
            instance.AddSingleton<IInsertExamEssayAnswer, InsertExamEssayAnswer>();
            instance.AddSingleton<IUpdateExamEssayAnswer, UpdateExamEssayAnswer>();
            instance.AddSingleton<IExamEssayAnswerManager, ExamEssayAnswerManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_ExamMultipleChoiceAnswer(this IServiceCollection instance)
        {
            instance.AddSingleton<IExamMultipleChoiceAnswerConverter<SqlDataReader>, ExamMultipleChoiceAnswerConverter>();
            instance.AddSingleton<IDeleteExamMultipleChoiceAnswer, DeleteExamMultipleChoiceAnswer>();
            instance.AddSingleton<IGetExamMultipleChoiceAnswerList, GetExamMultipleChoiceAnswerList>();
            instance.AddSingleton<IInsertExamMultipleChoiceAnswer, InsertExamMultipleChoiceAnswer>();
            instance.AddSingleton<IUpdateExamMultipleChoiceAnswer, UpdateExamMultipleChoiceAnswer>();
            instance.AddSingleton<IExamMultipleChoiceAnswerManager, ExamMultipleChoiceAnswerManager>();

            return instance;
        }

        public static IServiceCollection UseSqServer_ExamSet(this IServiceCollection instance)
        {
            instance.AddSingleton<IExamSetConverter<SqlDataReader>, ExamSetConverter>();
            instance.AddSingleton<IDeleteExamSet, DeleteExamSet>();
            instance.AddSingleton<IGetExamSetById, GetExamSetById>();
            instance.AddSingleton<IGetExamSetList, GetExamSetList>();
            instance.AddSingleton<IInsertExamSet, InsertExamSet>();
            instance.AddSingleton<IUpdateExamSet, UpdateExamSet>();
            instance.AddSingleton<IExamSetManager, ExamSetManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Locator(this IServiceCollection instance)
        {
            instance.AddSingleton<ILocatorConverter<SqlDataReader>, LocatorConverter>();
            instance.AddSingleton<IDeleteLocator, DeleteLocator>();
            instance.AddSingleton<IGetLocatorById, GetLocatorById>();
            instance.AddSingleton<IGetLocatorList, GetLocatorList>();
            instance.AddSingleton<IInsertLocator, InsertLocator>();
            instance.AddSingleton<IUpdateLocator, UpdateLocator>();
            instance.AddSingleton<ILocatorManager, LocatorManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_LocatorLeaveType(this IServiceCollection instance)
        {
            instance.AddSingleton<ILocatorLeaveTypeConverter<SqlDataReader>, LocatorLeaveTypeConverter>();
            instance.AddSingleton<IGetLocatorLeaveTypeById, GetLocatorLeaveTypeById>();
            instance.AddSingleton<IGetLocatorLeaveTypeList, GetLocatorLeaveTypeList>();
            instance.AddSingleton<ILocatorLeaveTypeManager, LocatorLeaveTypeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_MultipleChoiceCandidateAnswer(this IServiceCollection instance)
        {
            instance.AddSingleton<IMultipleChoiceCandidateAnswerConverter<SqlDataReader>, MultipleChoiceCandidateAnswerConverter>();
            instance.AddSingleton<IDeleteMultipleChoiceCandidateAnswer, DeleteMultipleChoiceCandidateAnswer>();
            instance.AddSingleton<IGetMultipleChoiceCandidateAnswerById, GetMultipleChoiceCandidateAnswerById>();
            instance.AddSingleton<IGetMultipleChoiceCandidateAnswerList, GetMultipleChoiceCandidateAnswerList>();
            instance.AddSingleton<IInsertMultipleChoiceCandidateAnswer, InsertMultipleChoiceCandidateAnswer>();
            instance.AddSingleton<IUpdateMultipleChoiceCandidateAnswer, UpdateMultipleChoiceCandidateAnswer>();
            instance.AddSingleton<IMultipleChoiceCandidateAnswerManager, MultipleChoiceCandidateAnswerManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_MultipleChoiceQuestion(this IServiceCollection instance)
        {
            instance.AddSingleton<IMultipleChoiceQuestionConverter<SqlDataReader>, MultipleChoiceQuestionConverter>();
            instance.AddSingleton<IDeleteMultipleChoiceQuestion, DeleteMultipleChoiceQuestion>();
            instance.AddSingleton<IGetMultipleChoiceQuestionById, GetMultipleChoiceQuestionById>();
            instance.AddSingleton<IGetMultipleChoiceQuestionList, GetMultipleChoiceQuestionList>();
            instance.AddSingleton<IInsertMultipleChoiceQuestion, InsertMultipleChoiceQuestion>();
            instance.AddSingleton<IUpdateMultipleChoiceQuestion, UpdateMultipleChoiceQuestion>();
            instance.AddSingleton<IMultipleChoiceQuestionManager, MultipleChoiceQuestionManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Position(this IServiceCollection instance)
        {
            instance.AddSingleton<IPositionConverter<SqlDataReader>, PositionConverter>();
            instance.AddSingleton<IDeletePosition, DeletePosition>();
            instance.AddSingleton<IGetPositionById, GetPositionById>();
            instance.AddSingleton<IGetPositionList, GetPositionList>();
            instance.AddSingleton<IInsertPosition, InsertPosition>();
            instance.AddSingleton<IUpdatePosition, UpdatePosition>();
            instance.AddSingleton<IPositionManager, PositionManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_SalaryGrade(this IServiceCollection instance)
        {
            instance.AddSingleton<ISalaryGradeConverter<SqlDataReader>, SalaryGradeConverter>();
            instance.AddSingleton<IDeleteSalaryGrade, DeleteSalaryGrade>();
            instance.AddSingleton<IGetSalaryGradeById, GetSalaryGradeById>();
            instance.AddSingleton<IGetSalaryGradeList, GetSalaryGradeList>();
            instance.AddSingleton<IInsertSalaryGrade, InsertSalaryGrade>();
            instance.AddSingleton<IUpdateSalaryGrade, UpdateSalaryGrade>();
            instance.AddSingleton<IGetSalaryGradeListByBatch, GetSalaryGradeListByBatch>();
            instance.AddSingleton<ISalaryGradeManager, SalaryGradeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_SalaryGradeBatch(this IServiceCollection instance)
        {
            instance.AddSingleton<ISalaryGradeBatchConverter<SqlDataReader>, SalaryGradeBatchConverter>();
            instance.AddSingleton<IDeleteSalaryGradeBatch, DeleteSalaryGradeBatch>();
            instance.AddSingleton<IGetSalaryGradeBatchById, GetSalaryGradeBatchById>();
            instance.AddSingleton<IGetSalaryGradeBatchList, GetSalaryGradeBatchList>();
            instance.AddSingleton<IInsertSalaryGradeBatch, InsertSalaryGradeBatch>();
            instance.AddSingleton<IUpdateSalaryGradeBatch, UpdateSalaryGradeBatch>();
            instance.AddSingleton<IGetCurrentSalaryGradeBatch, GetCurrentSalaryGradeBatch>();
            instance.AddSingleton<ISalaryGradeBatchManager, SalaryGradeBatchManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_SalaryGradeStep(this IServiceCollection instance)
        {
            instance.AddSingleton<ISalaryGradeStepConverter<SqlDataReader>, SalaryGradeStepConverter>();
            instance.AddSingleton<IDeleteSalaryGradeStep, DeleteSalaryGradeStep>();
            instance.AddSingleton<IGetSalaryGradeStepById, GetSalaryGradeStepById>();
            instance.AddSingleton<IGetSalaryGradeStepList, GetSalaryGradeStepList>();
            instance.AddSingleton<IInsertSalaryGradeStep, InsertSalaryGradeStep>();
            instance.AddSingleton<IUpdateSalaryGradeStep, UpdateSalaryGradeStep>();
            instance.AddSingleton<IGetSalaryGradeStepListBySalaryGrade, GetSalaryGradeStepListBySalaryGrade>();
            instance.AddSingleton<IGetSalaryGradeStepByNumberAndStep, GetSalaryGradeStepByNumberAndStep>();
            instance.AddSingleton<IGetCurrentSalaryGradeStepByEmployee, GetCurrentSalaryGradeStepByEmployee>();
            instance.AddSingleton<ISalaryGradeStepManager, SalaryGradeStepManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_TimeLog(this IServiceCollection instance)
        {
            instance.AddSingleton<ITimeLogConverter<SqlDataReader>, TimeLogConverter>();
            instance.AddSingleton<IDeleteTimeLog, DeleteTimeLog>();
            instance.AddSingleton<IGetTimeLogById, GetTimeLogById>();
            instance.AddSingleton<IGetTimeLogList, GetTimeLogList>();
            instance.AddSingleton<IInsertTimeLog, InsertTimeLog>();
            instance.AddSingleton<ILogEmployee, LogEmployee>();
            instance.AddSingleton<IUpdateTimeLog, UpdateTimeLog>();
            instance.AddSingleton<IGetActualTimeLogListByEmployeeCutOff, GetActualTimeLogListByEmployeeCutOff>();
            instance.AddSingleton<IGetTimeLogListByCutOff, GetTimeLogListByCutOff>();
            instance.AddSingleton<IGetTimeLogListByDepartmentCutOff, GetTimeLogListByDepartmentCutOff>();
            instance.AddSingleton<IGetTimeLogListByEmployeeCutOff, GetTimeLogListByEmployeeCutOff>();
            instance.AddSingleton<ITimeLogManager, TimeLogManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_TimeLogType(this IServiceCollection instance)
        {
            instance.AddSingleton<ITimeLogTypeConverter<SqlDataReader>, TimeLogTypeConverter>();
            instance.AddSingleton<IGetTimeLogTypeById, GetTimeLogTypeById>();
            instance.AddSingleton<IGetTimeLogTypeList, GetTimeLogTypeList>();
            instance.AddSingleton<ITimeLogTypeManager, TimeLogTypeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_WorkTimeSchedule(this IServiceCollection instance)
        {
            instance.AddSingleton<IWorkTimeScheduleConverter<SqlDataReader>, WorkTimeScheduleConverter>();
            instance.AddSingleton<IDeleteWorkTimeSchedule, DeleteWorkTimeSchedule>();
            instance.AddSingleton<IGetWorkTimeScheduleById, GetWorkTimeScheduleById>();
            instance.AddSingleton<IGetWorkTimeScheduleList, GetWorkTimeScheduleList>();
            instance.AddSingleton<IInsertWorkTimeSchedule, InsertWorkTimeSchedule>();
            instance.AddSingleton<IUpdateWorkTimeSchedule, UpdateWorkTimeSchedule>();
            instance.AddSingleton<IWorkTimeScheduleManager, WorkTimeScheduleManager>();

            return instance;
        }

        public static IServiceCollection UseBuiltInEntityResolver(this IServiceCollection instance)
        {
            instance.AddSingleton<IPersonPlaceholderResolver, PersonPlaceholderResolver>();

            return instance;
        }
    }
}
