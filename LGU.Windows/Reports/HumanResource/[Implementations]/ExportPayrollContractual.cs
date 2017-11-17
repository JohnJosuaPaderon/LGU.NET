using LGU.Entities.HumanResource;
using LGU.Extensions;
using LGU.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public sealed class ExportPayrollContractual : ExcelExportBase, IExportPayrollContractual
    {
        public ExportPayrollContractual(IPayrollContractualReportInfoProvider infoProvider, IPayrollContractualHeaderWriter headerWriter)
        {
            _InfoProvider = infoProvider;
            _HeaderWriter = headerWriter;
        }

        private readonly IPayrollContractualReportInfoProvider _InfoProvider;
        private readonly IPayrollContractualHeaderWriter _HeaderWriter;

        public IPayrollContractual PayrollContractual { get; set; }

        public void Export()
        {
            try
            {
                Initialize();
                OpenTemplate(_InfoProvider.Template);
                SetActiveWorksheet(1);
            }
            catch (Exception ex)
            {
                EventHandler?.OnException(ex);
            }

            int employeeCounter = 0;

            if (!Faulted)
            {
                foreach (var department in PayrollContractual.Departments)
                {
                    employeeCounter = 1;

                    if (department.Employees.Count <= _InfoProvider.MaxItemPerSheet)
                    {
                        DuplicateTemplate($"{department.Ordinal}");
                        Write(department, department.Employees, true, ref employeeCounter);
                    }
                    else
                    {
                        WriteCompound(department, ref employeeCounter);
                    }
                }

                TrySave();
                TryPrint();
            }
        }

        private void TrySave()
        {
            try
            {
                DirectoryResolver.Resolve(_InfoProvider.SaveDirectory);
                var path = Path.Combine(_InfoProvider.SaveDirectory, $"{PayrollContractual.RangeDate.ToFormattedString()}_{PayrollContractual.RunDate.ToString("yyyy-MM-dd-HH-mm")}_{DateTime.Now.ToString("yyyy-MM-dd-HH-mm")}.xlsx");
                TemplateWorksheet.Delete();
                Workbook.SaveAs(path);
                EventHandler?.OnExported(path);
            }
            catch (Exception ex)
            {
                EventHandler?.OnException(ex);
            }
        }

        private void TryPrint()
        {
            if (_InfoProvider.PrintAfterSave)
            {
                try
                {
                    Workbook.PrintOutEx();
                }
                catch (Exception ex)
                {
                    EventHandler?.OnException(ex);
                }
            }
        }

        private void WriteCompound(IPayrollContractualDepartment department, ref int employeeCounter)
        {
            var pagesM = decimal.Ceiling(department.Employees.Count / (decimal)_InfoProvider.MaxItemPerSheet);
            var pages = decimal.ToInt32(pagesM);

            var pageCounter = 1;

            var employees = new List<IPayrollContractualEmployee>();

            foreach (var employee in department.Employees)
            {
                employees.Add(employee);

                if (employees.Count >= _InfoProvider.MaxItemPerSheet || pageCounter >= pages)
                {
                    DuplicateTemplate($"{department.Ordinal}-{pageCounter}");
                    Write(department, employees, pageCounter >= pages, ref employeeCounter);
                    pageCounter++;
                    employees.Clear();
                }
            }
        }

        private void Write(IPayrollContractualDepartment department)
        {
            WriteHeaders();
            WriteSignatories();
            SetCellValue(_InfoProvider.DepartmentCell, department?.Department?.Description);
            WriteSignatory(department.Head, _InfoProvider.HeadCell, _InfoProvider.HeadTitleCell);
        }

        private void WriteSignatories()
        {
            WriteSignatory(PayrollContractual.Mayor, _InfoProvider.MayorCell, _InfoProvider.MayorTitleCell);
            WriteSignatory(PayrollContractual.HumanResourceHead, _InfoProvider.HumanResourceHeadCell, _InfoProvider.HumanResourceHeadTitleCell);
            WriteSignatory(PayrollContractual.Treasurer, _InfoProvider.TreasurerCell, _InfoProvider.TreasurerTitleCell);
            WriteSignatory(PayrollContractual.CityAccountant, _InfoProvider.AccountantCell, _InfoProvider.AccountantTitleCell);
            WriteSignatory(PayrollContractual.CityBudgetOfficer, _InfoProvider.BudgetOfficerCell, _InfoProvider.BudgetOfficerTitleCell);
        }

        private void WriteSignatory(IEmployee signatory, ExcelCell nameCell, ExcelCell titleCell)
        {
            SetCellValue(nameCell, signatory?.InformalFullName);
            SetCellValue(titleCell, signatory?.Title);
        }

        private void Write(IPayrollContractualDepartment department, IEnumerable<IPayrollContractualEmployee> employees, bool writeSumation, ref int employeeCounter)
        {
            Write(department);

            var row = _InfoProvider.ItemRowStart;

            foreach (var employee in employees)
            {

                SetCellValue(row, _InfoProvider.EmployeeColumn, employee.Employee.FullName);
                SetCellValue(row, _InfoProvider.DesignationColumn, employee.Employee.Position?.Description);
                SetCellValue(row, _InfoProvider.MonthlyRateColumn, employee.MonthlyRate);
                SetCellValue(row, _InfoProvider.AmountAccruedColumn, employee.AmountAccrued);
                SetCellValue(row, _InfoProvider.LeftCounterColumn, employeeCounter);
                SetCellValue(row, _InfoProvider.RightCounterColumn, employeeCounter);
                SetCellValue(row, _InfoProvider.AmountPaidColumn, employee.AmountPaid);

                SetCellValueIfNotDefault(row, _InfoProvider.HdmfPremiumPsColumn, employee.HdmfPremiumPs);
                SetCellValueIfNotDefault(row, _InfoProvider.WithholdingTaxColumn, employee.WithholdingTax);

                row++;
                employeeCounter++;
            }

            if (writeSumation)
            {
                SetCellValue(row, _InfoProvider.EmployeeColumn, "GRAND TOTAL");
                SetCellValue(row, _InfoProvider.MonthlyRateColumn, department.Employees.TotalMonthlyRate);
                SetCellValue(row, _InfoProvider.AmountAccruedColumn, department.Employees.TotalAmountAccrued);
                SetCellValue(row, _InfoProvider.AmountPaidColumn, department.Employees.TotalAmountPaid);

                SetCellValueIfNotDefault(row, _InfoProvider.HdmfPremiumPsColumn, department.Employees.TotalHdmfPremiumPs);
                SetCellValueIfNotDefault(row, _InfoProvider.WithholdingTaxColumn, department.Employees.TotalWithholdingTax);
            }
        }

        private void WriteHeaders()
        {
            _HeaderWriter.PayrollContractual = PayrollContractual;
            _HeaderWriter.Write(GetCell(_InfoProvider.HeadingMessageCell));

            if (PayrollContractual.Inclusion.HdmfPremiumPs)
            {
                SetCellValue(_InfoProvider.HdmfPremiumPsHeaderCell, "HDMF Premium PS");
            }
        }

        public async Task ExportAsync()
        {
            await Task.Run(() => Export());
        }
    }
}
