using System;
using System.Collections.Generic;
using System.Linq;

namespace CallMeHendrix
{
    public class Repository : IRepository
    {
        private IList<Feedback> _data;

        public Repository(IList<Feedback> data)
        {
            _data = data;
        }

        public int Get_NoOfFeedbacks_By_ODSCode(string ODSCode)
        {
            return _data.Count(fb => fb.ODSCode == ODSCode);
        }

        public DateTime Get_Date_Of_Earliest_Feedback()
        {
            return _data.OrderBy(o => o.CreatedOn).First().CreatedOn;
        }

        public DateTime Get_Date_Of_Most_Recent_Feedback()
        {
            return _data.OrderByDescending(o => o.CreatedOn).First().CreatedOn;
        }

        public int Get_NoOfFeedbacks_For_Non_NHSMail_For_Pages(IList<string> pages)
        {
            return _data
                .Where(fb => !fb.CreatedByEmail.ToLower().EndsWith(".nhs.net"))
                .Count(fb => pages.Any(p => fb.PageVisited.ToLower().EndsWith(p.ToLower())));
        }

        public string Get_Most_Disliked_Page_Design()
        {
            return _data
                .Where(fb => fb.Design == "Dislike")
                .GroupBy(fb => fb.PageVisited)
                .OrderByDescending(o => o.Count())
                .First()
                .Key;
        }

        public int Get_Count_Of_Users_With_Multiple_Pages(int minPages = 2)
        {
            return _data
                .GroupBy(g => g.CreatedByEmail)
                .Select(s => new { 
                    User = s.Key, 
                    Pages = s.Select(p => p.PageVisited).Distinct() 
                })
                .Where(g => g.Pages.Count() >= minPages)
                .Count();
        }

        public int Get_TotalNoOf_Users()
        {
            return _data.Select(s => s.CreatedByEmail).Distinct().Count();
        }
    }
}
