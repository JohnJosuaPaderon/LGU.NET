using System;
using System.IO;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace LGU.Reports
{
    public abstract class WordExportBase : IDisposable
    {
        protected void Initialize()
        {
            Application = new Word.Application()
            {
                DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
            };
        }

        protected void OpenTemplate(string templatePath)
        {
            if (Application != null)
            {
                if (File.Exists(templatePath))
                {
                    Documents = Application.Documents;
                    Document = Documents.Add(templatePath);
                }
                else
                {
                    EventHandler?.OnError($"Template not found: '{templatePath}'");
                }
            }
            else
            {
                EventHandler?.OnError("Microsoft Office Word is not running.");
            }
        }

        protected Word.Application Application { get; private set; }
        protected Word.Documents Documents { get; private set; }
        protected Word.Document Document { get; private set; }
        public IExportEventHandler EventHandler { get; set; }
        public bool PrintAfterSave { get; set; }

        public virtual void Dispose()
        {
            if (Document != null)
            {
                Document.Close();
                Marshal.ReleaseComObject(Document);
                Document = null;
            }

            if (Documents != null)
            {
                foreach (Word.Document document in Documents)
                {
                    document.Close();
                    Marshal.ReleaseComObject(document);
                }

                Marshal.ReleaseComObject(Documents);
                Documents = null;
            }

            if (Application != null)
            {
                Application.Quit();
                Marshal.ReleaseComObject(Application);
                Application = null;
            }
        }

        protected virtual void SaveAs(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Document.SaveAs2(filePath);
                EventHandler?.OnExported(filePath);

                if (PrintAfterSave)
                {
                    Document.PrintOut();
                }
            }
            else
            {
                EventHandler?.OnError($"Failed to save document, file already exists.");
            }
        }
    }
}
