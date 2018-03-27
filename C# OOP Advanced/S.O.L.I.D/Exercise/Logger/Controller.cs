using Logger.Factories;
using Logger.Interfaces;
using Logger.Loggers;

using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class Controller
    {
        //The controller is related only with this project so for this project these are the namespeces used for the factories
        private const string AppendersNamespace = "Logger.Appenders";
        private const string LayoutsNamespece = "Logger.Layouts";
        private const string WritableObjectsNamespace = "Logger.Writables";

        private ILogger logger;

        private AppenderFactory appenderFactory;
        private LayoutFactory layoutFactory;
        private WritableObjectFactory writableObjectsFactory;

        public Controller()
        {
            this.appenderFactory = new AppenderFactory(AppendersNamespace);
            this.layoutFactory = new LayoutFactory(LayoutsNamespece);
            this.writableObjectsFactory = new WritableObjectFactory(WritableObjectsNamespace);
        }

        public IReadOnlyCollection<IAppender> Appenders => logger.Appenders;

        public void AddAppender(string appenderInfo)
        {
            var data = appenderInfo.Split(" ");

            var appenderType = data[0];
            var layoutType = data[1];

            var layout = layoutFactory.GetLayout(layoutType);

            //Since the input doesn't provide information for the console or the file, the default for this project will be used
            //which will break the Liskov principle, but this should be rather here than in the Appender classes.
            IAppender appender = null;
            if (appenderType == "ConsoleAppender")
            {
                var writableObject = writableObjectsFactory.GetWritableObject("Console");
                appender = appenderFactory.GetAppender(appenderType, layout, writableObject);
            }

            else if (appenderType == "FileAppender")
            {
                var writableObject = writableObjectsFactory.GetWritableObject("LogFile");
                appender = appenderFactory.GetAppender(appenderType, layout, writableObject);
            }

            if (data.Length > 2 && Enum.TryParse(data[2], true, out ReportLevels reportLevelLimit))
                appender.ReportLevel = reportLevelLimit;

            if (logger is null)
                logger = new Loggers.Logger(appender);

            else logger.AddAppenders(appender);
        }

        public void WriteLog(string data)
        {
            var args = data.Split("|");

            var messageLevel = args[0];
            var dateTimeInfo = args[1];
            var message = args[2];

            if (Enum.TryParse(messageLevel, true, out ReportLevels reportLevel))
                logger.CreateLog(dateTimeInfo, reportLevel.ToString(), message);

            else logger.CreateLog(dateTimeInfo, messageLevel, message);
        }
    }
}
