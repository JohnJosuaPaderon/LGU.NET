using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.EntityProcesses.HumanResource;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace LGU.Extensions
{
    partial class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServerForHumanResource(this IServiceCollection instance)
        {
            instance.UseSqlServer_Applicant();
            instance.UseSqlServer_ApplicantStatus();
            instance.UseSqlServer_Application();
            instance.UseSqlServer_ApplicationDocument();
            instance.UseSqlServer_CalendarEvent();
            instance.UseSqlServer_Department();
            instance.UseSqlServer_Employee();
            instance.UseSqlServer_EmployeeFlexWorkSchedule();
            instance.UseSqlServer_EmployeeSalaryGradeStep();
            instance.UseSqlServer_EmployeeType();
            instance.UseSqlServer_EmployeeWorkdaySchedule();
            instance.UseSqlServer_EmploymentStatus();
            instance.UseSqlServer_EssayQuestion();
            instance.UseSqlServer_Exam();
            instance.UseSqlServer_ExamEssayAnswer();
            instance.UseSqlServer_ExamMultipleChoiceAnswer();
            instance.UseSqlServer_Locator();
            instance.UseSqlServer_LocatorLeaveType();
            instance.UseSqlServer_MultipleChoiceCandidateAnswer();
            instance.UseSqlServer_MultipleChoiceQuestion();
            instance.UseSqlServer_PayrollContractualDepartment();
            instance.UseSqlServer_PayrollContractualEmployee();
            instance.UseSqlServer_PayrollCutOff();
            instance.UseSqlServer_PayrollType();
            instance.UseSqlServer_Position();
            instance.UseSqlServer_SalaryGrade();
            instance.UseSqlServer_SalaryGradeBatch();
            instance.UseSqlServer_SalaryGradeStep();
            instance.UseSqlServer_TimeLog();
            instance.UseSqlServer_TimeLogType();
            instance.UseSqlServer_WorkTimeSchedule();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Applicant(this IServiceCollection instance)
        {
            instance.AddTransient<IApplicantConverter, ApplicantConverter>();
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
            instance.AddTransient<IApplicantStatusConverter, ApplicantStatusConverter>();
            instance.AddSingleton<IGetApplicantStatusById, GetApplicantStatusById>();
            instance.AddSingleton<IGetApplicantStatusList, GetApplicantStatusList>();
            instance.AddSingleton<IApplicantStatusManager, ApplicantStatusManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Application(this IServiceCollection instance)
        {
            instance.AddTransient<IApplicationConverter, ApplicationConverter>();
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
            instance.AddTransient<IApplicationDocumentConverter, ApplicationDocumentConverter>();
            instance.AddSingleton<IDeleteApplicationDocument, DeleteApplicationDocument>();
            instance.AddSingleton<IGetApplicationDocumentById, GetApplicationDocumentById>();
            instance.AddSingleton<IGetApplicationDocumentList, GetApplicationDocumentList>();
            instance.AddSingleton<IInsertApplicationDocument, InsertApplicationDocument>();
            instance.AddSingleton<IUpdateApplicationDocument, UpdateApplicationDocument>();
            instance.AddSingleton<IApplicationDocumentManager, ApplicationDocumentManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_CalendarEvent(this IServiceCollection instance)
        {
            instance.AddTransient<ICalendarEventConverter, CalendarEventConverter>();
            instance.AddSingleton<ICalendarEventFields, CalendarEventFields>();
            instance.AddSingleton<ICalendarEventParameters, CalendarEventParameters>();
            instance.AddSingleton<IDeleteCalendarEvent, DeleteCalendarEvent>();
            instance.AddSingleton<IGetCalendarEventById, GetCalendarEventById>();
            instance.AddSingleton<IInsertCalendarEvent, InsertCalendarEvent>();
            instance.AddSingleton<IUpdateCalendarEvent, UpdateCalendarEvent>();
            instance.AddSingleton<IGetCalendarEventList, GetCalendarEventList>();
            instance.AddSingleton<ICalendarEventManager, CalendarEventManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Department(this IServiceCollection instance)
        {
            instance.AddTransient<IDepartmentConverter, DepartmentConverter>();
            instance.AddSingleton<IDepartmentParameters, DepartmentParameters>();
            instance.AddSingleton<IDepartmentFields, DepartmentFields>();
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

        public static IServiceCollection UseSqlServer_Employee(this IServiceCollection instance)
        {
            instance.AddTransient<IEmployeeConverter, EmployeeConverter>();
            instance.AddSingleton<IEmployeeParameters, EmployeeParameters>();
            instance.AddSingleton<IEmployeeFields, EmployeeFields>();
            instance.AddSingleton<IDeleteEmployee, DeleteEmployee>();
            instance.AddSingleton<IGetEmployeeById, GetEmployeeById>();
            instance.AddSingleton<IGetEmployeeList, GetEmployeeList>();
            instance.AddSingleton<IInsertEmployee, InsertEmployee>();
            instance.AddSingleton<IUpdateEmployee, UpdateEmployee>();
            instance.AddSingleton<ISearchEmployee, SearchEmployee>();
            instance.AddSingleton<IGetEmployeeListWithTimeLog, GetEmployeeListWithTimeLog>();
            instance.AddSingleton<ISearchEmployeeWithTimeLog, SearchEmployeeWithTimeLog>();
            instance.AddSingleton<IGetEmployeeListWithTimeLogByDepartment, GetEmployeeListWithTimeLogByDepartment>();
            instance.AddSingleton<IGetEmployeeListByPayrollType, GetEmployeeListByPayrollType>();
            instance.AddSingleton<IEmployeeManager, EmployeeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EmployeeFlexWorkSchedule(this IServiceCollection instance)
        {
            instance.AddSingleton<IEmployeeFlexWorkScheduleFields, EmployeeFlexWorkScheduleFields>();
            instance.AddSingleton<IEmployeeFlexWorkScheduleParameters, EmployeeFlexWorkScheduleParameters>();
            instance.AddSingleton<IEmployeeFlexWorkScheduleConverter, EmployeeFlexWorkScheduleConverter>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EmployeeSalaryGradeStep(this IServiceCollection instance)
        {
            instance.AddTransient<IEmployeeSalaryGradeStepConverter, EmployeeSalaryGradeStepConverter>();
            instance.AddSingleton<IDeleteEmployeeSalaryGradeStep, DeleteEmployeeSalaryGradeStep>();
            instance.AddSingleton<IGetEmployeeSalaryGradeStepList, GetEmployeeSalaryGradeStepList>();
            instance.AddSingleton<IInsertEmployeeSalaryGradeStep, InsertEmployeeSalaryGradeStep>();
            instance.AddSingleton<IUpdateEmployeeSalaryGradeStep, UpdateEmployeeSalaryGradeStep>();
            instance.AddSingleton<IEmployeeSalaryGradeStepManager, EmployeeSalaryGradeStepManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EmployeeType(this IServiceCollection instance)
        {
            instance.AddTransient<IEmployeeTypeConverter, EmployeeTypeConverter>();
            instance.AddSingleton<IGetEmployeeTypeById, GetEmployeeTypeById>();
            instance.AddSingleton<IGetEmployeeTypeList, GetEmployeeTypeList>();
            instance.AddSingleton<IEmployeeTypeManager, EmployeeTypeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EmployeeWorkdaySchedule(this IServiceCollection instance)
        {
            instance.AddTransient<IEmployeeWorkdayScheduleConverter, EmployeeWorkdayScheduleConverter>();
            instance.AddSingleton<IEmployeeWorkdayScheduleParameters, EmployeeWorkdayScheduleParameters>();
            instance.AddSingleton<IDeleteEmployeeWorkdaySchedule, DeleteEmployeeWorkdaySchedule>();
            instance.AddSingleton<IGetEmployeeWorkdayScheduleById, GetEmployeeWorkdayScheduleById>();
            instance.AddSingleton<IInsertEmployeeWorkdaySchedule, InsertEmployeeWorkdaySchedule>();
            instance.AddSingleton<IUpdateEmployeeWorkdaySchedule, UpdateEmployeeWorkdaySchedule>();
            instance.AddSingleton<IGetEmployeeWorkdayScheduleByEmployee, GetEmployeeWorkdayScheduleByEmployee>();
            instance.AddSingleton<IEmployeeWorkdayScheduleManager, EmployeeWorkdayScheduleManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EmploymentStatus(this IServiceCollection instance)
        {
            instance.AddTransient<IEmploymentStatusConverter, EmploymentStatusConverter>();
            instance.AddSingleton<IGetEmploymentStatusById, GetEmploymentStatusById>();
            instance.AddSingleton<IGetEmploymentStatusList, GetEmploymentStatusList>();
            instance.AddSingleton<IEmploymentStatusManager, EmploymentStatusManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_EssayQuestion(this IServiceCollection instance)
        {
            instance.AddTransient<IEssayQuestionConverter, EssayQuestionConverter>();
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
            instance.AddTransient<IExamConverter, ExamConverter>();
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
            instance.AddTransient<IExamEssayAnswerConverter, ExamEssayAnswerConverter>();
            instance.AddSingleton<IDeleteExamEssayAnswer, DeleteExamEssayAnswer>();
            instance.AddSingleton<IGetExamEssayAnswerList, GetExamEssayAnswerList>();
            instance.AddSingleton<IInsertExamEssayAnswer, InsertExamEssayAnswer>();
            instance.AddSingleton<IUpdateExamEssayAnswer, UpdateExamEssayAnswer>();
            instance.AddSingleton<IExamEssayAnswerManager, ExamEssayAnswerManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_ExamMultipleChoiceAnswer(this IServiceCollection instance)
        {
            instance.AddTransient<IExamMultipleChoiceAnswerConverter, ExamMultipleChoiceAnswerConverter>();
            instance.AddSingleton<IDeleteExamMultipleChoiceAnswer, DeleteExamMultipleChoiceAnswer>();
            instance.AddSingleton<IGetExamMultipleChoiceAnswerList, GetExamMultipleChoiceAnswerList>();
            instance.AddSingleton<IInsertExamMultipleChoiceAnswer, InsertExamMultipleChoiceAnswer>();
            instance.AddSingleton<IUpdateExamMultipleChoiceAnswer, UpdateExamMultipleChoiceAnswer>();
            instance.AddSingleton<IExamMultipleChoiceAnswerManager, ExamMultipleChoiceAnswerManager>();

            return instance;
        }

        public static IServiceCollection UseSqServer_ExamSet(this IServiceCollection instance)
        {
            instance.AddTransient<IExamSetConverter, ExamSetConverter>();
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
            instance.AddTransient<ILocatorConverter, LocatorConverter>();
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
            instance.AddTransient<ILocatorLeaveTypeConverter, LocatorLeaveTypeConverter>();
            instance.AddSingleton<IGetLocatorLeaveTypeById, GetLocatorLeaveTypeById>();
            instance.AddSingleton<IGetLocatorLeaveTypeList, GetLocatorLeaveTypeList>();
            instance.AddSingleton<ILocatorLeaveTypeManager, LocatorLeaveTypeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_MultipleChoiceCandidateAnswer(this IServiceCollection instance)
        {
            instance.AddTransient<IMultipleChoiceCandidateAnswerConverter, MultipleChoiceCandidateAnswerConverter>();
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
            instance.AddTransient<IMultipleChoiceQuestionConverter, MultipleChoiceQuestionConverter>();
            instance.AddSingleton<IDeleteMultipleChoiceQuestion, DeleteMultipleChoiceQuestion>();
            instance.AddSingleton<IGetMultipleChoiceQuestionById, GetMultipleChoiceQuestionById>();
            instance.AddSingleton<IGetMultipleChoiceQuestionList, GetMultipleChoiceQuestionList>();
            instance.AddSingleton<IInsertMultipleChoiceQuestion, InsertMultipleChoiceQuestion>();
            instance.AddSingleton<IUpdateMultipleChoiceQuestion, UpdateMultipleChoiceQuestion>();
            instance.AddSingleton<IMultipleChoiceQuestionManager, MultipleChoiceQuestionManager>();

            return instance;
        }
        
        public static IServiceCollection UseSqlServer_PayrollContractualDepartment(this IServiceCollection instance)
        {
            instance.AddTransient<IPayrollContractualDepartmentConverter, PayrollContractualDepartmentConverter>();
            instance.AddSingleton<IPayrollContractualDepartmentFields, PayrollContractualDepartmentFields>();
            instance.AddSingleton<IPayrollContractualDepartmentParameters, PayrollContractualDepartmentParameters>();
            instance.AddSingleton<IGeneratePayrollContractualDepartmentList, GeneratePayrollContractualDepartmentList>();
            instance.AddSingleton<IPayrollContractualDepartmentManager, PayrollContractualDepartmentManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_PayrollContractualEmployee(this IServiceCollection instance)
        {
            instance.AddTransient<IPayrollContractualEmployeeConverter, PayrollContractualEmployeeConverter>();
            instance.AddSingleton<IPayrollContractualEmployeeFields, PayrollContractualEmployeeFields>();
            instance.AddSingleton<IPayrollContractualEmployeeParameters, PayrollContractualEmployeeParameters>();
            instance.AddSingleton<IInsertPayrollContractualEmployee<SqlConnection, SqlTransaction>, InsertPayrollContractualEmployee>();
            instance.AddSingleton<IGeneratePayrollContractualEmployeeList, GeneratePayrollContractualEmployeeList>();
            instance.AddSingleton<IGeneratePayrollContractualEmployeeListByDepartment, GeneratePayrollContractualEmployeeListByDepartment>();
            instance.AddSingleton<IPayrollContractualEmployeeManager<SqlConnection, SqlTransaction>, PayrollContractualEmployeeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_PayrollCutOff(this IServiceCollection instance)
        {
            instance.AddTransient<IPayrollCutOffConverter, PayrollCutOffConverter>();
            instance.AddSingleton<IGetPayrollCutOffById, GetPayrollCutOffById>();
            instance.AddSingleton<IGetPayrollCutOffList, GetPayrollCutOffList>();
            instance.AddSingleton<IPayrollCutOffManager, PayrollCutOffManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_PayrollDepartment(this IServiceCollection instance)
        {
            instance.AddSingleton<IPayrollDepartmentFields, PayrollDepartmentFields>();
            instance.AddSingleton<IPayrollDepartmentParameters, PayrollDepartmentParameters>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_PayrollType(this IServiceCollection instance)
        {
            instance.AddTransient<IPayrollTypeConverter, PayrollTypeConverter>();
            instance.AddSingleton<IGetPayrollTypeById, GetPayrollTypeById>();
            instance.AddSingleton<IGetPayrollTypeList, GetPayrollTypeList>();
            instance.AddSingleton<IPayrollTypeManager, PayrollTypeManager>();
            instance.AddSingleton<IPayrollTypeInitializer, PayrollTypeInitializer>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_Position(this IServiceCollection instance)
        {
            instance.AddTransient<IPositionConverter, PositionConverter>();
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
            instance.AddTransient<ISalaryGradeConverter, SalaryGradeConverter>();
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
            instance.AddTransient<ISalaryGradeBatchConverter, SalaryGradeBatchConverter>();
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
            instance.AddTransient<ISalaryGradeStepConverter, SalaryGradeStepConverter>();
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
            instance.AddTransient<ITimeLogConverter, TimeLogConverter>();
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
            instance.AddTransient<ITimeLogTypeConverter, TimeLogTypeConverter>();
            instance.AddSingleton<IGetTimeLogTypeById, GetTimeLogTypeById>();
            instance.AddSingleton<IGetTimeLogTypeList, GetTimeLogTypeList>();
            instance.AddSingleton<ITimeLogTypeManager, TimeLogTypeManager>();

            return instance;
        }

        public static IServiceCollection UseSqlServer_WorkTimeSchedule(this IServiceCollection instance)
        {
            instance.AddTransient<IWorkTimeScheduleConverter, WorkTimeScheduleConverter>();
            instance.AddSingleton<IWorkTimeScheduleFields, WorkTimeScheduleFields>();
            instance.AddSingleton<IWorkTimeScheduleParameters, WorkTimeScheduleParameters>();
            instance.AddSingleton<IDeleteWorkTimeSchedule, DeleteWorkTimeSchedule>();
            instance.AddSingleton<IGetWorkTimeScheduleById, GetWorkTimeScheduleById>();
            instance.AddSingleton<IGetWorkTimeScheduleList, GetWorkTimeScheduleList>();
            instance.AddSingleton<IInsertWorkTimeSchedule, InsertWorkTimeSchedule>();
            instance.AddSingleton<IUpdateWorkTimeSchedule, UpdateWorkTimeSchedule>();
            instance.AddSingleton<IWorkTimeScheduleManager, WorkTimeScheduleManager>();

            return instance;
        }
    }
}
