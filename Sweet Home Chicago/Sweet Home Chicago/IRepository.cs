namespace Sweet_Home_Chicago
{
    public interface IRepository
    {
        string DataFile { get; set; }

        int GetCount_OfDomesticCrimes();
    }
}