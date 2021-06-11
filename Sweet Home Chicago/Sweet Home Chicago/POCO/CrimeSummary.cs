using System;

namespace Sweet_Home_Chicago.POCO
{
    public class CrimeSummary
    {
        public string CaseNumber { get; set; }
        public DateTime Date { get; set; }
        public string PrimaryType { get; set; }
        public string LocationDescrtiption { get; set; }
        public bool Arrest { get; set; }
        public bool Domestic { get; set; }
        public int District { get; set; }
        public int Ward { get; set; }
    }
}
