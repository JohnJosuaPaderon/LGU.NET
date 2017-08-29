using LGU.Entities.HumanResource;

namespace LGU.Reports.HumanResource
{
    public interface IExportLocator : IExport
    {
        ILocator Locator { get; set; }
    }
}
