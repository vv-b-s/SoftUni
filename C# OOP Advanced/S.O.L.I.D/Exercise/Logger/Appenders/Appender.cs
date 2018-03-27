using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        private IWritableObject writableObject;
        private ILayout layout;

        protected Appender(ILayout layout, IWritableObject writableObject)
        {
            this.layout = layout;
            this.writableObject = writableObject;
        }

        public ReportLevels ReportLevel { get; set; } = ReportLevels.Info;

        public int AppendedMessages { get; private set; }

        protected IWritableObject WritableObject => this.writableObject;

        public virtual void Append(string dateTimeInfo, string levelOfImportance, string message)
        {
            var output = layout.CreateLine(dateTimeInfo, levelOfImportance, message);
            writableObject.Write(output + Environment.NewLine);

            this.AppendedMessages++;
        }

        public virtual void Append(string dateTimeInfo, ReportLevels reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
                this.Append(dateTimeInfo, reportLevel.ToString(), message);
        }

        public override string ToString()
        {
            var output = $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, " +
                $"Messages appended: {this.AppendedMessages}";

            return output;
        }
    }
}
