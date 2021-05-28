using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A_Premier_Challenge
{
    public class Repository : IRepository
    {
        private const int cBANDING_RANGES = 20;

        private IList<TeamResults> _results;

        public Repository(IList<TeamResults> results)
        {
            _results = results;
        }

        public int GetCount()
        {
            return _results.Count();
        }

        public int GetCountOfTeamsByMinPoints(string nameprefix, int minpoints)
        {
            return _results.Count(
                tr => 
                tr.Team.ToLower().StartsWith(nameprefix.ToLower()) && 
                tr.Points >= minpoints
            );
        }

        public string GetBestAverage_ByTeamsIncludingWord(IList<string> words)
        {
            return _results
                .Where(tr => words.Any(w => tr.Team.ToLower().Contains(w.ToLower())))
                .GroupBy(g => words.Single(w => g.Team.ToLower().Contains(w.ToLower())))
                .Select(s => new { Word = s.Key, averagePoints = s.Average(a => a.Points) })
                .OrderByDescending(o => o.averagePoints)
                .First().Word;
        }

        public IDictionary<string, int> FindCountOfTeams_Within_20Point_Bands()
        {
            return _results
                .GroupBy(g => g.Points / cBANDING_RANGES)
                .ToDictionary(s => getDescriptionFromBandNo(s.Key), s => s.Count());
        }

        public TeamResults Get_Team_With_Best_Points_Per_Goal()
        {
            return _results
                .Select(s => new { Team = s, Average = ((decimal)s.Points) / ((decimal)s.GoalsFor) })
                .OrderByDescending(o => o.Average)
                .Select(s => s.Team)
                .First();
        }

        private string getDescriptionFromBandNo(int bandno)
        {
            var lowerlimit = bandno * cBANDING_RANGES;
            var upperlimit = ((bandno + 1) * cBANDING_RANGES) - 1;
            return $"{lowerlimit} - {upperlimit}";
        }

    }
}
