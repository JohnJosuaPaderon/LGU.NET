using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace LGU
{
    public interface IConnectionString
    {
        string Key { get; set; }
        SecureString Value { get; set; }
    }
}
