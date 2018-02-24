using System;
using System.Collections.Generic;
using System.Text;

namespace Mordor_Cruel_Plan.Factory
{
    interface IFactory<TItem>
    {
        TItem Manufacture(object type);
    }
}
