using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sweet_Home_Chicago
{
    class Program
    {
        private const string cFILENAME = "ChicagoCrimes2017.csv";

        private static IRepository _repository;

        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = DependencyInjection.Configure();
            _repository = serviceProvider.GetService<IRepository>();
            _repository.DataFile = cFILENAME;

            var domCnt = _repository.GetCount_OfDomesticCrimes();
            Console.WriteLine($"No of domestic = {domCnt}");

            var streetMurders = _repository.GetCount_OfStreetHomicides();
            Console.WriteLine($"No of street murders = {streetMurders}");

            var mostCommonCrime = _repository.Get_MostCommonTypeOfCrime();
            Console.WriteLine($"Most common type of crime is {mostCommonCrime}");

            var safestDistricts = _repository.Find_SafestDistricts(3);
            Console.WriteLine("Safest disticts for non-domestic crime are:");

            foreach (var district in safestDistricts)
            {
                Console.WriteLine($"{district}");
            }

            Console.ReadLine();
        }
    }
}
