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
        /// <summary>
        /// This is for the base case where there is no input
        /// </summary>
        /// <returns>A Http Response Message with an empty string</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }
        
        /// <summary>
        /// This reverese the letters in words
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns> A Http Response message with all lettters in a word reversed</returns>

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
