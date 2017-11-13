using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.EntityProcesses.HumanResource;
using Unity;

namespace LGU.Extensions
{
    public static class IUnityContainerExtension
    {
        public static IUnityContainer UseSqlServer(this IUnityContainer instance)
        {
            instance.UseSqlServerForHumanResource();

            return instance;
        }

        public static IUnityContainer UseSqlServerForHumanResource(this IUnityContainer instance)
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

        public static IUnityContainer UseSqlServer_Applicant(this IUnityContainer instance)
        {
            instance.RegisterType<IApplicantConverter, ApplicantConverter>();
            instance.RegisterType<IDeleteApplicant, DeleteApplicant>();
            instance.RegisterType<IGetApplicantById, GetApplicantById>();
            instance.RegisterType<IGetApplicantList, GetApplicantList>();
            instance.RegisterType<IInsertApplicant, InsertApplicant>();
            instance.RegisterType<IUpdateApplicant, UpdateApplicant>();
            instance.RegisterType<IApplicantManager, ApplicantManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_ApplicantStatus(this IUnityContainer instance)
        {
            instance.RegisterType<IApplicantStatusConverter, ApplicantStatusConverter>();
            instance.RegisterType<IGetApplicantStatusById, GetApplicantStatusById>();
            instance.RegisterType<IGetApplicantStatusList, GetApplicantStatusList>();
            instance.RegisterType<IApplicantStatusManager, ApplicantStatusManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_Application(this IUnityContainer instance)
        {
            instance.RegisterType<IApplicationConverter, ApplicationConverter>();
            instance.RegisterType<IDeleteApplication, DeleteApplication>();
            instance.RegisterType<IGetApplicationById, GetApplicationById>();
            instance.RegisterType<IGetApplicationList, GetApplicationList>();
            instance.RegisterType<IInsertApplication, InsertApplication>();
            instance.RegisterType<IUpdateApplication, UpdateApplication>();
            instance.RegisterType<IApplicationManager, ApplicationManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_ApplicationDocument(this IUnityContainer instance)
        {
            instance.RegisterType<IApplicationDocumentConverter, ApplicationDocumentConverter>();
            instance.RegisterType<IDeleteApplicationDocument, DeleteApplicationDocument>();
            instance.RegisterType<IGetApplicationDocumentById, GetApplicationDocumentById>();
            instance.RegisterType<IGetApplicationDocumentList, GetApplicationDocumentList>();
            instance.RegisterType<IInsertApplicationDocument, InsertApplicationDocument>();
            instance.RegisterType<IUpdateApplicationDocument, UpdateApplicationDocument>();
            instance.RegisterType<IApplicationDocumentManager, ApplicationDocumentManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_CalendarEvent(this IUnityContainer instance)
        {
            instance.RegisterType<ICalendarEventConverter, CalendarEventConverter>();
            instance.RegisterType<ICalendarEventFields, CalendarEventFields>();
            instance.RegisterType<ICalendarEventParameters, CalendarEventParameters>();
            instance.RegisterType<IDeleteCalendarEvent, DeleteCalendarEvent>();
            instance.RegisterType<IGetCalendarEventById, GetCalendarEventById>();
            instance.RegisterType<IInsertCalendarEvent, InsertCalendarEvent>();
            instance.RegisterType<IUpdateCalendarEvent, UpdateCalendarEvent>();
            instance.RegisterType<IGetCalendarEventList, GetCalendarEventList>();
            instance.RegisterType<ICalendarEventManager, CalendarEventManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_Department(this IUnityContainer instance)
        {
            instance.RegisterType<IDepartmentConverter, DepartmentConverter>();
            instance.RegisterType<IDepartmentParameters, DepartmentParameters>();
            instance.RegisterType<IDepartmentFields, DepartmentFields>();
            instance.RegisterType<IDeleteDepartment, DeleteDepartment>();
            instance.RegisterType<IGetDepartmentById, GetDepartmentById>();
            instance.RegisterType<IGetDepartmentList, GetDepartmentList>();
            instance.RegisterType<ISearchDepartment, SearchDepartment>();
            instance.RegisterType<IInsertDepartment, InsertDepartment>();
            instance.RegisterType<IUpdateDepartment, UpdateDepartment>();
            instance.RegisterType<IGetDepartmentListWithTimeLog, GetDepartmentListWithTimeLog>();
            instance.RegisterType<IDepartmentManager, DepartmentManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_Employee(this IUnityContainer instance)
        {
            instance.RegisterType<IEmployeeConverter, EmployeeConverter>();
            instance.RegisterType<IEmployeeParameters, EmployeeParameters>();
            instance.RegisterType<IEmployeeFields, EmployeeFields>();
            instance.RegisterType<IDeleteEmployee, DeleteEmployee>();
            instance.RegisterType<IGetEmployeeById, GetEmployeeById>();
            instance.RegisterType<IGetEmployeeList, GetEmployeeList>();
            instance.RegisterType<IInsertEmployee, InsertEmployee>();
            instance.RegisterType<IUpdateEmployee, UpdateEmployee>();
            instance.RegisterType<ISearchEmployee, SearchEmployee>();
            instance.RegisterType<IGetEmployeeListWithTimeLog, GetEmployeeListWithTimeLog>();
            instance.RegisterType<ISearchEmployeeWithTimeLog, SearchEmployeeWithTimeLog>();
            instance.RegisterType<IGetEmployeeListWithTimeLogByDepartment, GetEmployeeListWithTimeLogByDepartment>();
            instance.RegisterType<IGetEmployeeListByPayrollType, GetEmployeeListByPayrollType>();
            instance.RegisterType<IEmployeeManager, EmployeeManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_EmployeeFlexWorkSchedule(this IUnityContainer instance)
        {
            instance.RegisterType<IEmployeeFlexWorkScheduleFields, EmployeeFlexWorkScheduleFields>();
            instance.RegisterType<IEmployeeFlexWorkScheduleParameters, EmployeeFlexWorkScheduleParameters>();
            instance.RegisterType<IEmployeeFlexWorkScheduleConverter, EmployeeFlexWorkScheduleConverter>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_EmployeeSalaryGradeStep(this IUnityContainer instance)
        {
            instance.RegisterType<IEmployeeSalaryGradeStepConverter, EmployeeSalaryGradeStepConverter>();
            instance.RegisterType<IDeleteEmployeeSalaryGradeStep, DeleteEmployeeSalaryGradeStep>();
            instance.RegisterType<IGetEmployeeSalaryGradeStepList, GetEmployeeSalaryGradeStepList>();
            instance.RegisterType<IInsertEmployeeSalaryGradeStep, InsertEmployeeSalaryGradeStep>();
            instance.RegisterType<IUpdateEmployeeSalaryGradeStep, UpdateEmployeeSalaryGradeStep>();
            instance.RegisterType<IEmployeeSalaryGradeStepManager, EmployeeSalaryGradeStepManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_EmployeeType(this IUnityContainer instance)
        {
            instance.RegisterType<IEmployeeTypeConverter, EmployeeTypeConverter>();
            instance.RegisterType<IGetEmployeeTypeById, GetEmployeeTypeById>();
            instance.RegisterType<IGetEmployeeTypeList, GetEmployeeTypeList>();
            instance.RegisterType<IEmployeeTypeManager, EmployeeTypeManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_EmployeeWorkdaySchedule(this IUnityContainer instance)
        {
            instance.RegisterType<IEmployeeWorkdayScheduleConverter, EmployeeWorkdayScheduleConverter>();
            instance.RegisterType<IEmployeeWorkdayScheduleParameters, EmployeeWorkdayScheduleParameters>();
            instance.RegisterType<IDeleteEmployeeWorkdaySchedule, DeleteEmployeeWorkdaySchedule>();
            instance.RegisterType<IGetEmployeeWorkdayScheduleById, GetEmployeeWorkdayScheduleById>();
            instance.RegisterType<IInsertEmployeeWorkdaySchedule, InsertEmployeeWorkdaySchedule>();
            instance.RegisterType<IUpdateEmployeeWorkdaySchedule, UpdateEmployeeWorkdaySchedule>();
            instance.RegisterType<IGetEmployeeWorkdayScheduleByEmployee, GetEmployeeWorkdayScheduleByEmployee>();
            instance.RegisterType<IEmployeeWorkdayScheduleManager, EmployeeWorkdayScheduleManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_EmploymentStatus(this IUnityContainer instance)
        {
            instance.RegisterType<IEmploymentStatusConverter, EmploymentStatusConverter>();
            instance.RegisterType<IGetEmploymentStatusById, GetEmploymentStatusById>();
            instance.RegisterType<IGetEmploymentStatusList, GetEmploymentStatusList>();
            instance.RegisterType<IEmploymentStatusManager, EmploymentStatusManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_EssayQuestion(this IUnityContainer instance)
        {
            instance.RegisterType<IEssayQuestionConverter, EssayQuestionConverter>();
            instance.RegisterType<IDeleteEssayQuestion, DeleteEssayQuestion>();
            instance.RegisterType<IGetEssayQuestionById, GetEssayQuestionById>();
            instance.RegisterType<IGetEssayQuestionList, GetEssayQuestionList>();
            instance.RegisterType<IInsertEssayQuestion, InsertEssayQuestion>();
            instance.RegisterType<IUpdateEssayQuestion, UpdateEssayQuestion>();
            instance.RegisterType<IEssayQuestionManager, EssayQuestionManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_Exam(this IUnityContainer instance)
        {
            instance.RegisterType<IExamConverter, ExamConverter>();
            instance.RegisterType<IDeleteExam, DeleteExam>();
            instance.RegisterType<IGetExamById, GetExamById>();
            instance.RegisterType<IGetExamList, GetExamList>();
            instance.RegisterType<IInsertExam, InsertExam>();
            instance.RegisterType<IUpdateExam, UpdateExam>();
            instance.RegisterType<IExamManager, ExamManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_ExamEssayAnswer(this IUnityContainer instance)
        {
            instance.RegisterType<IExamEssayAnswerConverter, ExamEssayAnswerConverter>();
            instance.RegisterType<IDeleteExamEssayAnswer, DeleteExamEssayAnswer>();
            instance.RegisterType<IGetExamEssayAnswerList, GetExamEssayAnswerList>();
            instance.RegisterType<IInsertExamEssayAnswer, InsertExamEssayAnswer>();
            instance.RegisterType<IUpdateExamEssayAnswer, UpdateExamEssayAnswer>();
            instance.RegisterType<IExamEssayAnswerManager, ExamEssayAnswerManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_ExamMultipleChoiceAnswer(this IUnityContainer instance)
        {
            instance.RegisterType<IExamMultipleChoiceAnswerConverter, ExamMultipleChoiceAnswerConverter>();
            instance.RegisterType<IDeleteExamMultipleChoiceAnswer, DeleteExamMultipleChoiceAnswer>();
            instance.RegisterType<IGetExamMultipleChoiceAnswerList, GetExamMultipleChoiceAnswerList>();
            instance.RegisterType<IInsertExamMultipleChoiceAnswer, InsertExamMultipleChoiceAnswer>();
            instance.RegisterType<IUpdateExamMultipleChoiceAnswer, UpdateExamMultipleChoiceAnswer>();
            instance.RegisterType<IExamMultipleChoiceAnswerManager, ExamMultipleChoiceAnswerManager>();

            return instance;
        }

        public static IUnityContainer UseSqServer_ExamSet(this IUnityContainer instance)
        {
            instance.RegisterType<IExamSetConverter, ExamSetConverter>();
            instance.RegisterType<IDeleteExamSet, DeleteExamSet>();
            instance.RegisterType<IGetExamSetById, GetExamSetById>();
            instance.RegisterType<IGetExamSetList, GetExamSetList>();
            instance.RegisterType<IInsertExamSet, InsertExamSet>();
            instance.RegisterType<IUpdateExamSet, UpdateExamSet>();
            instance.RegisterType<IExamSetManager, ExamSetManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_Locator(this IUnityContainer instance)
        {
            instance.RegisterType<ILocatorConverter, LocatorConverter>();
            instance.RegisterType<IDeleteLocator, DeleteLocator>();
            instance.RegisterType<IGetLocatorById, GetLocatorById>();
            instance.RegisterType<IGetLocatorList, GetLocatorList>();
            instance.RegisterType<IInsertLocator, InsertLocator>();
            instance.RegisterType<IUpdateLocator, UpdateLocator>();
            instance.RegisterType<ILocatorManager, LocatorManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_LocatorLeaveType(this IUnityContainer instance)
        {
            instance.RegisterType<ILocatorLeaveTypeConverter, LocatorLeaveTypeConverter>();
            instance.RegisterType<IGetLocatorLeaveTypeById, GetLocatorLeaveTypeById>();
            instance.RegisterType<IGetLocatorLeaveTypeList, GetLocatorLeaveTypeList>();
            instance.RegisterType<ILocatorLeaveTypeManager, LocatorLeaveTypeManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_MultipleChoiceCandidateAnswer(this IUnityContainer instance)
        {
            instance.RegisterType<IMultipleChoiceCandidateAnswerConverter, MultipleChoiceCandidateAnswerConverter>();
            instance.RegisterType<IDeleteMultipleChoiceCandidateAnswer, DeleteMultipleChoiceCandidateAnswer>();
            instance.RegisterType<IGetMultipleChoiceCandidateAnswerById, GetMultipleChoiceCandidateAnswerById>();
            instance.RegisterType<IGetMultipleChoiceCandidateAnswerList, GetMultipleChoiceCandidateAnswerList>();
            instance.RegisterType<IInsertMultipleChoiceCandidateAnswer, InsertMultipleChoiceCandidateAnswer>();
            instance.RegisterType<IUpdateMultipleChoiceCandidateAnswer, UpdateMultipleChoiceCandidateAnswer>();
            instance.RegisterType<IMultipleChoiceCandidateAnswerManager, MultipleChoiceCandidateAnswerManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_MultipleChoiceQuestion(this IUnityContainer instance)
        {
            instance.RegisterType<IMultipleChoiceQuestionConverter, MultipleChoiceQuestionConverter>();
            instance.RegisterType<IDeleteMultipleChoiceQuestion, DeleteMultipleChoiceQuestion>();
            instance.RegisterType<IGetMultipleChoiceQuestionById, GetMultipleChoiceQuestionById>();
            instance.RegisterType<IGetMultipleChoiceQuestionList, GetMultipleChoiceQuestionList>();
            instance.RegisterType<IInsertMultipleChoiceQuestion, InsertMultipleChoiceQuestion>();
            instance.RegisterType<IUpdateMultipleChoiceQuestion, UpdateMultipleChoiceQuestion>();
            instance.RegisterType<IMultipleChoiceQuestionManager, MultipleChoiceQuestionManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_PayrollContractualDepartment(this IUnityContainer instance)
        {
            instance.RegisterType<IPayrollContractualDepartmentConverter, PayrollContractualDepartmentConverter>();
            instance.RegisterType<IPayrollContractualDepartmentFields, PayrollContractualDepartmentFields>();
            instance.RegisterType<IPayrollContractualDepartmentParameters, PayrollContractualDepartmentParameters>();
            instance.RegisterType<IGeneratePayrollContractualDepartmentList, GeneratePayrollContractualDepartmentList>();
            instance.RegisterType<IPayrollContractualDepartmentManager, PayrollContractualDepartmentManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_PayrollContractualEmployee(this IUnityContainer instance)
        {
            instance.RegisterType<IPayrollContractualEmployeeConverter, PayrollContractualEmployeeConverter>();
            instance.RegisterType<IPayrollContractualEmployeeFields, PayrollContractualEmployeeFields>();
            instance.RegisterType<IPayrollContractualEmployeeParameters, PayrollContractualEmployeeParameters>();
            instance.RegisterType<IInsertPayrollContractualEmployee, InsertPayrollContractualEmployee>();
            instance.RegisterType<IGeneratePayrollContractualEmployeeList, GeneratePayrollContractualEmployeeList>();
            instance.RegisterType<IGeneratePayrollContractualEmployeeListByDepartment, GeneratePayrollContractualEmployeeListByDepartment>();
            instance.RegisterType<IPayrollContractualEmployeeManager, PayrollContractualEmployeeManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_PayrollCutOff(this IUnityContainer instance)
        {
            instance.RegisterType<IPayrollCutOffConverter, PayrollCutOffConverter>();
            instance.RegisterType<IGetPayrollCutOffById, GetPayrollCutOffById>();
            instance.RegisterType<IGetPayrollCutOffList, GetPayrollCutOffList>();
            instance.RegisterType<IPayrollCutOffManager, PayrollCutOffManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_PayrollDepartment(this IUnityContainer instance)
        {
            instance.RegisterType<IPayrollDepartmentFields, PayrollDepartmentFields>();
            instance.RegisterType<IPayrollDepartmentParameters, PayrollDepartmentParameters>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_PayrollType(this IUnityContainer instance)
        {
            instance.RegisterType<IPayrollTypeConverter, PayrollTypeConverter>();
            instance.RegisterType<IGetPayrollTypeById, GetPayrollTypeById>();
            instance.RegisterType<IGetPayrollTypeList, GetPayrollTypeList>();
            instance.RegisterType<IPayrollTypeManager, PayrollTypeManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_Position(this IUnityContainer instance)
        {
            instance.RegisterType<IPositionConverter, PositionConverter>();
            instance.RegisterType<IDeletePosition, DeletePosition>();
            instance.RegisterType<IGetPositionById, GetPositionById>();
            instance.RegisterType<IGetPositionList, GetPositionList>();
            instance.RegisterType<IInsertPosition, InsertPosition>();
            instance.RegisterType<IUpdatePosition, UpdatePosition>();
            instance.RegisterType<IPositionManager, PositionManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_SalaryGrade(this IUnityContainer instance)
        {
            instance.RegisterType<ISalaryGradeConverter, SalaryGradeConverter>();
            instance.RegisterType<IDeleteSalaryGrade, DeleteSalaryGrade>();
            instance.RegisterType<IGetSalaryGradeById, GetSalaryGradeById>();
            instance.RegisterType<IGetSalaryGradeList, GetSalaryGradeList>();
            instance.RegisterType<IInsertSalaryGrade, InsertSalaryGrade>();
            instance.RegisterType<IUpdateSalaryGrade, UpdateSalaryGrade>();
            instance.RegisterType<IGetSalaryGradeListByBatch, GetSalaryGradeListByBatch>();
            instance.RegisterType<ISalaryGradeManager, SalaryGradeManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_SalaryGradeBatch(this IUnityContainer instance)
        {
            instance.RegisterType<ISalaryGradeBatchConverter, SalaryGradeBatchConverter>();
            instance.RegisterType<IDeleteSalaryGradeBatch, DeleteSalaryGradeBatch>();
            instance.RegisterType<IGetSalaryGradeBatchById, GetSalaryGradeBatchById>();
            instance.RegisterType<IGetSalaryGradeBatchList, GetSalaryGradeBatchList>();
            instance.RegisterType<IInsertSalaryGradeBatch, InsertSalaryGradeBatch>();
            instance.RegisterType<IUpdateSalaryGradeBatch, UpdateSalaryGradeBatch>();
            instance.RegisterType<IGetCurrentSalaryGradeBatch, GetCurrentSalaryGradeBatch>();
            instance.RegisterType<ISalaryGradeBatchManager, SalaryGradeBatchManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_SalaryGradeStep(this IUnityContainer instance)
        {
            instance.RegisterType<ISalaryGradeStepConverter, SalaryGradeStepConverter>();
            instance.RegisterType<IDeleteSalaryGradeStep, DeleteSalaryGradeStep>();
            instance.RegisterType<IGetSalaryGradeStepById, GetSalaryGradeStepById>();
            instance.RegisterType<IGetSalaryGradeStepList, GetSalaryGradeStepList>();
            instance.RegisterType<IInsertSalaryGradeStep, InsertSalaryGradeStep>();
            instance.RegisterType<IUpdateSalaryGradeStep, UpdateSalaryGradeStep>();
            instance.RegisterType<IGetSalaryGradeStepListBySalaryGrade, GetSalaryGradeStepListBySalaryGrade>();
            instance.RegisterType<IGetSalaryGradeStepByNumberAndStep, GetSalaryGradeStepByNumberAndStep>();
            instance.RegisterType<IGetCurrentSalaryGradeStepByEmployee, GetCurrentSalaryGradeStepByEmployee>();
            instance.RegisterType<ISalaryGradeStepManager, SalaryGradeStepManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_TimeLog(this IUnityContainer instance)
        {
            instance.RegisterType<ITimeLogConverter, TimeLogConverter>();
            instance.RegisterType<IDeleteTimeLog, DeleteTimeLog>();
            instance.RegisterType<IGetTimeLogById, GetTimeLogById>();
            instance.RegisterType<IGetTimeLogList, GetTimeLogList>();
            instance.RegisterType<IInsertTimeLog, InsertTimeLog>();
            instance.RegisterType<ILogEmployee, LogEmployee>();
            instance.RegisterType<IUpdateTimeLog, UpdateTimeLog>();
            instance.RegisterType<IGetActualTimeLogListByEmployeeCutOff, GetActualTimeLogListByEmployeeCutOff>();
            instance.RegisterType<IGetTimeLogListByCutOff, GetTimeLogListByCutOff>();
            instance.RegisterType<IGetTimeLogListByDepartmentCutOff, GetTimeLogListByDepartmentCutOff>();
            instance.RegisterType<IGetTimeLogListByEmployeeCutOff, GetTimeLogListByEmployeeCutOff>();
            instance.RegisterType<ITimeLogManager, TimeLogManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_TimeLogType(this IUnityContainer instance)
        {
            instance.RegisterType<ITimeLogTypeConverter, TimeLogTypeConverter>();
            instance.RegisterType<IGetTimeLogTypeById, GetTimeLogTypeById>();
            instance.RegisterType<IGetTimeLogTypeList, GetTimeLogTypeList>();
            instance.RegisterType<ITimeLogTypeManager, TimeLogTypeManager>();

            return instance;
        }

        public static IUnityContainer UseSqlServer_WorkTimeSchedule(this IUnityContainer instance)
        {
            instance.RegisterType<IWorkTimeScheduleConverter, WorkTimeScheduleConverter>();
            instance.RegisterType<IDeleteWorkTimeSchedule, DeleteWorkTimeSchedule>();
            instance.RegisterType<IGetWorkTimeScheduleById, GetWorkTimeScheduleById>();
            instance.RegisterType<IGetWorkTimeScheduleList, GetWorkTimeScheduleList>();
            instance.RegisterType<IInsertWorkTimeSchedule, InsertWorkTimeSchedule>();
            instance.RegisterType<IUpdateWorkTimeSchedule, UpdateWorkTimeSchedule>();
            instance.RegisterType<IWorkTimeScheduleManager, WorkTimeScheduleManager>();

            return instance;
        }
    }
}
