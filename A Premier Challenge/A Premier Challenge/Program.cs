using System;

namespace A_Premier_Challenge
{
    class Program
    {
        private const string cDATAFILE = "epl20072008.csv";

        static void Main(string[] args)
        {
            var data = Loader.GetData(cDATAFILE);
            var repository = new Repository(data);
            Console.WriteLine($"We have {repository.GetCount()} results");
            Console.ReadLine();
        }
    }
}
