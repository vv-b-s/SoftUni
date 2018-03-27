﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void CreateLog(string dateTimeInfo,string levelOfImportance, string message);
        void AddAppenders(params IAppender[] appenders);
    }
}
