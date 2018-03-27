using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Layouts
{
    class SimpleLayout : ILayout
    {
        private const string Format = "{0} - {1} - {2}";

        public string CreateLine(string dateTimeInfo, string levelOfImportance, string message)
        {
            return string.Format(Format, dateTimeInfo, levelOfImportance, message);
        }
    }
}
