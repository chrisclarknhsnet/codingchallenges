using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace A_Premier_Challenge
{
    public static class Loader
    {
        public static IList<TeamResults> GetData(string filename)
        {
            using (TextReader reader = new StreamReader(filename))
            {
                using (var csv = new CsvReader(reader, CultureInfo.CurrentUICulture))
                {
                    return csv.GetRecords<TeamResults>().ToList();
                }
            }
        }
    }
}
