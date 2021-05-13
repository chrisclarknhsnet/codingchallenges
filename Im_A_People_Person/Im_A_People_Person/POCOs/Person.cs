using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace Tell_Me_About_Yourself.POCOs
{
    public class Person
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public IList<string> contacts { get; set; }
        public bool IsActive { get; set; }
    }
}
