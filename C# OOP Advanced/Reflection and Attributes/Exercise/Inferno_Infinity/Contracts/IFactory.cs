using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Contracts
{
    public interface IFactory<TProduct> where TProduct:class
    {
        TProduct CreateProduct(Type productType,params object[] args);
    }
}
