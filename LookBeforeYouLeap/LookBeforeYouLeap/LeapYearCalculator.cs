using System;

namespace LookBeforeYouLeap
{
    public class LeapYearCalculator : ILeapYearCalculator
    {
        public bool IsLeapYear(int year)
        {
            return (year % 4 == 0) && (year % 100 != 0 || year % 400 == 0);
        }

        ///// <summary>
        ///// The cheats way, but also inefficient
        ///// </summary>
        ///// <param name="year"></param>
        ///// <returns></returns>
        //public bool IsLeapYear(int year)
        //{
        //    // NOT GOOD, don't use exceptions to handle program logic they should be used for 
        //    // unexpected events.
        //    try
        //    {
        //        var dt = new DateTime(year, 2, 29);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
