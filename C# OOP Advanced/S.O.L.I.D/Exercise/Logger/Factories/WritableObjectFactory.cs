using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class WritableObjectFactory
    {
        private string writableObjectNamespace;

        public WritableObjectFactory(string writableObjectNamespace)
        {
            if (string.IsNullOrWhiteSpace(writableObjectNamespace) && writableObjectNamespace != "")
                throw new ArgumentException("The provided namespece cannot be null. Use empty string as argument if there is no namespace!");

            else this.writableObjectNamespace = writableObjectNamespace;
        }

        /// <summary>
        /// Create a writable object
        /// </summary>
        /// <param name="objectName">The name of the class by the provided namespace</param>
        /// <param name="additionalData">Some data for a personal constructor. E.g. filepath for LogFile</param>
        /// <returns></returns>
        public IWritableObject GetWritableObject(string objectName, params object[] additionalData)
        {
            var objectType = Type.GetType(this.writableObjectNamespace.Length == 0 ? objectName : $"{writableObjectNamespace}.{objectName}");

            IWritableObject writableObject;

            if (additionalData is null)
                writableObject = Activator.CreateInstance(objectType) as IWritableObject;

            else writableObject = Activator.CreateInstance(objectType, additionalData) as IWritableObject;

            return writableObject;
        }
    }
}
