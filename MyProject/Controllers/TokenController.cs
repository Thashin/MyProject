using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProject.Controllers
{
    public class TokenController : ApiController
    {
        // GET: Token
        [HttpGet]
        public Guid Get()
        {
            return Guid.Parse("fa926b8d-9a5e-4141-8574-b7e0e966bcc8");
        }
    }
}