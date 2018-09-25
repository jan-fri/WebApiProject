using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiProject.Interfaces;

namespace WebApiProject.Services
{
    public class SumNumbersService : ISumNumbers
    {
        /// <summary>
        /// Sums two intigers
        /// </summary>
        /// <param name="firstNum">first intiger</param>
        /// <param name="secondNum">second intiger</param>
        /// <returns>sum</returns>
        public int SumTwoInt(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }

        /// <summary>
        /// sums list of intigers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int SumListNumbers(List<int> numbers)
        {
            int sum = 0;
            if (numbers != null)
                sum = numbers.Sum();

            return sum;
        }
    }
}