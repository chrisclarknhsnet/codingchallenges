namespace PreviousTechTest
{
    public class OrganisationAgeInfo
    {
        public string Code  { get; set; }
        public int? Age { get; set; }
        public bool IsAgeYear { get; set; }
        public bool IsAge95PlusBand { get; set; }
        public bool IsTotal { get; set; }
        public int NoMalePatients { get; set; }
        public int NoFemalePatients { get; set; }
    }
}
