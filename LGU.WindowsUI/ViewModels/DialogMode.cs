using System;

namespace LGU.ViewModels
{
    [Flags]
    public enum DialogMode
    {
        NotSet = 0,
        Add = 1,
        Edit = 2,
        Delete = 3
    }
}
