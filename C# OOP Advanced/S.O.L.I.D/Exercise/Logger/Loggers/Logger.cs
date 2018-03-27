using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        private List<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }

        public IReadOnlyCollection<IAppender> Appenders => this.appenders;

        public void AddAppenders(params IAppender[] appenders)
        {
            foreach (var appender in appenders)
                this.appenders.Add(appender);
        }

        public void CreateLog(string dateTimeInfo, string levelOfImportance, string message)
        {
            foreach (var appender in this.appenders)
            {
                if (Enum.TryParse(levelOfImportance, out ReportLevels reportLevel))
                    appender.Append(dateTimeInfo, reportLevel, message);

                else appender.Append(dateTimeInfo, levelOfImportance, message);
            }
        }

        /// <summary>
        /// Writes a log with 'Error' level of importance
        /// </summary>
        /// <param name="dateTimeInfo"></param>
        /// <param name="message"></param>
        public void Error(string dateTimeInfo, string message)
        {
            CreateLog(dateTimeInfo, "Error", message);
        }

        /// <summary>
        /// Creates a log message with 'Info' level of importance"
        /// </summary>
        /// <param name="dateTimeInfo"></param>
        /// <param name="message"></param>
        public void Info(string dateTimeInfo, string message)
        {
            CreateLog(dateTimeInfo, "Info", message);
        }

        /// <summary>
        /// Creates a log with "Fatal" level of importance
        /// </summary>
        /// <param name="dateTimeInfo"></param>
        /// <param name="message"></param>
        public void Fatal(string dateTimeInfo, string message)
        {
            CreateLog(dateTimeInfo, "Fatal", message);
        }

        /// <summary>
        /// Creates a log with "Critical" level of importance
        /// </summary>
        /// <param name="dateTimeInfo"></param>
        /// <param name="message"></param>
        public void Critical(string dateTimeInfo, string message)
        {
            CreateLog(dateTimeInfo, "Critical", message);
        }
    }
}
