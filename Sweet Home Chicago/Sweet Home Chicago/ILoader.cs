using Sweet_Home_Chicago.POCO;
using System.Collections.Generic;

namespace Sweet_Home_Chicago
{
    public interface ILoader
    {
        IList<CrimeSummary> LoadData(string filename);
    }
}