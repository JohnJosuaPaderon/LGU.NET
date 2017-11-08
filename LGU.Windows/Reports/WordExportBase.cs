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
            try
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
            catch (Exception ex)
            {
                EventHandler?.OnException(ex);
            }
        }

        protected Word.Application Application { get; private set; }
        protected Word.Documents Documents { get; private set; }
        protected Word.Document Document { get; private set; }
        public IExportEventHandler EventHandler { get; set; }
        public bool PrintAfterSave { get; set; }
        protected bool SaveDocumentChangesOnClosing { get; set; }

        public virtual void Dispose()
        {
            if (Document != null)
            {
                Document.Close(SaveChanges: SaveDocumentChangesOnClosing);
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
                try
                {
                    Document.SaveAs(filePath);
                    EventHandler?.OnExported(filePath);
                }
                catch (Exception ex)
                {
                    EventHandler?.OnException(ex);
                }

                if (PrintAfterSave)
                {
                    Print();
                }
            }
            else
            {
                EventHandler?.OnError($"Failed to save document, file already exists.");
            }
        }

        protected void Print()
        {
            Document.PrintOut();
        }
    }
}
