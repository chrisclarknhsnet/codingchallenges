using System;
using System.Collections.Generic;
using System.Linq;

namespace HitMeDataOneMoreTime
{
    public class Repository : IRepository
    {
        private IEnumerable<HitSingle> _data;

        public Repository(IEnumerable<HitSingle> hitSingles)
        {
            _data = hitSingles;
        }

        public int Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000(string artist)
        {
            return _data.Count(hs =>
                hs.artist.ToLower() == artist.ToLower() &&
                (hs.dateentered - new DateTime(2000, 1, 1)).TotalDays >= 0
            );
        }

        public string Get_Artist_With_Most_Hit_Singles()
        {
            var x =  _data.OrderByDescending(o => o.artist.Length).First();
            return _data
                .GroupBy(hs => hs.artist.ToLower())
                .OrderByDescending(o => o.Count())
                .FirstOrDefault()
                .Key;
        }

        public string Get_Song_With_Longest_Playtime()
        {
            return _data
                .Select(s => new { song = s.track, time = timeAsStringToTimespan(s.time) })
                .OrderByDescending(o => o.time.TotalSeconds)
                .FirstOrDefault()
                .song;
        }

        private TimeSpan timeAsStringToTimespan(string timeAsString)
        {
            // Format is mm:ss
            var parts = timeAsString.Split(':');
            var mins = Convert.ToInt32(parts[0]);
            var secs = Convert.ToInt32(parts[1]);
            return new TimeSpan(0, mins, secs);
        }
    }
}
