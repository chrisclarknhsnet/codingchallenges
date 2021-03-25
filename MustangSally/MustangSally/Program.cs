using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mustang_Sally
{
    class Program
    {
        private static string cMOCK_DATA_FILE = @"MOCK_DATA.json";

        static void Main(string[] args)
        {
            var carDrivers = loadJson();
            var noofMustangSallys = howManySallyMustangs(carDrivers);
            Console.WriteLine($"There are {noofMustangSallys} Mustang Sallys");
            
            var sallyNonMustangs = areThereAnySallysWhoDontDriveMustangs(carDrivers)
                ? "are" : "are not";

            Console.WriteLine($"There {sallyNonMustangs} Sallys who do not drive a Mustang");
            Console.ReadLine();
        }

        // How many people named Sally drive a Mustang car?
        private static int howManySallyMustangs(IList<CarDriver> carDrivers)
        {
            return carDrivers.Count(
                cd =>
                cd.first_name == "Sally" &&
                cd.car_model == "Mustang");
        }

        private static bool areThereAnySallysWhoDontDriveMustangs(IList<CarDriver> carDrivers)
        {
            return carDrivers.Any(
                cd =>
                cd.first_name == "Sally" &&
                cd.car_model != "Mustang");
        }

        private static IList<CarDriver> loadJson()
        {
            using (var r = new StreamReader(cMOCK_DATA_FILE))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<CarDriver>>(json);
                return items;
            }
        }
    }
}
