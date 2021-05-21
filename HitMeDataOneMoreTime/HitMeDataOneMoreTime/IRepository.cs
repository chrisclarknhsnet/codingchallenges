namespace HitMeDataOneMoreTime
{
    public interface IRepository
    {
        int Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000(string artist);
        string Get_Artist_With_Most_Hit_Singles();
    }
}