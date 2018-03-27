using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Layouts
{
    public class XmlLayout:ILayout
    {
        private const string LogTagFormat = "<log>\r\n\t{0}\r\n\t{1}\r\n\t{2}\r\n</log>";
        private const string DateTagFormat = "<date>{0}</date>";
        private const string LevelTagFormat = "<level>{1}</level>";
        private const string MessageTagFormat = "<message>{2}</message>";

        public string CreateLine(string dateTimeInfo, string levelOfImportance, string message)
        {
            var logBlock = string.Format(LogTagFormat, DateTagFormat, LevelTagFormat, MessageTagFormat);
            var output = string.Format(logBlock, dateTimeInfo, levelOfImportance, message);

            return output;
        }
    }
}
