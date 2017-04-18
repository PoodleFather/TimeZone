using System;
using TimeZone.Controllers.API;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeZone.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var apiTest = new GetTimeZoneController();
            Assert.AreNotEqual("", apiTest.GetTimeZoneNow("kr"));
        }
    }
}
