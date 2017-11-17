namespace LGU.Reports.HumanResource
{
    public interface IPayrollContractualReportInfoProvider
    {
        string Template { get; }
        string SaveDirectory { get; }
        bool PrintAfterSave { get; }
        int MaxItemPerSheet { get; }
        ExcelCell HeadingMessageCell { get; }
        ExcelCell DepartmentCell { get; }
        ExcelCell MayorCell { get; }
        ExcelCell MayorTitleCell { get; }
        ExcelCell HumanResourceHeadCell { get; }
        ExcelCell HumanResourceHeadTitleCell { get; }
        ExcelCell TreasurerCell { get; }
        ExcelCell TreasurerTitleCell { get; }
        ExcelCell AccountantCell { get; }
        ExcelCell AccountantTitleCell { get; }
        ExcelCell BudgetOfficerCell { get; }
        ExcelCell BudgetOfficerTitleCell { get; }
        ExcelCell HeadCell { get; }
        ExcelCell HeadTitleCell { get; }
        int LeftCounterColumn { get; }
        int RightCounterColumn { get; }
        int EmployeeColumn { get; }
        int DesignationColumn { get; }
        int MonthlyRateColumn { get; }
        int AmountAccruedColumn { get; }
        int AmountPaidColumn { get; }
        int HdmfPremiumPsColumn { get; }
        int WithholdingTaxColumn { get; }
        int ItemRowStart { get; }
        ExcelCell HdmfPremiumPsHeaderCell { get; }
    }
}
