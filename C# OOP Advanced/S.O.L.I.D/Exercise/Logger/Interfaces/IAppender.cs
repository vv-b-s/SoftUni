using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    public enum ReportLevels { Info, Warning, Error, Critical, Fatal}
    public interface IAppender
    {
        ReportLevels ReportLevel { get; set; }
        int AppendedMessages { get; }

        void Append(string dateTimeInfo, string levelOfImportance, string message);

        void Append(string dateTimeInfo, ReportLevels reportLevel, string message);
    }
}
