using System;
using System.Collections.Generic;

namespace PreviousTechTest
{
    class Program
    {
        private const string cFILE = @"C:\Users\Chris\Downloads\flattened.csv";
        
        static void Main(string[] args)
        {
            Console.Write("START");

            doCalculations(
                new Loader(cFILE),
                new StatisticsGenerator()
            );

            Console.Write("END");
            Console.ReadLine();
        }

        private static void doCalculations(
            ILoader loader, 
            IStatisticsGenerator generator
        )
        {
            IList<OrganisationAgeInfo> ageInfo;

            do
            {
                ageInfo = loader.LoadOrganisationData();

                if (ageInfo != null)
                {
                    var stats = generator.GenerateStatistics(ageInfo);
                    Console.WriteLine($"{stats.Organisation}\t{stats.TotalMalePatients}\t{stats.TotalFemalePatients}");
                }

            } while (ageInfo != null);
        }
    }
}
