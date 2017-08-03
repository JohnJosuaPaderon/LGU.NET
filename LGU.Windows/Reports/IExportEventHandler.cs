using System;

namespace LGU.Reports
{
    public interface IExportEventHandler
    {
        void OnException(Exception exception);
        void OnError(string message);
        void OnExported();
    }
}
