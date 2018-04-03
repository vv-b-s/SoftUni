using Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Inferno_Infinity.Core
{
    public class MetadataController : IMetadataController
    {
        public IMetadataAttribute GetAttribute(Type containingType)
        {
            var attribute = containingType.GetCustomAttributes(false).Where(a => a is IMetadataAttribute).FirstOrDefault();

            return attribute as IMetadataAttribute;
        }

        public IDictionary<string, object> GetAttributeValues(IMetadataAttribute attribute)
        {
            var output = new Dictionary<string, object>();

            foreach (var property in attribute.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                output[property.Name] = property.GetValue(attribute);

            return output;
        }

    }
}
