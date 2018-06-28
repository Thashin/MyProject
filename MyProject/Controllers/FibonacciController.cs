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


        /// <summary>
        /// This calculates the nth Fibonacci number.
        /// For n greater than 92 and n less than -92 produces a fibonacci number that cannot be held in a long
        /// This algorithm was taken from https://www.nayuki.io/page/fast-fibonacci-algorithms
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The nth Fibonacci number</returns>
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

        /// <summary>
        /// Calculates the nth power of the base case matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="n"></param>
        /// <returns>nth power of the base matrix</returns>
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
        /// <summary>
        /// Multiplies 2 2x2 matrices
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>a 2x2 matrix</returns>
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
