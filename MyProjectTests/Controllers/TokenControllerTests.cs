using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Controllers.Tests
{
    [TestClass()]
    public class TokenControllerTests
    {
        public TokenController sut;

        [TestInitialize]
        public void SetUp()
        {
            sut = new TokenController();
        }

        [TestMethod()]
        public void GetTest()
        {

            Assert.AreEqual("fa926b8d-9a5e-4141-8574-b7e0e966bcc8",sut.Get().ToString());
        }
    }
}