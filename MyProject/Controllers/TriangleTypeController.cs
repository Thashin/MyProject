using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProject.Controllers
{
    public class TriangleTypeController : ApiController
    {
        private string error = "Error";
        private string equilateral = "Equilateral";
        private string isosceles = "Isosceles";
        private string scalene = "Scalene";

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "" };
        }

        // GET api/values/5
        public string Get([FromUri] int a, [FromUri] int b, [FromUri] int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return error;
            }

            int[] sides = new int[] { a, b, c };

            Array.Sort(sides);

            if(sides[0]+sides[1]<=sides[2])
            {
                return error;
            }
            if (sides.Distinct().Count() == 1) //There is only one distinct value in the set, therefore all sides are of equal length
            {
                return equilateral;
            }
            if (sides.Distinct().Count() == 2) //There are only two distinct values in the set, therefore two sides are equal and one is not
            {
                return isosceles;
            }
            if (sides.Distinct().Count() == 3) // There are three distinct values in the set, therefore no sides are equal
            {
                return scalene;
            }
            return error;
        }

    }
}
