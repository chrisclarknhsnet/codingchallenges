using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Tell_Me_About_Yourself.POCOs;
using System.Linq;

namespace Tell_Me_About_Yourself
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = loadJson();
            var x = people
                .SingleOrDefault(p => p.first_name == "Thomas" && p.last_name == "Jefferson");

            Console.ReadKey();
        }


        private static IList<Person> loadJson()
        {
            using (StreamReader file = File.OpenText(@"mock_people.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var people = (List<Person>)serializer.Deserialize(file, typeof(List<Person>));
                return people;
            }
        }
    }
}
