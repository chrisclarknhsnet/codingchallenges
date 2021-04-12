using System.Collections.Generic;

namespace Mustang_Sally
{
    /// <summary>
    /// Generic interface for reading and deserializing JSON from a file to a 
    /// collection of type T where T must match the JSON schema or use JsonProperty
    /// attributation to explcitly define the mapping.
    /// </summary>
    public interface IJsonLoader<T>
    {
        /// <summary>
        /// Will read, load and deserialize the JSON in the input filename
        /// </summary>
        /// <param name="filename">The full filename including path</param>
        /// <returns>The JSON data as a list of type T</returns>
        IList<T> LoadJson(string filename);
    }
}