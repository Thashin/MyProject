using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyProject.Controllers.Tests
{
    [TestClass()]
    public class TriangleTypeControllerTests
    {
        public TriangleTypeController sut;

        [TestInitialize]
        public void SetUp()
        {
            sut = new TriangleTypeController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod()]
        public void NegativeSideTest()
        {
            var expected = "Error";
            sut.Get(2,2,-2).TryGetContentValue(out string actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ImpossibleTriangleTest()
        {
            var expected = "Error";
            sut.Get(2, 8, 2).TryGetContentValue(out string actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EquilateralTest()
        {
            var expected = "Equilateral";
            sut.Get(2, 2, 2).TryGetContentValue(out string actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsoscelesTest()
        {
            var expected = "Isosceles";
            sut.Get(2, 2, 3).TryGetContentValue(out string actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ScaleneTest()
        {
            var expected = "Scalene";
            sut.Get(3, 4, 5).TryGetContentValue(out string actual);
            Assert.AreEqual(expected, actual);
        }

    }
}