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


        
        public string Get([FromUri] int a, [FromUri] int b, [FromUri] int c)
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
