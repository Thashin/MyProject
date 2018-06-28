using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProject.Controllers.Tests
{
    [TestClass()]
    public class FibonacciControllerTests
    {
        public FibonacciController sut;

        [TestInitialize]
        public void SetUp()
        {
            sut = new FibonacciController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod()]
        public void BaseNumberTest()
        {
            long expected = 1;
            sut.Get(1).TryGetContentValue(out long actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PositiveNumberTest()
        {
            long expected = 6765;
            sut.Get(20).TryGetContentValue(out long actual);

            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void NegativeNumberTest()
        {
            long expected = -102334155;
            sut.Get(-40).TryGetContentValue(out long actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LargeNumberTest()
        {
            var expected = HttpStatusCode.BadRequest;
            var actual = sut.Get(94).StatusCode;
            Assert.AreEqual(expected, actual);
        }


    }
}