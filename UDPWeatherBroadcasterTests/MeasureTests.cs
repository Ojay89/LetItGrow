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
        private Measure m = new Measure(1, 2020 - 05 - 12T07: 09:57.3415153 + 00:00, "TestLocation", 24, 12, 7);

        [TestMethod()]
        public void MeasureTest()
        {
            Assert.AreEqual(m.Id,1);
            Assert.AreEqual(m.MeasureTime, DateTime.Now);
            Assert.AreEqual(m.DeviceLocation, "TestLocation");
            Assert.AreEqual(m.RandomTemperature,24);
            Assert.AreEqual(m.Rain,12);
            Assert.AreEqual(m.WindSpeed,7);
        }

        [TestMethod()]
        public void RandomRainTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MeasureTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}