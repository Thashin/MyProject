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
        private const string error = "Error";
        private const string equilateral = "Equilateral";
        private const string isosceles = "Isosceles";
        private const string scalene = "Scalene";



        public HttpResponseMessage Get([FromUri] int a, [FromUri] int b, [FromUri] int c)
        {

            return Request.CreateResponse(HttpStatusCode.OK, DetermineType(a, b, c));
        }

        ///<summary> Determines the type of triangle based on the length of the sides
        ///There are two error cases in to look for
        /// 1) a negative length
        /// 2) the value of the longest side is less than or equal to the sum of the other 2 sides
        ///</summary>

        private string DetermineType(int a,int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return error;
            }

            int[] sides = new int[] { a, b, c };

            Array.Sort(sides);

            if (sides[0] + sides[1] <= sides[2])
            {
                return error;
            }
            if (sides.Distinct().Count() == 1)
            {
                return equilateral;
            }
            if (sides.Distinct().Count() == 2)
            {
                return isosceles;
            }
            if (sides.Distinct().Count() == 3)
            {
                return scalene;
            }

            return error;
        }

    }
}
