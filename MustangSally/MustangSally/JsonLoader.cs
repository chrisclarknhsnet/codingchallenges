using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Mustang_Sally
{
    /// <summary>
    /// Generic class for reading and deserializing JSON from a file to a 
    /// collection of type T where T must match the JSON schema or use JsonProperty
    /// attributation to explcitly define the mapping.
    public class JsonLoader<T> : IJsonLoader<T>
    {
        /// <summary>
        /// Will read, load and deserialize the JSON in the input filename.
        /// </summary>
        /// <param name="filename">The full filename including path</param>
        /// <returns>The JSON data as a list of type T</returns>
        public IList<T> LoadJson(string filename)
        {
            var rawJson = getRawJson(filename);
            return deserializeJSON(rawJson);
        }

        private string getRawJson(string filename)
        {
            using (var r = new StreamReader(filename))
            {
                return r.ReadToEnd();
            }
        }

        private IList<T> deserializeJSON(string rawJson)
        {
            var settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Error
            };

            return JsonConvert.DeserializeObject<List<T>>(rawJson, settings);
        }
    }
}
