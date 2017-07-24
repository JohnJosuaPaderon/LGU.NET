using LGU.Entities.Core;
using System;

namespace LGU.Entities.HumanResource
{
    public class ApplicationDocument : Document
    {
        public ApplicationDocument(Application application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public Application Application { get; }
    }
}
