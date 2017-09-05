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

            #region Core
            // Document
            instance.AddSingleton<IDocumentConverter<SqlDataReader>, DocumentConverter>();
            instance.AddSingleton<IDeleteDocument, DeleteDocument>();
            instance.AddSingleton<IGetDocumentById, GetDocumentById>();
            instance.AddSingleton<IGetDocumentList, GetDocumentList>();
            instance.AddSingleton<IInsertDocument, InsertDocument>();
            instance.AddSingleton<IUpdateDocument, UpdateDocument>();
            instance.AddSingleton<IDocumentManager, DocumentManager>();

            // DocumentPathType
            instance.AddSingleton<IDocumentPathTypeConverter<SqlDataReader>, DocumentPathTypeConverter>();
            instance.AddSingleton<IGetDocumentPathTypeById, GetDocumentPathTypeById>();
            instance.AddSingleton<IGetDocumentPathTypeList, GetDocumentPathTypeList>();
            instance.AddSingleton<IDocumentPathTypeManager, DocumentPathTypeManager>();

            // Gender
            instance.AddSingleton<IGenderConverter<SqlDataReader>, GenderConverter>();
            instance.AddSingleton<IGetGenderById, GetGenderById>();
            instance.AddSingleton<IGetGenderList, GetGenderList>();
            instance.AddSingleton<IGenderManager, GenderManager>();

            // Module
            instance.AddSingleton<IModuleConverter<SqlDataReader>, ModuleConverter>();
            instance.AddSingleton<IGetModuleById, GetModuleById>();
            instance.AddSingleton<IGetModuleList, GetModuleList>();
            instance.AddSingleton<IModuleManager, ModuleManager>();

            // Person
            instance.AddSingleton<IPersonConverter<SqlDataReader>, PersonConverter>();
            instance.AddSingleton<IDeletePerson, DeletePerson>();
            instance.AddSingleton<IGetPersonById, GetPersonById>();
            instance.AddSingleton<IGetPersonList, GetPersonList>();
            instance.AddSingleton<IInsertPerson, InsertPerson>();
            instance.AddSingleton<IUpdatePerson, UpdatePerson>();
            instance.AddSingleton<ISearchPerson, SearchPerson>();
            instance.AddSingleton<IPersonManager, PersonManager>();

            // User
            instance.AddSingleton<IUserConverter<SqlDataReader>, UserConverter>();
            instance.AddSingleton<IDeleteUser, DeleteUser>();
            instance.AddSingleton<IGetUserById, GetUserById>();
            instance.AddSingleton<IGetUserList, GetUserList>();
            instance.AddSingleton<IInsertUser, InsertUser>();
            instance.AddSingleton<IUpdateUser, UpdateUser>();
            instance.AddSingleton<ILoginUser, LoginUser>();
            instance.AddSingleton<IIsUsernameExists, IsUsernameExists>();
            instance.AddSingleton<IUserManager, UserManager>();

            // UserStatus
            instance.AddSingleton<IUserStatusConverter<SqlDataReader>, UserStatusConverter>();
            instance.AddSingleton<IGetUserStatusById, GetUserStatusById>();
            instance.AddSingleton<IGetUserStatusList, GetUserStatusList>();
            instance.AddSingleton<IUserStatusManager, UserStatusManager>();

            // UserType
            instance.AddSingleton<IUserTypeConverter<SqlDataReader>, UserTypeConverter>();
            instance.AddSingleton<IGetUserTypeById, GetUserTypeById>();
            instance.AddSingleton<IGetUserTypeList, GetUserTypeList>();
            instance.AddSingleton<IUserTypeManager, UserTypeManager>();
            #endregion

            #region HumanResource
            // Applicant
            instance.AddSingleton<IApplicantConverter<SqlDataReader>, ApplicantConverter>();
            instance.AddSingleton<IDeleteApplicant, DeleteApplicant>();
            instance.AddSingleton<IGetApplicantById, GetApplicantById>();
            instance.AddSingleton<IGetApplicantList, GetApplicantList>();
            instance.AddSingleton<IInsertApplicant, InsertApplicant>();
            instance.AddSingleton<IUpdateApplicant, UpdateApplicant>();
            instance.AddSingleton<IApplicantManager, ApplicantManager>();

            // ApplicantStatus
            instance.AddSingleton<IApplicantStatusConverter<SqlDataReader>, ApplicantStatusConverter>();
            instance.AddSingleton<IGetApplicantStatusById, GetApplicantStatusById>();
            instance.AddSingleton<IGetApplicantStatusList, GetApplicantStatusList>();
            instance.AddSingleton<IApplicantStatusManager, ApplicantStatusManager>();

            // Application
            instance.AddSingleton<IApplicationConverter<SqlDataReader>, ApplicationConverter>();
            instance.AddSingleton<IDeleteApplication, DeleteApplication>();
            instance.AddSingleton<IGetApplicationById, GetApplicationById>();
            instance.AddSingleton<IGetApplicationList, GetApplicationList>();
            instance.AddSingleton<IInsertApplication, InsertApplication>();
            instance.AddSingleton<IUpdateApplication, UpdateApplication>();
            instance.AddSingleton<IApplicationManager, ApplicationManager>();

            // ApplicationDocument
            instance.AddSingleton<IApplicationDocumentConverter<SqlDataReader>, ApplicationDocumentConverter>();
            instance.AddSingleton<IDeleteApplicationDocument, DeleteApplicationDocument>();
            instance.AddSingleton<IGetApplicationDocumentById, GetApplicationDocumentById>();
            instance.AddSingleton<IGetApplicationDocumentList, GetApplicationDocumentList>();
            instance.AddSingleton<IInsertApplicationDocument, InsertApplicationDocument>();
            instance.AddSingleton<IUpdateApplicationDocument, UpdateApplicationDocument>();
            instance.AddSingleton<IApplicationDocumentManager, ApplicationDocumentManager>();

            // Department
            instance.AddSingleton<IDepartmentConverter<SqlDataReader>, DepartmentConverter>();
            instance.AddSingleton<IDeleteDepartment, DeleteDepartment>();
            instance.AddSingleton<IGetDepartmentById, GetDepartmentById>();
            instance.AddSingleton<IGetDepartmentList, GetDepartmentList>();
            instance.AddSingleton<ISearchDepartment, SearchDepartment>();
            instance.AddSingleton<IInsertDepartment, InsertDepartment>();
            instance.AddSingleton<IUpdateDepartment, UpdateDepartment>();
            instance.AddSingleton<IGetDepartmentListWithTimeLog, GetDepartmentListWithTimeLog>();
            instance.AddSingleton<IDepartmentManager, DepartmentManager>();

            // DepartmentHead
            instance.AddSingleton<IDepartmentHeadConverter<SqlDataReader>, DepartmentHeadConverter>();
            instance.AddSingleton<IDeleteDepartmentHead, DeleteDepartmentHead>();
            instance.AddSingleton<IGetDepartmentHeadById, GetDepartmentHeadById>();
            instance.AddSingleton<IGetDepartmentHeadList, GetDepartmentHeadList>();
            instance.AddSingleton<IInsertDepartmentHead, InsertDepartmentHead>();
            instance.AddSingleton<IUpdateDepartmentHead, UpdateDepartmentHead>();
            instance.AddSingleton<IDepartmentHeadManager, DepartmentHeadManager>();

            // Employee
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

            // EmployeeSalaryGradeStep
            instance.AddSingleton<IEmployeeSalaryGradeStepConverter<SqlDataReader>, EmployeeSalaryGradeStepConverter>();
            instance.AddSingleton<IDeleteEmployeeSalaryGradeStep, DeleteEmployeeSalaryGradeStep>();
            instance.AddSingleton<IGetEmployeeSalaryGradeStepList, GetEmployeeSalaryGradeStepList>();
            instance.AddSingleton<IInsertEmployeeSalaryGradeStep, InsertEmployeeSalaryGradeStep>();
            instance.AddSingleton<IUpdateEmployeeSalaryGradeStep, UpdateEmployeeSalaryGradeStep>();

            // EmployeeType
            instance.AddSingleton<IEmployeeTypeConverter<SqlDataReader>, EmployeeTypeConverter>();
            instance.AddSingleton<IGetEmployeeTypeById, GetEmployeeTypeById>();
            instance.AddSingleton<IGetEmployeeTypeList, GetEmployeeTypeList>();
            instance.AddSingleton<IEmployeeTypeManager, EmployeeTypeManager>();

            // EmployeeWorkTimeSchedule
            instance.AddSingleton<IEmployeeWorkTimeScheduleConverter<SqlDataReader>, EmployeeWorkTimeScheduleConverter>();
            instance.AddSingleton<IDeleteEmployeeWorkTimeSchedule, DeleteEmployeeWorkTimeSchedule>();
            instance.AddSingleton<IGetEmployeeWorkTimeScheduleById, GetEmployeeWorkTimeScheduleById>();
            instance.AddSingleton<IGetEmployeeWorkTimeScheduleList, GetEmployeeWorkTimeScheduleList>();
            instance.AddSingleton<IInsertEmployeeWorkTimeSchedule, InsertEmployeeWorkTimeSchedule>();
            instance.AddSingleton<IUpdateEmployeeWorkTimeSchedule, UpdateEmployeeWorkTimeSchedule>();
            instance.AddSingleton<IEmployeeWorkTimeScheduleManager, EmployeeWorkTimeScheduleManager>();

            // EmploymentStatus
            instance.AddSingleton<IEmploymentStatusConverter<SqlDataReader>, EmploymentStatusConverter>();
            instance.AddSingleton<IGetEmploymentStatusById, GetEmploymentStatusById>();
            instance.AddSingleton<IGetEmploymentStatusList, GetEmploymentStatusList>();
            instance.AddSingleton<IEmploymentStatusManager, EmploymentStatusManager>();

            // EssayQuestion
            instance.AddSingleton<IEssayQuestionConverter<SqlDataReader>, EssayQuestionConverter>();
            instance.AddSingleton<IDeleteEssayQuestion, DeleteEssayQuestion>();
            instance.AddSingleton<IGetEssayQuestionById, GetEssayQuestionById>();
            instance.AddSingleton<IGetEssayQuestionList, GetEssayQuestionList>();
            instance.AddSingleton<IInsertEssayQuestion, InsertEssayQuestion>();
            instance.AddSingleton<IUpdateEssayQuestion, UpdateEssayQuestion>();
            instance.AddSingleton<IEssayQuestionManager, EssayQuestionManager>();

            // Exam
            instance.AddSingleton<IExamConverter<SqlDataReader>, ExamConverter>();
            instance.AddSingleton<IDeleteExam, DeleteExam>();
            instance.AddSingleton<IGetExamById, GetExamById>();
            instance.AddSingleton<IGetExamList, GetExamList>();
            instance.AddSingleton<IInsertExam, InsertExam>();
            instance.AddSingleton<IUpdateExam, UpdateExam>();
            instance.AddSingleton<IExamManager, ExamManager>();

            // ExamEssayAnswer
            instance.AddSingleton<IExamEssayAnswerConverter<SqlDataReader>, ExamEssayAnswerConverter>();
            instance.AddSingleton<IDeleteExamEssayAnswer, DeleteExamEssayAnswer>();
            instance.AddSingleton<IGetExamEssayAnswerList, GetExamEssayAnswerList>();
            instance.AddSingleton<IInsertExamEssayAnswer, InsertExamEssayAnswer>();
            instance.AddSingleton<IUpdateExamEssayAnswer, UpdateExamEssayAnswer>();
            instance.AddSingleton<IExamEssayAnswerManager, ExamEssayAnswerManager>();

            // ExamMultipleChoice
            instance.AddSingleton<IExamMultipleChoiceAnswerConverter<SqlDataReader>, ExamMultipleChoiceAnswerConverter>();
            instance.AddSingleton<IDeleteExamMultipleChoiceAnswer, DeleteExamMultipleChoiceAnswer>();
            instance.AddSingleton<IGetExamMultipleChoiceAnswerList, GetExamMultipleChoiceAnswerList>();
            instance.AddSingleton<IInsertExamMultipleChoiceAnswer, InsertExamMultipleChoiceAnswer>();
            instance.AddSingleton<IUpdateExamMultipleChoiceAnswer, UpdateExamMultipleChoiceAnswer>();
            instance.AddSingleton<IExamMultipleChoiceAnswerManager, ExamMultipleChoiceAnswerManager>();

            // ExamSet
            instance.AddSingleton<IExamSetConverter<SqlDataReader>, ExamSetConverter>();
            instance.AddSingleton<IDeleteExamSet, DeleteExamSet>();
            instance.AddSingleton<IGetExamSetById, GetExamSetById>();
            instance.AddSingleton<IGetExamSetList, GetExamSetList>();
            instance.AddSingleton<IInsertExamSet, InsertExamSet>();
            instance.AddSingleton<IUpdateExamSet, UpdateExamSet>();
            instance.AddSingleton<IExamSetManager, ExamSetManager>();

            // Locator
            instance.AddSingleton<ILocatorConverter<SqlDataReader>, LocatorConverter>();
            instance.AddSingleton<IDeleteLocator, DeleteLocator>();
            instance.AddSingleton<IGetLocatorById, GetLocatorById>();
            instance.AddSingleton<IGetLocatorList, GetLocatorList>();
            instance.AddSingleton<IInsertLocator, InsertLocator>();
            instance.AddSingleton<IUpdateLocator, UpdateLocator>();
            instance.AddSingleton<ILocatorManager, LocatorManager>();

            // LocatorLeaveType
            instance.AddSingleton<ILocatorLeaveTypeConverter<SqlDataReader>, LocatorLeaveTypeConverter>();
            instance.AddSingleton<IGetLocatorLeaveTypeById, GetLocatorLeaveTypeById>();
            instance.AddSingleton<IGetLocatorLeaveTypeList, GetLocatorLeaveTypeList>();
            instance.AddSingleton<ILocatorLeaveTypeManager, LocatorLeaveTypeManager>();

            // MultipleChoiceCandidateAnswer
            instance.AddSingleton<IMultipleChoiceCandidateAnswerConverter<SqlDataReader>, MultipleChoiceCandidateAnswerConverter>();
            instance.AddSingleton<IDeleteMultipleChoiceCandidateAnswer, DeleteMultipleChoiceCandidateAnswer>();
            instance.AddSingleton<IGetMultipleChoiceCandidateAnswerById, GetMultipleChoiceCandidateAnswerById>();
            instance.AddSingleton<IGetMultipleChoiceCandidateAnswerList, GetMultipleChoiceCandidateAnswerList>();
            instance.AddSingleton<IInsertMultipleChoiceCandidateAnswer, InsertMultipleChoiceCandidateAnswer>();
            instance.AddSingleton<IUpdateMultipleChoiceCandidateAnswer, UpdateMultipleChoiceCandidateAnswer>();
            instance.AddSingleton<IMultipleChoiceCandidateAnswerManager, MultipleChoiceCandidateAnswerManager>();

            // MultipleChoiceQuestion
            instance.AddSingleton<IMultipleChoiceQuestionConverter<SqlDataReader>, MultipleChoiceQuestionConverter>();
            instance.AddSingleton<IDeleteMultipleChoiceQuestion, DeleteMultipleChoiceQuestion>();
            instance.AddSingleton<IGetMultipleChoiceQuestionById, GetMultipleChoiceQuestionById>();
            instance.AddSingleton<IGetMultipleChoiceQuestionList, GetMultipleChoiceQuestionList>();
            instance.AddSingleton<IInsertMultipleChoiceQuestion, InsertMultipleChoiceQuestion>();
            instance.AddSingleton<IUpdateMultipleChoiceQuestion, UpdateMultipleChoiceQuestion>();
            instance.AddSingleton<IMultipleChoiceQuestionManager, MultipleChoiceQuestionManager>();

            // Position
            instance.AddSingleton<IPositionConverter<SqlDataReader>, PositionConverter>();
            instance.AddSingleton<IDeletePosition, DeletePosition>();
            instance.AddSingleton<IGetPositionById, GetPositionById>();
            instance.AddSingleton<IGetPositionList, GetPositionList>();
            instance.AddSingleton<IInsertPosition, InsertPosition>();
            instance.AddSingleton<IUpdatePosition, UpdatePosition>();
            instance.AddSingleton<IPositionManager, PositionManager>();

            // SalaryGrade
            instance.AddSingleton<ISalaryGradeConverter<SqlDataReader>, SalaryGradeConverter>();
            instance.AddSingleton<IDeleteSalaryGrade, DeleteSalaryGrade>();
            instance.AddSingleton<IGetSalaryGradeById, GetSalaryGradeById>();
            instance.AddSingleton<IGetSalaryGradeList, GetSalaryGradeList>();
            instance.AddSingleton<IInsertSalaryGrade, InsertSalaryGrade>();
            instance.AddSingleton<IUpdateSalaryGrade, UpdateSalaryGrade>();
            instance.AddSingleton<IGetSalaryGradeListByBatch, GetSalaryGradeListByBatch>();
            instance.AddSingleton<ISalaryGradeManager, SalaryGradeManager>();

            // SalaryGradeBatch
            instance.AddSingleton<ISalaryGradeBatchConverter<SqlDataReader>, SalaryGradeBatchConverter>();
            instance.AddSingleton<IDeleteSalaryGradeBatch, DeleteSalaryGradeBatch>();
            instance.AddSingleton<IGetSalaryGradeBatchById, GetSalaryGradeBatchById>();
            instance.AddSingleton<IGetSalaryGradeBatchList, GetSalaryGradeBatchList>();
            instance.AddSingleton<IInsertSalaryGradeBatch, InsertSalaryGradeBatch>();
            instance.AddSingleton<IUpdateSalaryGradeBatch, UpdateSalaryGradeBatch>();
            instance.AddSingleton<IGetCurrentSalaryGradeBatch, GetCurrentSalaryGradeBatch>();
            instance.AddSingleton<ISalaryGradeBatchManager, SalaryGradeBatchManager>();

            // SalaryGradeStep
            instance.AddSingleton<ISalaryGradeStepConverter<SqlDataReader>, SalaryGradeStepConverter>();
            instance.AddSingleton<IDeleteSalaryGradeStep, DeleteSalaryGradeStep>();
            instance.AddSingleton<IGetSalaryGradeStepById, GetSalaryGradeStepById>();
            instance.AddSingleton<IGetSalaryGradeStepList, GetSalaryGradeStepList>();
            instance.AddSingleton<IInsertSalaryGradeStep, InsertSalaryGradeStep>();
            instance.AddSingleton<IUpdateSalaryGradeStep, UpdateSalaryGradeStep>();
            instance.AddSingleton<IGetSalaryGradeStepListBySalaryGrade, GetSalaryGradeStepListBySalaryGrade>();
            instance.AddSingleton<IGetSalaryGradeStepByNumberAndStep, GetSalaryGradeStepByNumberAndStep>();
            instance.AddSingleton<ISalaryGradeStepManager, SalaryGradeStepManager>();

            // TimeLog
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

            // TimeLogType
            instance.AddSingleton<ITimeLogTypeConverter<SqlDataReader>, TimeLogTypeConverter>();
            instance.AddSingleton<IGetTimeLogTypeById, GetTimeLogTypeById>();
            instance.AddSingleton<IGetTimeLogTypeList, GetTimeLogTypeList>();
            instance.AddSingleton<ITimeLogTypeManager, TimeLogTypeManager>();
            #endregion

            return instance;
        }

        public static IServiceCollection UseBuiltInEntityResolver(this IServiceCollection instance)
        {
            instance.AddSingleton<IPersonPlaceholderResolver, PersonPlaceholderResolver>();

            return instance;
        }
    }
}
