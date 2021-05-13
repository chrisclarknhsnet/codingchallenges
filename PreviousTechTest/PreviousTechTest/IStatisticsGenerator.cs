using System.Collections.Generic;

namespace PreviousTechTest
{
    public interface IStatisticsGenerator
    {
        OrganisationAgeStatistics GenerateStatistics(IList<OrganisationAgeInfo> ageInfoBreakdown);
    }
}