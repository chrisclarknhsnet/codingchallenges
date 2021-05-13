using System.Collections.Generic;

namespace PreviousTechTest
{
    public interface ILoader
    {
        void GetReader();
        IList<OrganisationAgeInfo> LoadOrganisationData();
    }
}