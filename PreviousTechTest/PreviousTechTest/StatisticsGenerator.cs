using System;
using System.Collections.Generic;
using System.Linq;

namespace PreviousTechTest
{
    public class StatisticsGenerator : IStatisticsGenerator
    {
        public OrganisationAgeStatistics GenerateStatistics(
            IList<OrganisationAgeInfo> ageInfoBreakdown
        )
        {
            try
            {
                var totals = ageInfoBreakdown.SingleOrDefault(aib => aib.IsTotal);

                return new OrganisationAgeStatistics()
                {
                    Organisation = totals.Code,
                    TotalMalePatients = totals.NoMalePatients,
                    TotalFemalePatients = totals.NoFemalePatients
                };
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unexpected error occured trying to find single totals row", ex);
            }
        }
    }
}
