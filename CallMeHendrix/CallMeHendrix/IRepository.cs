using System;
using System.Collections.Generic;

namespace CallMeHendrix
{
    public interface IRepository
    {
        DateTime Get_Date_Of_Earliest_Feedback();
        DateTime Get_Date_Of_Most_Recent_Feedback();
        int Get_NoOfFeedbacks_By_ODSCode(string ODSCode);
        int Get_NoOfFeedbacks_For_Non_NHSMail_For_Pages(IList<string> pages);
        string Get_Most_Disliked_Page_Design();
        int Get_Count_Of_Users_With_Multiple_Pages(int minPages = 2);
        int Get_TotalNoOf_Users();
    }
}