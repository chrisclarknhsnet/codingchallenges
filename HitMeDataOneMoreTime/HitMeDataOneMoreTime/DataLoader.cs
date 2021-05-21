using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace HitMeDataOneMoreTime
{
    public static class DataLoader
    {
        public static IEnumerable<HitSingle> LoadData(string filename)
        {
            using (TextReader reader = new StreamReader(filename))
            {
                using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                {
                    return csv.GetRecords<HitSingle>().ToList();
                }
            }
        }
    }
}
