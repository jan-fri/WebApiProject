using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProject.Interfaces;

namespace WebApiProject.Controllers
{
    public class SumNumbersController : ApiController
    {
        /*
        * Task 2 Controller after refactorization 
        */

        /// <summary>
        /// interface used for DI 
        /// </summary>
        private ISumNumbers _sumNumbers;

        /// <summary>
        /// constructor for the controller
        /// </summary>
        /// <param name="sumNumbers">Interface to be injected</param>
        public SumNumbersController(ISumNumbers sumNumbers)
        {
            _sumNumbers = sumNumbers;
        }


        /// <summary>
        /// Sums two numbers given in the URI
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNum">second number</param>
        /// <returns>sum of two numbers</returns>
        /// GET: api/sum/v2/sumnumbers
        [HttpGet]
        [Route("api/sum/v2/getsum")]
        public HttpResponseMessage GetSum(int firstNumber, int secondNum)
        {
            int result = _sumNumbers.SumTwoInt(firstNumber, secondNum);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }


        /// <summary>
        /// Sums list of numbers (intigers) sent in the HTTP body
        /// </summary>
        /// <param name="numbers">list of numbers, format [1,2,3]</param>
        /// <returns>sum of numbers in a given list</returns>
        /// // POST: api/sum/v2/SumNumbers/
        [HttpPost]
        [Route("api/sum/v2/sumlist")]
        public HttpResponseMessage AddNumberList([FromBody] List<int> numbers)
        {
            int result = _sumNumbers.SumListNumbers(numbers);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        /*
         * Task 1 controller methods before refactorization (can still be used)   
         */
        /// <summary>
        /// sums two intigers
        /// version before refactoring
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        // GET: api/v1/getsum
        [HttpGet]
        [Route("api/sum/v1/getsum")]
        public string GetSum_old(int one, int two)
        {
            int add = one + two;
            return "the sum " + add.ToString();
        }

        /// <summary>
        /// sums list of intigers
        /// version before refactoring
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        // POST: api/Addition/
        [HttpPost]
        [Route("api/sum/v1/sumlist")]
        public string AddNumberList_old([FromBody] List<int> numbers)
        {
            int sum = 0;
            if (numbers != null)
                sum = numbers.Sum();

            return "the sum of the list is " + sum.ToString();
        }
    }
}
