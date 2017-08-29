using LGU.Entities.Core;
using System;

namespace LGU.Entities.HumanResource
{
    public class ApplicationDocument : Document, IApplicationDocument
    {
        public ApplicationDocument(IApplication application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public IApplication Application { get; }
    }
}
