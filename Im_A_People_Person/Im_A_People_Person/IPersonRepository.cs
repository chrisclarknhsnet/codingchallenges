using System.Collections.Generic;

namespace Tell_Me_About_Yourself
{
    public interface IPersonRepository
    {
        IEnumerable<string> FindSurnames_ByFirstName(string firstName);

        int Get_Max_No_Of_Contacts_For_Any_Person();
    }
}