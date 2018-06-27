using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProject.Controllers
{
    public class FibonacciController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "" };
        }

        // 92 is the highest value that is supported add error handling for after 92
        public HttpResponseMessage Get([FromUri] int n)
        {
            if(n>92||n<-93)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            long[] matrix = { 1, 1, 1, 0 };
            if(n<0 && n%2==0)
            {
                return Request.CreateResponse(HttpStatusCode.OK,powMatrix(matrix, n)[1]*-1);
            }

            return Request.CreateResponse(HttpStatusCode.OK,powMatrix(matrix, n)[1]);
        }

        
        private static long[] powMatrix(long[] matrix, int n)
        {

            long[] result = { 1, 0, 0, 1 };
            while (n != 0)
            {  
                if (n % 2 != 0)
                    result = multiplyMatrix(result, matrix);
                n /= 2;
                matrix = multiplyMatrix(matrix, matrix);
            }
            return result;
        }
        
        private static long[] multiplyMatrix(long[] x, long[] y)
        {
            return new long[] {
            (x[0]*y[0])+(x[1]*y[2]),
            (x[0]* y[1])+(x[1]* y[3]),
            (x[2]* y[0])+(x[3]* y[2]),
            (x[2]* y[1])+(x[3]* y[3])
        };
        }
    }
}
