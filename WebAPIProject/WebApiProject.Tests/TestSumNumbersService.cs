using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Services;

namespace WebApiProject.Tests
{
    [TestClass]
    public class TestSumNumbersService
    {
        [DataTestMethod]
        [DataRow(4, 5, 9)]
        [DataRow(0, 0, 0)]
        [DataRow(-4, -10, -14)]
        [DataRow(100, 30, 130)]
        public void TestSum(int firstNum, int secondNum, int expected)
        {
            SumNumbersService sumService = new SumNumbersService();
            int result = sumService.SumTwoInt(firstNum, secondNum);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(5, 15)]
        public void TestListSum(int n, int expected)
        {
            SumNumbersService sumService = new SumNumbersService();
            List<int> numbers = new List<int>();
            numbers.AddRange(Enumerable.Range(1, n));

            int result = sumService.SumListNumbers(numbers);

            Assert.AreEqual(expected, result);
        }
    }
}
