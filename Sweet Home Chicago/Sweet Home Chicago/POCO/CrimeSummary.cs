using CsvHelper.Configuration.Attributes;
using System;

namespace Sweet_Home_Chicago.POCO
{
    public class CrimeSummary
    {
        [Name("Case Number")]
        public string CaseNumber { get; set; }


        public DateTime Date { get; set; }

        [Name("Primary Type")]
        public string PrimaryType { get; set; }

        [Name("Location Description")]
        public string LocationDescription { get; set; }

        public bool Arrest { get; set; }

        public bool Domestic { get; set; }

        public int District { get; set; }

        public int Ward { get; set; }
    }
}
