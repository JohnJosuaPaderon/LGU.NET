using System;
using System.Collections.Generic;
using System.Text;

namespace LGU
{
    public interface IContainer
    {
        void Register<TTarget, TValue>();
        void Register(Type targetType, Type valueType);
    }
}
