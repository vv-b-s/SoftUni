using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        private string layoutNamespace;

        public LayoutFactory(string layoutNamespace)
        {
            if (string.IsNullOrWhiteSpace(layoutNamespace) && layoutNamespace != "")
                throw new ArgumentException("The layout namespace should not be null. If there is no namespece please provide empty string!");

            else this.layoutNamespace = layoutNamespace;
        }

        /// <summary>
        /// Generates a layout instance according to the provided data
        /// </summary>
        /// <param name="layoutName">The name of the layout class with the given namespace</param>
        /// <returns></returns>
        public ILayout GetLayout(string layoutName)
        {
            var layoutType = Type.GetType(this.layoutNamespace.Length == 0 ? layoutName : $"{this.layoutNamespace}.{layoutName}");

            var layout = Activator.CreateInstance(layoutType) as ILayout;

            return layout;
        }

    }
}
