using System;
using System.Collections.Generic;

namespace A_Premier_Challenge
{
    class Program
    {
        private const string cDATAFILE = "epl20072008.csv";

        static void Main(string[] args)
        {
            var data = Loader.GetData(cDATAFILE);
            var repository = new Repository(data);

            Console.WriteLine("Questions 1:");
            var qu1count = repository.GetCountOfTeamsByMinPoints("M", 51);
            Console.WriteLine($"No of teams starting with M >= 50 points = {qu1count}");

            Console.WriteLine("Question 2:");
            var cityorunited = repository.GetBestAverage_ByTeamsIncludingWord(new List<string>() { "City", "United" });
            Console.WriteLine($"The better points average was by teams with {cityorunited} in their name");

            Console.WriteLine("Question 3:");
            Console.WriteLine("Banding as follows:");
            var bandings = repository.FindCountOfTeams_Within_20Point_Bands();

            foreach (var banding in bandings)
            {
                Console.WriteLine($"{banding.Key} = {banding.Value} team(s)");
            }

            Console.WriteLine("Question 4:");
            var bestteam = repository.Get_Team_With_Best_Points_Per_Goal();
            Console.WriteLine($"Team with best points per goal average is {bestteam.Team}");


            Console.ReadLine();
        }
    }
}
