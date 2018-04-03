using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Contracts
{
    public interface IMetadataAttribute
    {
        string Author { get; }
        int Revision { get; }
        string Description { get; }
        string[] Reviewers { get; }
    }
}
