using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProject.Interfaces;

namespace WebApiProject.Controllers
{
    public class LoadStringsController : ApiController
    {
        /*
         * Task 2 Controller after refactorization  
         */

        /// <summary>
        /// interface used for DI
        /// </summary>
        private ILoadStrings _loadStrings;

        /// <summary>
        /// controller constructor
        /// </summary>
        /// <param name="inputStrings">interface to be injected</param>
        public LoadStringsController(ILoadStrings inputStrings)
        {
            _loadStrings = inputStrings;
        }

        /// <summary>
        /// Retrieves the saved strings from a local JSON file.
        /// </summary>
        /// <returns>List of strings</returns>
        /// GET: api/loadstrings/v2/getstrings
        [HttpGet]
        [Route("api/loadstrings/v2/getstrings")]
        public IHttpActionResult GetAllStrings()
        {
            List<string> result = new List<string>(_loadStrings.ReadLocalDB());
            if (result.Any())
                return Ok(result);

            return Content(HttpStatusCode.NoContent, "Empty array");
        }


        /// <summary>
        /// Adds a given string to a local Json file 
        /// </summary>
        /// <param name="str">string to be added to the Json file</param>
        /// <returns></returns>
        /// POST: api/savestring
        [HttpPost]
        [Route("api/loadstrings/v2/savestring")]
        public IHttpActionResult AddStringToFile([FromUri] string str)
        {
            _loadStrings.SaveStringstoLocalDB(str);

            return Ok("String saved to file");
        }

        /*
         * Task 1 controller methods before refactorization (can still be used)   
         */
        

        /// <summary>
        /// get all the strings saved in the Json file 
        /// version before refactoring
        /// </summary>
        /// <returns></returns>
        // GET: api/getstrings
        [HttpGet]
        [Route("api/loadstrings/v1/getstrings")]
        public List<string> GetAllStrings_old()
        {
            List<string> strings = new List<string>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Repository\localDB.json");


            JObject jsObj = JObject.Parse(File.ReadAllText(filePath));
            var array = jsObj["string_array"].ToList();

            foreach (var item in array)
                strings.Add((string)item);

            return strings;
        }

        /// <summary>
        /// save a string to a Json file 
        /// version before refactoring
        /// </summary>
        /// <param name="str"></param>
        // POST: api/savestring
        //write to Json file using Newtonsoft library
        [HttpPost]
        [Route("api/loadstrings/v1/savestring")]
        public void AddStringToFile_old([FromUri] string str)
        {
            JObject jsObj = new JObject();
            JArray array = new JArray();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Repository\localDB.json");

            if (!System.IO.File.Exists(filePath))
            {
                array.Add(str);
                jsObj["string_array"] = array;
                string json = jsObj.ToString();
            }
            else
            {
                jsObj = JObject.Parse(File.ReadAllText(filePath));
                array = (JArray)jsObj["string_array"];
                array.Add(str);
            }

            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(filePath, append: false))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, jsObj);
            }
        }
    }
}
