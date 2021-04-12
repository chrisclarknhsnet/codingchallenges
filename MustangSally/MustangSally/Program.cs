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
            var loader = new JsonLoader<CarDriver>();
            var querier = new CarDriverQueries();
            var checker = new MustangSallyChecker(cMOCK_DATA_FILE, loader, querier);
            
            var noofMustangSallys = checker.Count_Of_Mustang_Sallys();
            Console.WriteLine($"There are {noofMustangSallys} Mustang Sallys");

            var sallyNonMustangs = checker.Are_Sallys_Without_Mustang()
                ? "are" : "are not";

            Console.WriteLine($"There {sallyNonMustangs} Sallys who do not drive a Mustang");
            Console.ReadLine();
        }

        
    }
}
