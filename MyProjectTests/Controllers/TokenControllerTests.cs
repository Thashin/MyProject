using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Controllers;
using System.Net.Http;

namespace MyProject.Controllers.Tests
{
    private TokenController sut { get; set; }

    [TestClass()]
    public class TokenControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var _client = new HttpClient { BaseAddress = new Uri("http://loclahost:1000") };
            Assert.AreEqual("fa926b8d - 9a5e - 4141 - 8574 - b7e0e966bcc8",_client.);
        }

    }
}