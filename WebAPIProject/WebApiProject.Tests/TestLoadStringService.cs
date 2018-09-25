using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Services;

namespace WebApiProject.Tests
{
    [TestClass]
    public class TestLoadStringService
    {
        /// <summary>
        /// testing the validity of reading data from a Json test file in specified path
        /// </summary>
        [TestMethod]
        public void TestReadLocalDB()
        {
            //the expected results
            List<string> expected = new List<string> { "one", "two", "three" };
            
            //specifying the path to the Json test file (should be present to run the test correctly)
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\TestFiles\testFileContent.json");

            //instanciating the InputStringsService class and specify path through constructor
            LoadStringsService inputStringsService = new LoadStringsService(path);

            //reading the file content
            //List<string> fileContent = new List<string>();
            var fileContent = inputStringsService.ReadLocalDB();

            CollectionAssert.AreEqual(expected, fileContent);
        }


        /// <summary>
        /// testing writing to and reading from the a Json test file
        /// </summary>
        /// <param name="str">example string to be written into the file</param>
        [DataTestMethod]
        [DataRow("SampleString")]
        [DataRow("TestString")]
        public void TestSaveStringstoLocalDB(string str)
        {
            //specifying the path to the Json test file, the file will be created in that path
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\TestFiles\testFileCreation.json");
            if (System.IO.File.Exists(path))
                File.Delete(path);

            //instanciating the InputStringsService class and specify path through constructor
            LoadStringsService inputStringsService = new LoadStringsService(path);

            // run the method to be tested
            inputStringsService.SaveStringstoLocalDB(str);

            //read the created file by using InputStringsService.ReadLocalDB method
            var fileContent = inputStringsService.ReadLocalDB();
            var result = fileContent[0];

            Assert.AreEqual(str, result);
        }
    }
}
