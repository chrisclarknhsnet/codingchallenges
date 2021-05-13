using System;
using System.Collections.Generic;

namespace CallMeHendrix
{
    class Program
    {
        public const string cFILENAME = "Feedback.csv";

        static void Main(string[] args)
        {
            var data = Loader.LoadFeedback(cFILENAME);
            var repos = new Repository(data);

            Console.WriteLine("===================================");

            var VM6AFNumber = repos.Get_NoOfFeedbacks_By_ODSCode("VM6AF");
            Console.WriteLine($"VM6AF has provided {VM6AFNumber} feedback items");

            Console.WriteLine("===================================");

            var earliestDate = repos.Get_Date_Of_Earliest_Feedback();
            var latestDate = repos.Get_Date_Of_Most_Recent_Feedback();

            Console.WriteLine($"Earliest feedback was provided on {earliestDate}");
            Console.WriteLine($"Most recent feedback was provided on {latestDate}");

            Console.WriteLine("===================================");

            var pages = new List<string>()
            {
                "/Publication/Published",
                "Assessment/ActionPlan"
            };

            var nooffeedbacks = repos.Get_NoOfFeedbacks_For_Non_NHSMail_For_Pages(pages);
            Console.WriteLine($"No of non NHS feedbacks for pages = {nooffeedbacks}");

            Console.WriteLine("===================================");

            var mostdislikedPage = repos.Get_Most_Disliked_Page_Design();
            Console.WriteLine($"The most disliked page design was {mostdislikedPage}");

            Console.WriteLine("===================================");

            var nousersmorethanonepage = repos.Get_Count_Of_Users_With_Multiple_Pages();
            Console.WriteLine($"No of users providing feedback on > 1 page = {nousersmorethanonepage}");

            var totalnousers = repos.Get_TotalNoOf_Users();
            Console.WriteLine($"Total No of users = {totalnousers}");

            Console.WriteLine("===================================");
        }
    }
}
