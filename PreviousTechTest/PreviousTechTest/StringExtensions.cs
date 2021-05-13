using System;
using System.Collections.Generic;
using System.Text;

namespace PreviousTechTest
{
    public static class StringExtensions
    {
        public static OrganisationAgeInfo GetAgeInfo(this string row)
        {
            var parts = row.Split(',');
            int age;

            var ageInfo = new OrganisationAgeInfo();
            ageInfo.Code = parts[0];
            bool isAge = int.TryParse(parts[1], out age);
            ageInfo.Age = isAge ? age : (int?) null;
            ageInfo.IsAgeYear = ageInfo.Age.HasValue;
            ageInfo.IsAge95PlusBand = parts[1] == "95+";
            ageInfo.IsTotal = parts[1] == "ALL";
            ageInfo.NoMalePatients = int.Parse(parts[2]);
            ageInfo.NoFemalePatients = int.Parse(parts[3]);

            return ageInfo;
        }
    }
}
