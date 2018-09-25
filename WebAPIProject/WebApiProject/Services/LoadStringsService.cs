using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApiProject.Interfaces;

namespace WebApiProject.Services
{
    public class LoadStringsService : ILoadStrings
    {
        /// <summary>
        /// path to where the Json file is stored
        /// </summary>
        private string _filePath;

        /// <summary>
        /// public property to return the file path
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
        }

        /// <summary>
        /// class constructor to populate the default file path
        /// </summary>
        public LoadStringsService()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Repository\localDB.json");
        }

        /// <summary>
        /// constructor used to populate the file path (used in unit tests)
        /// </summary>
        /// <param name="path"></param>
        public LoadStringsService(string path)
        {
            _filePath = path;
        }

        /// <summary>
        /// reads the contents of the Json file
        /// </summary>
        /// <returns></returns>
        public List<string> ReadLocalDB()
        {
            List<string> strings = new List<string>();

            JObject jsObj = JObject.Parse(File.ReadAllText(FilePath));
            var array = jsObj["string_array"].ToList();

            foreach (var item in array)
                strings.Add((string)item);

            return strings;
        }

        /// <summary>
        /// saves the provided string into the Json file
        /// </summary>
        /// <param name="str"></param>
        public void SaveStringstoLocalDB(string str)
        {
            JObject jsObj = new JObject();
            JArray array = new JArray();

            //check if the Json file exists
            if (!System.IO.File.Exists(FilePath))
            {
                array.Add(str);
                jsObj["string_array"] = array;
                string json = jsObj.ToString();
            }
            else
            {
                jsObj = JObject.Parse(File.ReadAllText(FilePath));
                array = (JArray)jsObj["string_array"];
                array.Add(str);
            }

            //initiate Newtonsoft serializer
            JsonSerializer serializer = new JsonSerializer();

            //write the string to Json file
            using (StreamWriter sw = new StreamWriter(FilePath, append: false))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, jsObj);
            }
        }
    }
}