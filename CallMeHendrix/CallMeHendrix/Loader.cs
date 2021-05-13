using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CallMeHendrix
{
    public static class Loader
    {
        public static IList<Feedback> LoadFeedback(string filename)
        {
            using (TextReader sr = new StreamReader(filename))
            {
                using (var csvReader = new CsvReader(sr, CultureInfo.CurrentCulture))
                {
                    return csvReader.GetRecords<Feedback>().ToList();
                }
            }
        }
    }
}
