using Inferno_Infinity.Contracts;
using Inferno_Infinity.DI_Mechanism;
using Inferno_Infinity.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inferno_Infinity.Core.Commands
{
    public abstract class MetadataCommand : ICommand
    {
        [Inject]
        public IPrintLocation PrintLocation { get; protected set; }

        [Inject]
        public IMetadataController MetadataController { get; protected set; }

        public virtual string Execute(string[] args)
        {
            var attribute = this.MetadataController.GetAttribute(typeof(Weapon));

            var metadataValues = MetadataController.GetAttributeValues(attribute);

            var pair = metadataValues.FirstOrDefault(mdv => mdv.Key == this.GetType().Name);

            if (!pair.Equals(default(KeyValuePair<string, object>)))
                PrintLocation.Print(PairOutput(pair) + Environment.NewLine);

            return null;

        }

        protected virtual string PairOutput(KeyValuePair<string, object> pair)
        {
            var output = $"{pair.Key}: {pair.Value}";
            return output;
        }
    }

    public class Author : MetadataCommand { }

    public class Revision : MetadataCommand { }

    public class Description : MetadataCommand
    {
        protected override string PairOutput(KeyValuePair<string, object> pair)
        {
            var output = $"Class description: {pair.Value}";
            return output;
        }
    }

    public class Reviewers : MetadataCommand
    {
        protected override string PairOutput(KeyValuePair<string, object> pair)
        {
            var output = $"{pair.Key}: {string.Join(", ", pair.Value as string[])}";
            return output;
        }
    }
}
