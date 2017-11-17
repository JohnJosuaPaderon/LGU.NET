namespace LGU.Reports.HumanResource
{
    public sealed class PayrollContractualReportInfoProvider : ExcelReportInfoProvider, IPayrollContractualReportInfoProvider
    {
        private const string APP_SETTING_OWNER = "HumanResource.PayrollContractual";

        public PayrollContractualReportInfoProvider() : base(APP_SETTING_OWNER)
        {
            Template = GetReportTemplatePath(nameof(Template));
            SaveDirectory = GetReportDirectory(nameof(SaveDirectory));
            PrintAfterSave = GetBoolean(nameof(PrintAfterSave));
            MaxItemPerSheet = GetInt32(nameof(MaxItemPerSheet));
            HeadingMessageCell = GetCell(nameof(HeadingMessageCell));
            DepartmentCell = GetCell(nameof(DepartmentCell));
            MayorCell = GetCell(nameof(MayorCell));
            MayorTitleCell = GetCell(nameof(MayorTitleCell));
            HumanResourceHeadCell = GetCell(nameof(HumanResourceHeadCell));
            HumanResourceHeadTitleCell = GetCell(nameof(HumanResourceHeadTitleCell));
            TreasurerCell = GetCell(nameof(TreasurerCell));
            TreasurerTitleCell = GetCell(nameof(TreasurerTitleCell));
            AccountantCell = GetCell(nameof(AccountantCell));
            AccountantTitleCell = GetCell(nameof(AccountantTitleCell));
            BudgetOfficerCell = GetCell(nameof(BudgetOfficerCell));
            BudgetOfficerTitleCell = GetCell(nameof(BudgetOfficerTitleCell));
            HeadCell = GetCell(nameof(HeadCell));
            HeadTitleCell = GetCell(nameof(HeadTitleCell));
            LeftCounterColumn = GetInt32(nameof(LeftCounterColumn));
            RightCounterColumn = GetInt32(nameof(RightCounterColumn));
            EmployeeColumn = GetInt32(nameof(EmployeeColumn));
            DesignationColumn = GetInt32(nameof(DesignationColumn));
            MonthlyRateColumn = GetInt32(nameof(MonthlyRateColumn));
            AmountAccruedColumn = GetInt32(nameof(AmountAccruedColumn));
            AmountPaidColumn = GetInt32(nameof(AmountPaidColumn));
            HdmfPremiumPsColumn = GetInt32(nameof(HdmfPremiumPsColumn));
            WithholdingTaxColumn = GetInt32(nameof(WithholdingTaxColumn));
            ItemRowStart = GetInt32(nameof(ItemRowStart));
            HdmfPremiumPsHeaderCell = GetCell(nameof(HdmfPremiumPsHeaderCell));
        }

        public string Template { get; }
        public string SaveDirectory { get; }
        public bool PrintAfterSave { get; }
        public int MaxItemPerSheet { get; }
        public ExcelCell HeadingMessageCell { get; }
        public ExcelCell DepartmentCell { get; }
        public ExcelCell MayorCell { get; }
        public ExcelCell MayorTitleCell { get; }
        public ExcelCell HumanResourceHeadCell { get; }
        public ExcelCell HumanResourceHeadTitleCell { get; }
        public ExcelCell TreasurerCell { get; }
        public ExcelCell TreasurerTitleCell { get; }
        public ExcelCell AccountantCell { get; }
        public ExcelCell AccountantTitleCell { get; }
        public ExcelCell BudgetOfficerCell { get; }
        public ExcelCell BudgetOfficerTitleCell { get; }
        public ExcelCell HeadCell { get; }
        public ExcelCell HeadTitleCell { get; }
        public int LeftCounterColumn { get; }
        public int EmployeeColumn { get; }
        public int DesignationColumn { get; }
        public int MonthlyRateColumn { get; }
        public int AmountAccruedColumn { get; }
        public int AmountPaidColumn { get; }
        public int HdmfPremiumPsColumn { get; }
        public int WithholdingTaxColumn { get; }
        public int RightCounterColumn { get; }
        public int ItemRowStart { get; }
        public ExcelCell HdmfPremiumPsHeaderCell { get; }
    }
}
