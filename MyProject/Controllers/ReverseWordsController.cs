using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProject.Controllers
{
    public class ReverseWordsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }
        
        public HttpResponseMessage Get([FromUri] string sentence)
        {

            return Request.CreateResponse(HttpStatusCode.OK, string.Join(" ", sentence
                                                                   .Split(' ')
                                                                   .Select(x => new string(x.Reverse()
                                                                                            .ToArray()
                                                                                           ))));
        }

    }
}
