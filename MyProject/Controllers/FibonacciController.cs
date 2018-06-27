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
        public long Get([FromUri] int n)
        {
            long[] matrix = { 1, 1, 1, 0 };
            if(n<0 && n%2==0)
            {
                return matrixPow(matrix, n)[1]*-1;
            }

            return matrixPow(matrix, n)[1];
        }


        // Computes the power of a matrix. The matrix is packed in row-major order.
        private static long[] matrixPow(long[] matrix, int n)
        {

            long[] result = { 1, 0, 0, 1 };
            while (n != 0)
            {  // Exponentiation by squaring
                if (n % 2 != 0)
                    result = matrixMultiply(result, matrix);
                n /= 2;
                matrix = matrixMultiply(matrix, matrix);
            }
            return result;
        }

        // Multiplies two matrices.
        private static long[] matrixMultiply(long[] x, long[] y)
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
