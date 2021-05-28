using System.Collections.Generic;

namespace A_Premier_Challenge
{
    public interface IRepository
    {
        int GetCount();

        int GetCountOfTeamsByMinPoints(string nameprefix, int minpoints);

        string GetBestAverage_ByTeamsIncludingWord(IList<string> words);

        IDictionary<string, int> FindCountOfTeams_Within_20Point_Bands();

        TeamResults Get_Team_With_Best_Points_Per_Goal();
    }
}