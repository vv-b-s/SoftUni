using Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Infinity.Models
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class MetadataAttribute : Attribute, IMetadataAttribute
    {

        public MetadataAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; }

        public int Revision { get; }

        public string Description { get; }

        public string[] Reviewers { get; }
    }
}
