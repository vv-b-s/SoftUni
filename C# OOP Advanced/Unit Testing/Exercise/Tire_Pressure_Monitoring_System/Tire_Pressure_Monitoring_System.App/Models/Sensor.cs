using System;
using Tire_Pressure_Monitoring_System.App.Contracts;

namespace Tire_Pressure_Monitoring_System.App.Models
{
    public class Sensor : ISensor
    {
        //
        // The reading of the pressure value from the sensor is simulated in this implementation.
        // Because the focus of the exercise is on the other class.
        //

        const double Offset = 16;
        readonly IRandom _randomPressureSampleSimulator;

        public Sensor(IRandom randomPressureSampleSimulator)
        {
            this._randomPressureSampleSimulator = randomPressureSampleSimulator;
        }

        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = ReadPressureSample();

            return Offset + pressureTelemetryValue;
        }

        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * _randomPressureSampleSimulator.NextDouble() * _randomPressureSampleSimulator.NextDouble();
        }
    }
}
