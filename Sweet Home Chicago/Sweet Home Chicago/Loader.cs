using CsvHelper;
using Sweet_Home_Chicago.POCO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Sweet_Home_Chicago
{
    public class Loader : ILoader
    {
        public IList<CrimeSummary> LoadData(string filename)
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
            {
                return csv.GetRecords<CrimeSummary>().ToList();
            }
        }
    }
}
