using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProject.Interfaces
{
    public interface ILoadStrings
    {
        /// <summary>
        /// method definition for reading the Json file
        /// </summary>
        /// <returns></returns>
        List<string> ReadLocalDB();

        /// <summary>
        /// method definition for adding a string to Json file
        /// </summary>
        /// <param name="str"></param>
        void SaveStringstoLocalDB(string str);
    }
}
