using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03BarracksFactory
{
    public class DependencyContainer
    {
        private Dictionary<string, object> container;

        public DependencyContainer()
        {
            container = new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates an instance of an object and looks for dependencies which can be stored in the container
        /// </summary>
        /// <param name="classType">The class which is going to be instantiated</param>
        /// <param name="arguments">The arguments if any for the instance</param>
        /// <returns></returns>
        public object CreateAndInject(Type classType, params object[] arguments)
        {
            //Create the instance which will get injection
            var instance = GetInstanceConstructor(classType, arguments).Invoke(arguments);

            //Get the properties of the instance to find if any has the InjectAttribute
            var properties = instance.GetType().GetProperties();

            foreach (var property in properties)
            {
                //Look at the property's attributes to find the InjectAttribute one if it exists
                var attribute = property
                    .GetCustomAttributes(false)
                    .FirstOrDefault(a => a.GetType() == typeof(InjectAttribute));

                if (attribute is InjectAttribute injection)
                {
                    //Find the dependency matching the name of the required interface
                    var dependency = this.container
                        .Where(d => d.Key == injection.DependencyName)
                        .FirstOrDefault().Value;

                    property.SetValue(instance, dependency);
                }
            }

            return instance;
        }

        /// <summary>
        /// Adds a new dependency to the container
        /// </summary>
        /// <typeparam name="TInterface">The interface which the class implements</typeparam>
        /// <typeparam name="TImplementation">The class which implements the interface</typeparam>
        /// <param name="dependency">Instance of the class</param>
        public void AddDependency<TInterface, TImplementation>(TImplementation dependency) where TImplementation : class, TInterface
        {
            var interfaceName = typeof(TInterface).Name;
            this.container[interfaceName] = dependency;
        }

        /// <summary>
        /// Looks for a constructor matching the given arguments for the given class
        /// </summary>
        /// <param name="classType">The type of the class which constructor is going to be looked for</param>
        /// <param name="args">The arguments for the constructor</param>
        /// <returns></returns>
        private ConstructorInfo GetInstanceConstructor(Type classType, params object[] args)
        {
            var constructorParams = args.Select(arg => arg.GetType()).ToArray();

            var constructor = classType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, constructorParams, null);

            return constructor;
        }
    }
}
