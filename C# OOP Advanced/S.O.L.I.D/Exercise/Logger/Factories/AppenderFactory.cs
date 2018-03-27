using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private string appendersNamespace;

        public AppenderFactory(string appendersNamespace)
        {
            if (string.IsNullOrWhiteSpace(appendersNamespace) && appendersNamespace != "")
                throw new ArgumentException("The given namespace should not be null. If there is no namespece set it to an empty string!");

            else this.appendersNamespace = appendersNamespace;
        }

        /// <summary>
        /// Creates appender
        /// </summary>
        /// <param name="appenderName">The class name of the appender. It should be in the provided namespace</param>
        /// <param name="layout">The layout in which the appender should append the given data</param>
        /// <param name="writableObject">The place where the appender will place the data</param>
        /// <returns></returns>
        public IAppender GetAppender(string appenderName, ILayout layout, IWritableObject writableObject)
        {
            var appenderType = Type.GetType(this.appendersNamespace.Length == 0 ? appenderName : $"{appendersNamespace}.{appenderName}");

            var appender = Activator.CreateInstance(appenderType, layout, writableObject) as IAppender;

            return appender;
        }
    }
}
