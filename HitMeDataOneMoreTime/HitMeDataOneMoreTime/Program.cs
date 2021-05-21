using System;

namespace HitMeDataOneMoreTime
{
    class Program
    {
        private const string cFILENAME = "billboard.csv";

        static void Main(string[] args)
        {
            Console.Write("Loading data and setting repository...");
            var data = DataLoader.LoadData(cFILENAME);
            var repos = new Repository(data);
            Console.WriteLine("done");

            Console.Write("Getting number of Mariah singles...");
            var noofhits = repos.Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000("Carey, Mariah");
            Console.WriteLine("done");
            Console.WriteLine($"Mariah Carey had {noofhits} hits within the year 2000");

            Console.Write("Getting artist with most hit singles...");
            var topartist = repos.Get_Artist_With_Most_Hit_Singles();
            Console.WriteLine("done");
            Console.WriteLine($"The artist with the most hits in 2000 was {topartist}");

            Console.Write("Getting song with longest playtime...");
            var longestsong = repos.Get_Song_With_Longest_Playtime();
            Console.WriteLine("done");
            Console.WriteLine($"The song with the longest playtime was {longestsong}");


            Console.ReadLine();
        }
    }
}
