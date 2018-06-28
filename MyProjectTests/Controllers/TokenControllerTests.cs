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
    public class TokenControllerTests
    {
        public TokenController sut;

        [TestInitialize]
        public void SetUp()
        {
            sut = new TokenController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            }; 
        }

        [TestMethod()]
        public void GetTest()
        {
            var expected = "fa926b8d-9a5e-4141-8574-b7e0e966bcc8";
            var actual = sut.Get().ToString();
            Assert.AreEqual(expected,actual);
        }
    }
}