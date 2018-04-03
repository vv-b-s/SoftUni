using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Contracts
{
    public interface IMetadataController
    {
        IMetadataAttribute GetAttribute(Type containingType);
        IDictionary<string, object> GetAttributeValues(IMetadataAttribute attribute);
    }
}
