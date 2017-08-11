using System;
using System.Threading.Tasks;

namespace LGU.Reports
{
    public interface IExport : IDisposable
    {
        void Export();
        Task ExportAsync();
        IExportEventHandler EventHandler { get; set; }
        bool PrintAfterSave { get; set; }
    }
}
