using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
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
            var fuelQuantity = double.Parse(data[1]);
            var fuelConsumption = double.Parse(data[2]);

            var vehicleType = Type.GetType("Vehicles." + vehicle);
            var vehicleInstance = Activator.CreateInstance(vehicleType, fuelQuantity, fuelConsumption);

            return vehicleInstance as Vehicle;
        }
    }
}
