using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficLights
{
    public class TrafficLight
    {
        private const int NumberOfLights = 3;

        public TrafficLight(Light light)
        {
            this.CurrentLight = light;
        }

        public enum Light { Red, Green, Yellow}

        public Light CurrentLight{ get; private set; }

        public void ChangeLight()
        {
            var nextLight = (((int)this.CurrentLight) + 1) % NumberOfLights;

            this.CurrentLight = (Light)nextLight;
        }

        public override string ToString()
        {
            return this.CurrentLight.ToString();
        }
    }
}
