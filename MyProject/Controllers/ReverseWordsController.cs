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
        public IEnumerable<string> Get()
        {
            return new string[] { "" };
        }

        // GET api/values/5
        public string Get([FromUri] string sentence)
        {

            return string.Join(" ", sentence
                .Split(' ')
                .Select(x => new string(x.Reverse().ToArray())));
        }

    }
}
