using Microsoft.VisualStudio.TestTools.UnitTesting;
using UDPWeatherBroadcaster;
using System;
using System.Collections.Generic;
using System.Text;

namespace UDPWeatherBroadcaster.Tests
{
    [TestClass()]
    public class MeasureTests
    {
        private Measure m = new Measure(2, DateTime.MaxValue, "TestLocation", 24, 12, 7);
        private Measure m2 = new Measure(2, DateTime.MaxValue, "TestLocation", 24, 12, 7);

        [TestMethod()]
        public void NonRandomParameterTest()
        {
            Assert.AreEqual(m.Id,2);
            Assert.AreEqual(m.MeasureTime, DateTime.MaxValue);
            Assert.AreEqual(m.DeviceLocation, "TestLocation");

            Assert.AreNotEqual(m.Id,1);
            Assert.AreNotEqual(m.MeasureTime, DateTime.Now);
            Assert.AreNotEqual(m.DeviceLocation, "LocationTest");
        }

        [TestMethod()]
        public void RandomParameterTest()
        {
            //Testing simply that we are within the range given for each random parameter.
            Assert.AreNotEqual(m.RandomRain(),-1);
            Assert.AreNotEqual(m.RandomRain(),21);

            Assert.AreNotEqual(m.Rain,-1);
            Assert.AreNotEqual(m.Rain,21);

            Assert.AreNotEqual(m.WindSpeed, 3);
            Assert.AreNotEqual(m.WindSpeed, 9);

            Assert.AreNotEqual(m.RandomTemperature,-6);
            Assert.AreNotEqual(m.RandomTemperature,26);

        }

       
        [TestMethod()]
        public void DifferentObjectSameId()
        {
            Assert.AreEqual(m.Id,m2.Id);

            Assert.AreNotSame(m.Id,m2.Id);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(m.ToString(),
                $"ID | {m.Id} | DATE | {m.MeasureTime} | LOCATION | {m.DeviceLocation} | TEMPERATURE IN CELCIUS | {m.RandomTemperature} | RAIN IN MM | {m.Rain} | WINDSPEED IN M/S | {m.WindSpeed}");
        }

    }
}