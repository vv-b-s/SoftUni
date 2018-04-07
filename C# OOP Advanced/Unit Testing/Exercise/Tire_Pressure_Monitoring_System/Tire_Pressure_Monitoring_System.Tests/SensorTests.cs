using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tire_Pressure_Monitoring_System.App.Contracts;
using Tire_Pressure_Monitoring_System.App.Models;

namespace Tire_Pressure_Monitoring_System.Tests
{
    [TestFixture]
    public class SensorTests
    {
        private Mock<IRandom> rand;

        [SetUp]
        public void Init()
        {
            this.rand = new Mock<IRandom>();
        }

        [Test]
        public void SensorPopNextPressurePsiValueWorks()
        {
            var sensor = new Sensor(this.rand.Object);

            this.rand.Setup(r => r.NextDouble()).Returns(new Random().NextDouble());
            var sample1 = sensor.PopNextPressurePsiValue();

            this.rand.Setup(r => r.NextDouble()).Returns(new Random().NextDouble());
            var sample2 = sensor.PopNextPressurePsiValue();

            Assert.That(sample1, Is.Not.EqualTo(sample2),"Sensor does not return random values!");
        }
    }
}
