using System;

namespace Sweet_Home_Chicago
{
    class Program
    {
        private const string cFILENAME = "ChicagoCrime2017.csv";

        private IRepository _repository;

        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = DependencyInjection.Configure();
            
        }
    }
}
