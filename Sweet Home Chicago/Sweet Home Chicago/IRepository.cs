using System;
using System.Collections.Generic;

namespace Sweet_Home_Chicago
{
    public interface IRepository
    {
        string DataFile { get; set; }

        int GetCount_OfDomesticCrimes();

        int GetCount_OfStreetHomicides();

        string Get_MostCommonTypeOfCrime();

        IList<int> Find_SafestDistricts(int noofdistricts);

        double Get_PercentageOfStreetAssaults_ByWeekday(DayOfWeek weekday);
    }
}