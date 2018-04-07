using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Hack.Tests
{
    [TestFixture]
    public class MathTests
    {
        private const int AmountOfTestNumbers = 5;
        private IMath math;

        private List<KeyValuePair<double, double>> absTestNumbers = new List<KeyValuePair<double, double>>
        {
            new KeyValuePair<double,double>(-1,1),
            new KeyValuePair<double,double>(-53,53),
            new KeyValuePair<double,double>(4,4),
            new KeyValuePair<double,double>(-3.15,3.15),
            new KeyValuePair<double, double>( 2.5,2.5)
        };

        private List<KeyValuePair<double, double>> floorTestNumbers = new List<KeyValuePair<double, double>>
        {
            new KeyValuePair<double, double>(1.53,1 ),
            new KeyValuePair<double, double>(-35.16,-36 ),
            new KeyValuePair<double, double>(16,16 ),
            new KeyValuePair<double, double>( -25,-25),
            new KeyValuePair<double, double>(-0.53,-1 )
        };

        [SetUp]
        public void Init()
        {
            var mock = new Mock<IMath>();
            for (int i = 0; i < AmountOfTestNumbers; i++)
            {
                mock.Setup(m => m.Abs(this.absTestNumbers[i].Key)).Returns(this.absTestNumbers[i].Value);
                mock.Setup(m => m.Floor(this.floorTestNumbers[i].Key)).Returns(this.floorTestNumbers[i].Value);
            }

            this.math = mock.Object;
        }

        [Test]
        public void MathAbsWorks()
        {
            for (int i = 0; i < AmountOfTestNumbers; i++)
            {
                var testValue = this.absTestNumbers[i].Key;
                var expectedResult = this.math.Abs(testValue);

                Assert.That(Math.Abs(testValue), Is.EqualTo(expectedResult));
            }
        }

        [Test]
        public void MathFloorWorks()
        {
            for (int i = 0; i < AmountOfTestNumbers; i++)
            {
                var testValue = this.floorTestNumbers[i].Key;
                var expectedResult = this.math.Floor(testValue);

                Assert.That(Math.Floor(testValue), Is.EqualTo(expectedResult));
            }
        }

    }
}
