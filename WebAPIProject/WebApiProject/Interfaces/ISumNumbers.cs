using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProject.Interfaces
{
    public interface ISumNumbers
    {
        /// <summary>
        /// method definition for sum two intigers
        /// </summary>
        /// <param name="firstNum"></param>
        /// <param name="secondNum"></param>
        /// <returns></returns>
        int SumTwoInt(int firstNum, int secondNum);

        /// <summary>
        /// method definition for sum list of intigers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        int SumListNumbers(List<int> numbers);
    }
}
