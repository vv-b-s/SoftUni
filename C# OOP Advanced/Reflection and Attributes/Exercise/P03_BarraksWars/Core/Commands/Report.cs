using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class Report : Command
    {
        public Report(string[] data) : base(data) { }

        [Inject("IRepository")]
        public IRepository Repository { get; private set; }

        public override string Execute()
        {
            string output = this.Repository.Statistics;

            return output;
        }
    }
}
