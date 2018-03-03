using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle_Extension
{
    public static class VehicleFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">Provide: Type of vehicle, Fuel quantity and Fuel consumption</param>
        /// <returns></returns>
        public static Vehicle Manufacture(string[] data)
        {
            var vehicle = data[0];
            var parameters = data.Skip(1).Select(dt=>(object)double.Parse(dt)).ToArray();

            var vehicleType = Type.GetType("Vehicle_Extension." + vehicle);
            var vehicleInstance = Activator.CreateInstance(vehicleType, parameters);

            return vehicleInstance as Vehicle;
        }
    }
}
