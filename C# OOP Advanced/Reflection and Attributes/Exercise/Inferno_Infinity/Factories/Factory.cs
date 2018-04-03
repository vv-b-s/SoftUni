using Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inferno_Infinity.Factories
{
    public abstract class Factory<TProduct> : IFactory<TProduct> where TProduct : class
    {
        public TProduct CreateProduct(Type productType, params object[] args)
        {
            var constructor = productType.GetConstructor(args.Select(a => a.GetType()).ToArray());
            var instance = constructor.Invoke(args);

            return instance as TProduct;
        }
    }
}
