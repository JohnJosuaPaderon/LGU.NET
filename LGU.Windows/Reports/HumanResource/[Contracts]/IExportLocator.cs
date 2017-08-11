using LGU.Entities.HumanResource;

namespace LGU.Reports.HumanResource
{
    public interface IExportLocator : IExport
    {
        Locator Locator { get; set; }
    }
}
