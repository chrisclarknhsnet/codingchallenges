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


            Console.ReadLine();
        }
    }
}
