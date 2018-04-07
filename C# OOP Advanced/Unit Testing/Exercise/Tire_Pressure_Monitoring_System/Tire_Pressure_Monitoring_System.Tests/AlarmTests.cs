using Moq;
using NUnit.Framework;
using System;
using Tire_Pressure_Monitoring_System.App.Contracts;
using Tire_Pressure_Monitoring_System.App.Models;

namespace Tire_Pressure_Monitoring_System.Tests
{
    [TestFixture]
    public class AlarmTests
    {
        private Mock<ISensor> fakeSensor;
        private Random randomizer = new Random();
        private Alarm alarm;

        [SetUp]
        public void Init()
        {
            this.fakeSensor = new Mock<ISensor>();
            this.alarm = new Alarm(fakeSensor.Object);
        }

        [Test]
        public void AlarmDoesNotGoOffWhenPressureIsNormal()
        {
            var alarm = new Alarm(this.fakeSensor.Object);

            for (int i = 0; i < 10; i++)
            {
                this.fakeSensor.Setup(fs => fs.PopNextPressurePsiValue())
                    .Returns(randomizer.Next((int)Alarm.LowPressureThreshold, (int)Alarm.HighPressureThreshold + 1));

                alarm.Check();

                Assert.That(alarm.AlarmOn, Is.EqualTo(false), "Alarm goes off when pressure is normal!");
            }
        }

        [Test]
        public void AlarmSetsOffWhenPressureIsAbnormal()
        {
            var alarm = new Alarm(this.fakeSensor.Object);

            for (int i = 0; i < 10; i++)
            {
                this.fakeSensor.Setup(fs => fs.PopNextPressurePsiValue())
                    .Returns(randomizer.Next((int)Alarm.LowPressureThreshold));

                alarm.Check();


                Assert.That(alarm.AlarmOn, Is.EqualTo(true), "Alarm does not go off when pressure is low");
            }

            for (int i = 0; i < 10; i++)
            {
                this.fakeSensor.Setup(fs => fs.PopNextPressurePsiValue())
                    .Returns(randomizer.Next((int)Alarm.HighPressureThreshold + 2, int.MaxValue));

                alarm.Check();


                Assert.That(alarm.AlarmOn, Is.EqualTo(true), "Alarm does not go off when pressure is high");
            }
        }
    }
}
